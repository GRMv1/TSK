using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public static float massValue;
    public static float t1Value;
    public static float t2Value;

    [SerializeField]
    private GameObject liquidHUD;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(liquidHUD.activeSelf)
        {
            massValue = LiquidHUD.massValue;
            t1Value = LiquidHUD.t1Value;
            t2Value = LiquidHUD.t2Value;
        }
    }
}
