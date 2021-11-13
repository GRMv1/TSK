using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KettleHUD : MonoBehaviour
{
    public GameObject environmentHUD;

    public static float powerValue = 500;
    public static float efficiencyValue = 1;

    Text powerValueTxt;
    Text efficiencyValueTxt;
    // Start is called before the first frame update
    void Start()
    {
        powerValueTxt = this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>();
        efficiencyValueTxt = this.gameObject.transform.GetChild(1).GetChild(2).GetComponent<Text>();
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
