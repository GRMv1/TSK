using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentHUD : MonoBehaviour
{
    public GameObject kettle;
    public GameObject TimeHUD;

    public static float pressureValue = 75;
    public static float speedValue = 1f;

    Text pressureValueTxt;
    Text speedValueTxt;
    // Start is called before the first frame update
    void Start()
    {
        pressureValueTxt = this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>();
        speedValueTxt = this.gameObject.transform.GetChild(1).GetChild(2).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        gameObject.SetActive(false);
        kettle.SetActive(true);
        TimeHUD.SetActive(true);
    }
    public void ChangePressureValue(float value)
    {
        pressureValue = value;
        pressureValueTxt.text = value.ToString();
    }
    public void ChangeSpeedValue(float value)
    {
        speedValue = value;
        speedValueTxt.text = value.ToString();
    }
}
