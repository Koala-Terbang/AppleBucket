using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            FindObjectOfType<TimeManager>().AddScore(1);

            WindEffect.Instance.UpdateWind();

            other.GetComponent<AppleThrow>().ResetApple();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
