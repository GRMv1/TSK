using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kettle : MonoBehaviour
{
    public int waterDropNumber = 0;
    
    GameObject water;
    Transform newTransform;
    // Start is called before the first frame update

    void Start()
    {
        if(this.gameObject.transform.childCount!=0)
        {
            water = this.gameObject.transform.GetChild(0).gameObject;
            newTransform = this.gameObject.transform;
            water.transform.localScale = new Vector3(0.25f, 0.25f, 1);
            for (int i = 0; i < waterDropNumber; i++)
            {
                Instantiate(water, newTransform.position, newTransform.rotation, newTransform);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
