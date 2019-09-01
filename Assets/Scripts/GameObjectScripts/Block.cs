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

    // Start is called before the first frame update
    void Start()
    {
        
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

        //Tell my parent that i have been disabled, so they can recycle me.
        myParent.ReturnToPool(this);
    }
}
