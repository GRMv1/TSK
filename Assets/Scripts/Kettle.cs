using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kettle : MonoBehaviour
{
    float powerValue = 500;
    float efficiencyValue = 1;

    public int waterDropNumber = 0;

    Text powerValueTxt;
    Text efficiencyValueTxt;
    GameObject water;
    Transform newTransform;
    // Start is called before the first frame update
    void Start()
    {
        
        water = this.gameObject.transform.GetChild(0).gameObject;
        newTransform = this.gameObject.transform;
        water.transform.localScale = new Vector3(0.25f, 0.25f,1);
        for (int i = 0; i< waterDropNumber; i++)
        {
            Instantiate(water, newTransform.position, newTransform.rotation, newTransform);
        }
            

        powerValueTxt = GetComponent<Text>();
        efficiencyValueTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
