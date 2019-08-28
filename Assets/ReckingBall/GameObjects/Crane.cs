using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public Rigidbody WreckingBall; 

    // Start is called before the first frame update
    void Start()
    {
        //Ensure the wrecking ball rigid body is kenetic upon start.
        WreckingBall.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        //WE will do keyboard controsl test here for now. that basically calls the action funciton.
        if(Input.GetButtonDown("Jump"))
        {
            BallRelease();
        }
    }


    //The action function of relesing the ball.
   public void BallRelease()
    {
        WreckingBall.isKinematic = false;
    }


}

