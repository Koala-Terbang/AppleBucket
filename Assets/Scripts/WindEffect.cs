using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour
{
    public float windStrength = 0f;
    private Vector3 windDirection = Vector3.zero;

    public static WindEffect Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateWind();
    }

    public void ApplyWindForce(Rigidbody appleRb)
    {
        if (windStrength != 0)
        {
            appleRb.AddForce(windDirection * windStrength, ForceMode.Force);
        }
    }

    public void UpdateWind()
    {
        windStrength = Random.Range(0f, 0.3f);
        float direction = Random.Range(0, 2) == 0 ? -1f : 1f;
        windDirection = new Vector3(direction, 0, 0);
    }

    public Vector3 GetWindDirection()
    {
        return windDirection;
    }

    public float GetWindStrength()
    {
        return windStrength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
