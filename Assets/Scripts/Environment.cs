using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Environment : MonoBehaviour
{
    float pressureValue = 75;

    Text pressureValueTxt;
    // Start is called before the first frame update
    void Start()
    {
        pressureValueTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePressureValue(float value)
    {
        pressureValue = value;
        pressureValueTxt.text = value.ToString();
    }
}
