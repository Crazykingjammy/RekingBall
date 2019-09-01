using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //Grab the transform point to focus the camera around.
    [SerializeField]
     Transform CenterPoint;

    //Grab the rec of the window that ae are going to test against for mouse camera movement.
    [SerializeField]
    RectTransform GameWindow;

    [SerializeField]
    float speed = 10.0f, zoomSpeed = 2.0f;

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


    public void UpdateGameCamera()
    {
        Radius += Input.GetAxis("Mouse Y") * zoomSpeed;

        //Calculate the offset every update?
        offset = (transform.position - CenterPoint.position).normalized * Radius;

        Quaternion q = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up);
        offset = q * offset;
        transform.rotation = q * transform.rotation;

        transform.position = CenterPoint.position + offset;
    }

       

    // Update is called once per frame
    void LateUpdate()
    {
       
    }

    //Call the update camera function when we are enabled.
    private void OnEnable()
    {
        UpdateGameCamera();
    }


    private bool MouseInRect()
    {
        //Grab the mouse posotion from the InverseTransformPoint.
        Vector2 mousepos = GameWindow.InverseTransformPoint(Input.mousePosition);

        if (GameWindow.rect.Contains(mousepos))
        {
            return true;
        }

        return false;
    }
}
