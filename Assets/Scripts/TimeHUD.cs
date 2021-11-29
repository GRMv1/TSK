using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHUD : MonoBehaviour
{
    [SerializeField] Storage Storage;

    [SerializeField] Kettle kettle;
    float time;
    float boilingTemp;
    Text timeTxt;
    Text boilingTempTxt;
    int iteratorBoil = 0;
    bool invokeOnce = false;

    float elapsed = 0f;
    Text currentTempTxt;
    float currTemp = -1.0f;

    Text T1txt;
    Text T2txt;


    bool passed = false;
    // Start is called before the first frame update
    void Start()
    {
        timeTxt = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        boilingTempTxt = this.gameObject.transform.GetChild(3).GetComponent<Text>();
        currentTempTxt = this.gameObject.transform.GetChild(5).GetComponent<Text>();
        T1txt = this.gameObject.transform.GetChild(7).GetComponent<Text>();
        T2txt = this.gameObject.transform.GetChild(9).GetComponent<Text>();

        T1txt.text = Storage.GetT1Value().ToString();

        T2txt.text = Storage.GetT2Value().ToString();


        time = Storage.GetTime();
        time = Mathf.Round(time);
        timeTxt.text = time.ToString();

        boilingTemp = Storage.GetBoilingTemp();
        boilingTemp = Mathf.Round(boilingTemp);
        boilingTempTxt.text = boilingTemp.ToString();

        InvokeRepeating("TimeRemaining", 0.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            currentTempTxt.text = (CurrentTemp()).ToString();
        }

        if (isActiveAndEnabled)
        {
            if(!passed)
            {
                //time = Storage.GetTurnToSteamTime();
                if(Storage.lessThanBoilingTemp)
                    kettle.increaseSpeed = 0.00015f;

                if ( (time - Storage.GetTurnToSteamTime() - Storage.GetTimeAfterBoiling() <= 0) && !invokeOnce && !Storage.lessThanBoilingTemp)
                {
                    
                    InvokeRepeating("Evaporation", 0.0f, kettle.secondsToEvaporate);
                    invokeOnce = true;
                }
            }
            if(passed)
            {

            }
            
        }
    }

    void TimeRemaining()
    {
        if(time>0)
        {
            time = time - 1;
            timeTxt.text = time.ToString();
            kettle.UpdateDropSpeed();
        }
        
    }

    float CurrentTemp()
    {
        float tempPerSecondBeforeBoiling;

        if (Storage.GetT2Value() < boilingTemp)
        {
            tempPerSecondBeforeBoiling = (Storage.GetT2Value() - Storage.GetT1Value()) / Storage.GetTimeBeforeT2();
        }
        else
        {
            tempPerSecondBeforeBoiling = (Storage.GetBoilingTemp() - Storage.GetT1Value()) / Storage.GetTimeBeforeBoiling();
        }
        

        float tempPerSecondAfterBoiling = (Storage.GetT2Value() - Storage.GetBoilingTemp()) / Storage.GetTimeAfterBoiling();

        if (currTemp == -1.0f)
        {
            currTemp = Storage.GetT1Value();
            currTemp = Mathf.Round(currTemp);
        }
        else
        {
            if(boilingTemp < Storage.GetT2Value())
            {
                if (currTemp < boilingTemp)
                {
                    currTemp = currTemp + tempPerSecondBeforeBoiling;
                    if (currTemp > boilingTemp)
                    {
                        currTemp = boilingTemp;
                    }
                    currTemp = Mathf.Round(currTemp * 100f) / 100f;
                }
                else
                {
                    currTemp = boilingTemp;
                }
                if (currTemp == boilingTemp && time - Storage.GetTimeAfterBoiling() <= 0)
                {
                    currTemp = currTemp + tempPerSecondAfterBoiling;
                    if (currTemp <= Storage.GetT2Value())
                    {
                        currTemp = Storage.GetT2Value();
                    }
                    currTemp = Mathf.Round(currTemp * 100f) / 100f;
                }
            }
            else
            {
                if (currTemp < Storage.GetT2Value())
                {
                    Debug.Log("halo");
                    currTemp = currTemp + tempPerSecondBeforeBoiling;
                    if (currTemp >= Storage.GetT2Value())
                    {
                        currTemp = Storage.GetT2Value();
                    }
                    currTemp = Mathf.Round(currTemp * 100f) / 100f;
                }
                else
                {
                    currTemp = Storage.GetT2Value();
                }
            }
            
            
        }
        
        
        
        return currTemp;
    }

    void Evaporation()
    {
        kettle.ChangeToSteam(iteratorBoil);
        iteratorBoil = iteratorBoil + 1;

        if (time - Storage.GetTimeAfterBoiling() <= 0)
        {
            CancelInvoke("Evaporation");
        }
    }
}
