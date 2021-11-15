using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Kettle : MonoBehaviour
{
    int waterDropNumber = 9;
    private static float waterDropMass;
    public float mass;
    //public float mass = 0;
    GameObject water;
    Transform newTransform;
    WaterDrop[] waterDropTable;

    [SerializeField]
    private Storage storage;
    //private GameObject storage;


    // Start is called before the first frame update
    private void OnEnable()
    {
        mass = Storage.massValue;
    }

    void Start()
    {
        water = this.gameObject.transform.GetChild(0).gameObject;

        waterDropMass = WaterDrop.dropMass;
        waterDropNumber =  ((int)(mass / waterDropMass));

        newTransform = this.gameObject.transform;
        water.transform.localScale = new UnityEngine.Vector3(0.25f, 0.25f, 1);
        for (int i = 0; i < waterDropNumber; i++)
        {
            Instantiate(water, newTransform.position, newTransform.rotation, newTransform);
        }

        waterDropTable = FindObjectsOfType<WaterDrop>();
        //Debug.Log(waterDropTable[0].name);
    }

    public void UpdateDropSpeed()
    {
        foreach (WaterDrop w in waterDropTable)
        {
            w.SetSpeed(w.GetSpeed()+storage.increaseSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(WaterDrop w in waterDropTable)
        {
            w.Wiggle();
        }
    }

    
}
