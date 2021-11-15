using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public float wiggleSpeedY = 0.0f;
    float wiggleSpeedX = 0.0f;
    public static float maxSpeedY = 0.2f;

    public static float dropMass = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetSpeed()
    {
        return wiggleSpeedY;
    }    

    public void SetSpeed( float newSpeed )
    {
        wiggleSpeedY = newSpeed;
    }

    public void Wiggle()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + wiggleSpeedX, this.gameObject.transform.position.y + wiggleSpeedY, this.gameObject.transform.position.z);
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - wiggleSpeedX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
}
