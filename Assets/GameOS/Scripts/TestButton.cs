using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{

    public Light SceneSun;

    public Transform SunStart, SunSet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



  public  void TODUpdate(float value)
    {

        float range = Mathf.Lerp(-25, 200, value);

        //apply the angle to the direction light.
        Quaternion sunPos = SceneSun.transform.localRotation;
        // sunPos =  Quaternion.Lerp()



        // SceneSun.transform.rotation = Quaternion.Euler(range, SceneSun.transform.rotation.y, SceneSun.transform.rotation.z);
        SceneSun.transform.rotation = Quaternion.Euler(range, 137.0f, 0.0f);



    }



    void CalculateRange()
    {

    }
}
