using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentHUD : MonoBehaviour
{
    public GameObject kettle;

    float pressureValue = 75;

    Text pressureValueTxt;
    // Start is called before the first frame update
    void Start()
    {
        pressureValueTxt = this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        gameObject.SetActive(false);
        kettle.SetActive(true);
    }
    public void ChangePressureValue(float value)
    {
        pressureValue = value;
        pressureValueTxt.text = value.ToString();
    }
}
