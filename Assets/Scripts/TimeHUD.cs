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
    Text currentTimeTxt;
    float currTemp = -1.0f;

    bool passed = false;
    // Start is called before the first frame update
    void Start()
    {
        timeTxt = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        boilingTempTxt = this.gameObject.transform.GetChild(3).GetComponent<Text>();
        currentTimeTxt = this.gameObject.transform.GetChild(5).GetComponent<Text>();

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
            currentTimeTxt.text = (CurrentTemp()).ToString();
        }

        if (isActiveAndEnabled)
        {
            if(!passed)
            {
                //time = Storage.GetTurnToSteamTime();

                if (time - Storage.GetTurnToSteamTime() - Storage.GetTimeAfterBoiling() <= 0 && !invokeOnce)
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
        float tempPerSecond = (Storage.GetBoilingTemp() - Storage.GetT1Value()) / Storage.GetTimeBeforeBoiling();

        if (currTemp == -1.0f)
        {
            currTemp = Storage.GetT1Value();
            currTemp = Mathf.Round(currTemp);
        }
        else
        {
            if (currTemp < boilingTemp)
            {
                currTemp = currTemp + tempPerSecond;
                if (currTemp > boilingTemp)
                {
                    currTemp = boilingTemp;
                }
                currTemp = Mathf.Round(currTemp);
            }
            else
            {
                currTemp = boilingTemp;
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
