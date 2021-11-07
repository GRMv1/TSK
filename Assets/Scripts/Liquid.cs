using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Liquid : MonoBehaviour
{
    Text massValue;
    // Start is called before the first frame update
    void Start()
    {
        massValue = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMassValue(float value)
    {
        massValue.text = value.ToString();
    }
}
