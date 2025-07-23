using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleThrow : MonoBehaviour
{
    private Vector3 dragStartWorldPos;
    private Vector3 dragEndWorldPos;
    private Rigidbody rb;
    private bool isThrown = false;

    public float throwForce = 8f;
    public float maxForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void OnMouseDown()
    {
        Vector3 screenStartPos = Input.mousePosition;
        dragStartWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenStartPos.x, screenStartPos.y, Camera.main.nearClipPlane + 1));
    }

    void OnMouseUp()
    {
        Vector3 screenEndPos = Input.mousePosition;
        dragEndWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenEndPos.x, screenEndPos.y, Camera.main.nearClipPlane + 1));

        Vector3 throwDirection = (dragEndWorldPos - dragStartWorldPos).normalized;

        float forceMagnitude = Mathf.Clamp(Vector3.Distance(dragStartWorldPos, dragEndWorldPos) * throwForce, 0, maxForce);
        Vector3 force = throwDirection * forceMagnitude;

        rb.isKinematic = false;
        rb.AddForce(force, ForceMode.Impulse);

        isThrown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrown)
        {
            WindEffect.Instance.ApplyWindForce(rb);
            if (transform.position.y < -10)
            {
                ResetApple();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(DelayedReset());
        }
    }

    private IEnumerator DelayedReset()
    {
        yield return new WaitForSeconds(0.5f);
        ResetApple();
    }

    public void ResetApple()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = new Vector3(4.316f, 1.186f, -0.641f);
        transform.rotation = Quaternion.identity;

        rb.isKinematic = true;

        isThrown = false;
    }
}
