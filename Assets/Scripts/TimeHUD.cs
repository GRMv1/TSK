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

    bool passed = false;
    // Start is called before the first frame update
    void Start()
    {
        timeTxt = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        boilingTempTxt = this.gameObject.transform.GetChild(3).GetComponent<Text>();

        time = Storage.GetTime();
        time = Mathf.Round(time);
        timeTxt.text = time.ToString();

        boilingTemp = Storage.GetBoilingTemp();
        boilingTemp = Mathf.Round(boilingTemp);
        boilingTempTxt.text = boilingTemp.ToString();

        InvokeRepeating("TimePassed", 0.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isActiveAndEnabled)
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

    void TimePassed()
    {
        if(time>0)
        {
            time = time - 1;
            timeTxt.text = time.ToString();
            kettle.UpdateDropSpeed();
        }
        
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
