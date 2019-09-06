using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    int Health, Points;

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


    private void OnDisable()
    {
        //Reset Logic ?
        _selfBody.Sleep();

        //Reset the transform.
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;


        //Tell my parent that i have been disabled, so they can recycle me.
        myParent.ReturnToPool(this);
    }

    Rigidbody _selfBody 
    {
        get
        {
            if(!mybody)
            {
                mybody = this.GetComponent<Rigidbody>();
            }

            return mybody;
        }
    }
}
