using UnityEngine;
using Scriptables.Variables;
using Scriptables.References;

namespace RekingBall.GameObjects
{
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



        //[SerializeField]
        //Vector3  RangeMax;

        //The max range field.
        Vector3 RangeMax => _maxRange.Value;

        [SerializeField]
        Vector3Variable _maxRange;

        [SerializeField]
        Vector3Variable _offsetPosition;

        [SerializeField]
        Vector3Variable _normalizedOffsetPosition;

        //Store a reference to the toggle of the grid. 
        [SerializeField] BoolReference ToggleGridReference;

        //Variables for movement of the crane.
        //Vector3 offsetPosition, normalizedOffsetPosition;

        Vector3 offsetPosition
        {
            get { return _offsetPosition.Value; }
            set { _offsetPosition.SetValue(value); }
        }

        Vector3 normalizedOffsetPosition
        {
            get { return _normalizedOffsetPosition.Value; }
            set { _normalizedOffsetPosition.SetValue(value); }
        }

        [SerializeField]
        FloatVariable _offsetRotation;
        float offsetRotation
        {
            get { return _offsetRotation.Value; }
            set { _offsetRotation.SetValue(value); }
        }




        // Start is called before the first frame update
        void Start()
        {
            //Ensure the wrecking ball rigid body is kenetic upon start.
            WreckingBall.isKinematic = true;
            Handle.isKinematic = true;

            //Hide the grid my default.
            BoundaryField.SetActive(false);

            //GridToggle.ValueChanged = OnToggleChange();
            ToggleGridReference.ValueChanged += this.OnToggleChange;

        }

        //Our functon that will be called once the reference of the grid value chances.
        void OnToggleChange()
        {
            //We set our accessor of the grid value.
            //Which enables or disables the grid object according to toggle value.
            GridView = ToggleGridReference.Value;
        }

        // Update is called once per frame
        void Update()
        {

            //Update the position of the vehicle.
            //Only set the x and Z values, becasue the height is set by the shaft.
            Vehicle.transform.localPosition = new Vector3(offsetPosition.x, 0.0f, offsetPosition.z);
            Shaft.transform.localPosition = new Vector3(0.0f, offsetPosition.y, 0.0f);

            //Set the rotation of the shaft.
            //Rotate around the up angle. 
            Shaft.transform.localEulerAngles = new Vector3(0.0f, -offsetRotation, 0.0f);
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
            //Create a local varable to access the offset as we wish. 
            Vector3 offset = offsetPosition;

            offset.x += strafe * speed;
            offset.z += forward * speed;

            //Negate the amount added if the vehicle position if we are greater than our max bounds.
            if (_outOfBounds())
            {
                offset.x -= strafe * speed;
                offset.z -= forward * speed;
            }

            //Assign back the offset.
            offsetPosition = offset;

            _calculateNormalizedPosition();

        }

        ////Incomming with normalized position.
        //public void UpdatePosition(Vector3 pos)
        //{
        //    //do stuff here.
        //    NormalizedPosition = pos;

        //}

        //The action function of relesing the ball.
        public void BallRelease()
        {
            //Just activate the physics and let her go!
            WreckingBall.isKinematic = false;
            Handle.isKinematic = false;
        }

        private void OnDestroy()
        {
            //Reset the values back to 0.
            //We do this to reset back during run time.
            offsetRotation = 0;
            offsetPosition = Vector3.zero;

            //Subtract ourselfs from the callbacks!
            ToggleGridReference.ValueChanged -= this.OnToggleChange;

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


        public bool GridView
        {
            get
            {
                if (BoundaryField.gameObject == null)
                {
                    Debug.LogError("Trying to access Boundary Grid Game object: " + this.name);
                    return false;
                }

                return BoundaryField.gameObject.activeSelf;
            }

            set
            {
                if (BoundaryField.gameObject == null)
                {
                    Debug.LogError("Trying to access Boundary Grid Game object: " + this.name);
                }

                BoundaryField.gameObject.SetActive(value);

            }
        }

    }
}
