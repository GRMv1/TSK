using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHUD : MonoBehaviour
{
    [SerializeField] Storage Storage;

    float time;
    Text timeTxt;
    // Start is called before the first frame update
    void Start()
    {
        timeTxt = this.gameObject.transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActiveAndEnabled)
        {
            time = Storage.GetTime();
            time = Mathf.Round(time);
            timeTxt.text = time.ToString();
            
        }
    }
}
