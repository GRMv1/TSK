using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Liquid : MonoBehaviour
{
    float massValue = 2;
    float t1Value = 1;
    float t2Value = 21;

    Text massValueTxt;
    Text t1ValueTxt;
    Text t2ValueTxt;
    // Start is called before the first frame update
    void Start()
    {
        massValueTxt = GetComponent<Text>();
        t1ValueTxt = GetComponent<Text>();
        t2ValueTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMassValue(float value)
    {
        massValue = value;
        massValueTxt.text = value.ToString();
    }
    public void ChangeT1Value(float value)
    {
        t1Value = value;
        t1ValueTxt.text = value.ToString();
    }
    public void ChangeT2Value(float value)
    {
        t2Value = value;
        t2ValueTxt.text = value.ToString();
    }
}
