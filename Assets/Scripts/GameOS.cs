using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOS : MonoBehaviour
{
    //All of our open game objects that we have access to here.
    [SerializeField]
    Crane crane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This is hte main function that the player calls when they are ready to start the game.
    public void GAME_Simulate()
    {
        //We relese the recking ball here.
        crane.BallRelease();
    }
}
