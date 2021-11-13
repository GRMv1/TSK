using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KettleHUD : MonoBehaviour
{
    public GameObject environmentHUD;

    float powerValue = 500;
    float efficiencyValue = 1;

    Text powerValueTxt;
    Text efficiencyValueTxt;
    // Start is called before the first frame update
    void Start()
    {
        powerValueTxt = GetComponent<Text>();
        efficiencyValueTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        gameObject.SetActive(false);
        environmentHUD.SetActive(true);
    }
    public void ChangePowerValue(float value)
    {
        powerValue = value;
        powerValueTxt.text = value.ToString();
    }
    public void ChangeEfficiencyValue(float value)
    {
        efficiencyValue = value;
        efficiencyValueTxt.text = value.ToString();
    }
}
