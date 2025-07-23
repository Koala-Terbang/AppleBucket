using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindIndicator : MonoBehaviour
{
    public Text windText;
    public Image windArrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float windStrength = WindEffect.Instance.GetWindStrength();
        Vector3 windDirection = WindEffect.Instance.GetWindDirection();

        string directionText = windDirection.x > 0 ? "Left" : "Right";
        windText.text = $"{windStrength:F2}";

        windArrow.rectTransform.rotation = Quaternion.Euler(0, windDirection.x > 0 ? 180 : 0, 0);
    }
}
