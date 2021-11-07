using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    TextMeshPro massValue;
    // Start is called before the first frame update
    void Start()
    {
        massValue = GetComponent<TextMeshPro>();
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
