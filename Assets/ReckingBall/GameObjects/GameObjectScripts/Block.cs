using RekingBall.GameObjects.Managers;
using RekingBall.Scriptables;

using UnityEngine;

namespace RekingBall.GameObjects
{
    public class Block : MonoBehaviour
    {
        [SerializeField]
        int Health, Points;

        [SerializeField] BlockType type;


        //Here we will store a refernce to the block pool.
        //this should be eventually phased out and replaced with an delegate.
        //Sooner than eventually.
        BlockLoader myParent;

        Rigidbody mybody;

        // Start is called before the first frame update
        void Start()
        {
            //Grab a reference of the rigid body for resetting.
            //mybody = this.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetParentLoader(BlockLoader parent)
        {
            myParent = parent;

        }

        public BlockType Type => type;

        private void OnDisable()
        {
            //Reset Logic ?
            _selfBody.Sleep();

            //Reset the transform.
            this.transform.position = Vector3.zero;
            this.transform.rotation = Quaternion.identity;


            ///Call the type reset, which adds to the pool of disabled types.
            type.OnTypeReset(this);
        }

  

        public Rigidbody _selfBody
        {
            get
            {
                if (!mybody)
                {
                    mybody = this.GetComponent<Rigidbody>();
                }

                return mybody;
            }
        }
    }

}
