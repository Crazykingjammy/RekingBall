using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
     Transform CenterPoint;

    public float speed = 10.0f;
    // int boundary = 1;
    //int width;
    //int height;
    [SerializeField]
    float Height = 10;

    [SerializeField]
    float Radius = 10;

    [SerializeField]
    float AnglePosition = 90.0f;

    private Vector3 offset; 

    // Start is called before the first frame update
    void Start()
    {
        //width = Screen.width;
        //height = Screen.height;
        offset = (transform.position - CenterPoint.position).normalized * Radius;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            Quaternion q = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up);
            offset = q * offset;
            transform.rotation = q * transform.rotation;

        }

        transform.position = CenterPoint.position + offset;

        //transform.position = CenterPoint.position - new Vector3(AnglePosition,Height, Radius);

        //transform.LookAt(CenterPoint);


        //always update the position
       // transform

        //if (Input.GetMouseButton(0))
        //{
        //    if (Input.GetAxis("Mouse X") > 0)
        //    {
        //        transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
        //                                   0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        //    }

        //    else if (Input.GetAxis("Mouse X") < 0)
        //    {
        //        transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
        //                                   0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        //    }

        //}

    }
}
