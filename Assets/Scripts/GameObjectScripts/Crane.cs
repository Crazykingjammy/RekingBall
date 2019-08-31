using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField]
    Rigidbody WreckingBall, Handle;

    [SerializeField]
    Collider Boundaries, GroundCollider;

    [SerializeField]
    GameObject Vehicle, Shaft, BoundaryField;


    [SerializeField]
    float speed;



    [SerializeField]
    Vector3  RangeMax;

    //Variables for movement of the crane.
    Vector3 offsetPosition, normalizedOffsetPosition;
    float offsetRotation;

   
    

    // Start is called before the first frame update
    void Start()
    {
        //Ensure the wrecking ball rigid body is kenetic upon start.
        WreckingBall.isKinematic = true;
        Handle.isKinematic = true;

        //Hide the grid my default.
        BoundaryField.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        //Update the position of the vehicle.
        //Only set the x and Z values, becasue the height is set by the shaft.
        Vehicle.transform.localPosition =  new Vector3(offsetPosition.x, 0.0f, offsetPosition.z);
        Shaft.transform.localPosition = new Vector3(0.0f, offsetPosition.y, 0.0f);

        //Set the rotation of the shaft.
        //Rotate around the up angle. 
        Shaft.transform.localEulerAngles = new Vector3(0.0f, -RotationAngle, 0.0f);
    }


    //Internal Functions.
    bool _outOfBounds()
    {
        //Return true if we are outside of magnitude.
        if (offsetPosition.x > RangeMax.x || offsetPosition.x < -RangeMax.x)
            return true;

        //Return true if we are outside of magnitude.
        if (offsetPosition.z > RangeMax.z || offsetPosition.z < -RangeMax.z)
            return true;

        //Return false as default.
        return false;
    }


    void _calculateNormalizedPosition()
    {
        normalizedOffsetPosition = new Vector3(
            offsetPosition.x / RangeMax.x,
            offsetPosition.y / RangeMax.y,
            offsetPosition.z / RangeMax.z
            );
     
    }



    //Public Methods.
    public void MoveMe(float strafe, float forward)
    {

        offsetPosition.x += strafe * speed;
        offsetPosition.z += forward * speed;

        //Negate the amount added if the vehicle position if we are greater than our max bounds.
        if (_outOfBounds())
        {
            offsetPosition.x -= strafe * speed;
            offsetPosition.z -= forward * speed;
        }

        _calculateNormalizedPosition();

    }

    //The action function of relesing the ball.
    public void BallRelease()
    {
        //Just activate the physics and let her go!
        WreckingBall.isKinematic = false;
        Handle.isKinematic = false;
    }


    //Accessors.
    public Vector3 NormalizedPosition
    {
        get { return normalizedOffsetPosition; }
        set
        {
            offsetPosition = new Vector3(
                value.x * RangeMax.x,
                value.y * RangeMax.y,
                value.z * RangeMax.z
                );
        }
    }

    public float RotationAngle
    {
        get { return offsetRotation; }
        set
        {
            offsetRotation = value;
        }
    }

    public bool GridView
    {
        get
        {
            if(BoundaryField == null)
            {
                Debug.LogError("Trying to access Boundary Grid Game object: " + this.name);
                return false;
            }

            return BoundaryField.gameObject.activeSelf;
        }

        set
        {
            if (BoundaryField == null)
            {
                Debug.LogError("Trying to access Boundary Grid Game object: " + this.name);      
            }

            BoundaryField.gameObject.SetActive(value);

        }
    }

}

