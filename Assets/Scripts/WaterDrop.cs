using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public float wiggleSpeedY = 0.0f;
    float wiggleSpeedX = 0.0f;
    public static float maxSpeedY = 1.5f;

    bool steam = false;

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

    public void SetSpeed(float newSpeed)
    {
        wiggleSpeedY = newSpeed;
    }

    public void Wiggle()
    {
        if(!steam)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + wiggleSpeedY, this.gameObject.transform.position.z);
        }
        else if (steam)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - wiggleSpeedY, this.gameObject.transform.position.z);
        }
        //this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - wiggleSpeedX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }

    public void Evaporate()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = -13f;
        this.GetComponent<SpriteRenderer>().color = Color.gray;
        steam = true;
    }

    public bool IsSteam()
    {
        return steam;
    }

}
