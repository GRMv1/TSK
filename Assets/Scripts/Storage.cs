using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public static float massValue;          //g
    public static float t1Value;            //°C
    public static float t2Value;            //°C
    public static float powerValue;         //W
    public static float efficiencyValue;    //%
    public static float pressureValue;      //hPa
    

    [SerializeField]
    private GameObject liquidHUD;

    [SerializeField]
    private GameObject kettleHUD;

    [SerializeField]
    private GameObject envHUD;
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
        if (kettleHUD.activeSelf)
        {
            powerValue = KettleHUD.powerValue;
            efficiencyValue = KettleHUD.efficiencyValue;
        }
        if (envHUD.activeSelf)
        {
            pressureValue = EnvironmentHUD.pressureValue;
        }
    }

    public float GetTurnToSteamTime()
    {
        float n = massValue / 18.02f;   // mol
        float deltaH = 40.7f;           // kJ/mol

        float turnToSteamTime = (n * deltaH * 1000) / ((efficiencyValue / 100) * powerValue);
        return turnToSteamTime;
    }

    public float GetTimeBeforeBoiling()
    {
        float Cliquid = 4.1899f;           // J/(g * °C )
        float boilingTemp = Mathf.Pow((1.0f / 100.0f) - (8.3145f * Mathf.Log(pressureValue / 1000.0f) / 2257.0f), -1.0f);

        float timeBeforeBoiling = (massValue * Cliquid * (boilingTemp - t1Value)) / ((efficiencyValue / 100) * powerValue);

        return timeBeforeBoiling;
    }

    public float GetTimeAfterBoiling()
    {
        float Cgas = 1.890f;              // J/(g * °C )
        float boilingTemp = Mathf.Pow((1.0f / 100.0f) - (8.3145f * Mathf.Log(pressureValue / 1000.0f) / 2257.0f), -1.0f);

        float timeAfterBoiling = (massValue * Cgas * (t2Value - boilingTemp)) / ((efficiencyValue / 100) * powerValue);

        return timeAfterBoiling;
    }

    public float GetTime()
    {

        //time = {[m * Cliquid * (tw – t1)] + (n * deltaH) + [m * Cgas * (t2 – tw)]}/( efficiency * P)
        // boilingTemp = ((1/T0) - ((R * ln(P/P0))/deltaHvap))^-1
        //float boilingTemp = 100.0f;
        float boilingTemp = Mathf.Pow((1.0f / 100.0f) - (8.3145f * Mathf.Log(pressureValue / 1000.0f) / 2257.0f), -1.0f);
        float time;
        float Cliquid = 4.1899f;           // J/(g * °C )
        float Cgas = 1.890f;              // J/(g * °C )
        float n = massValue / 18.02f;   // mol
        float deltaH = 40.7f;           // kJ/mol



        if (t2Value > 100)
        {
            time = ((massValue * Cliquid * (boilingTemp - t1Value)) + (n * deltaH * 1000) + (massValue * Cgas * (t2Value - boilingTemp))) / ((efficiencyValue / 100) * powerValue);
        }
        else
        {
            time = (massValue * Cliquid * (boilingTemp - t1Value)) / ((efficiencyValue / 100) * powerValue);
        }

        

        //return time;
        return GetTimeBeforeBoiling() + GetTimeAfterBoiling() + GetTurnToSteamTime();
    }

    public float GetBoilingTemp()
    {
        // boilingTemp = ((1/T0) - ((R * ln(P/P0))/deltaHvap))^-1

        float boilingTemp = Mathf.Pow((1.0f / 100.0f) - (8.3145f * Mathf.Log(pressureValue / 1000.0f) / 2257.0f), -1.0f);

        return boilingTemp;
    }
}
