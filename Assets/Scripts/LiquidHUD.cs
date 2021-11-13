using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidHUD : MonoBehaviour
{
    public GameObject kettleHUD;

    public static float massValue = 2;
    public static float t1Value = 1;
    public static float t2Value = 21;

    Text massValueTxt;
    Text t1ValueTxt;
    Text t2ValueTxt;

    // Start is called before the first frame update
    void Start()
    {
        massValueTxt = this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>();
        t1ValueTxt = this.gameObject.transform.GetChild(1).GetChild(2).GetComponent<Text>();
        t2ValueTxt = this.gameObject.transform.GetChild(2).GetChild(2).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        gameObject.SetActive(false);
        kettleHUD.SetActive(true);
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
