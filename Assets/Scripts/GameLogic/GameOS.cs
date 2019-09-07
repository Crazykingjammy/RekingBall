using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOS : MonoBehaviour
{
    //All of our open game objects that we have access to here.
    [SerializeField]
    Crane CraneTemplate;

    [SerializeField]
    CameraController gameCam;

    [SerializeField]
    BlockLoader loader;

    //For local cache.
    Crane craneInstance;

   
    // Start is called before the first frame update
    void Start()
    {
        
        //Lets instanuate the crane here.
        craneInstance = Instantiate(CraneTemplate) as Crane;

        //Set ths scene as the active scene.
        SceneManager.SetActiveScene(gameObject.scene);
    }

    // Update is called once per frame
    void Update()
    {
        //Check for controls.
        _checkControls();
    }

    void CreateScene()
    {
        //if(myCrane)
            
    }

    //Internal functions.
    bool _instantiateFromTemplate()
    {
        //check if the template is valid.
        if (!CraneTemplate)
        {
            Debug.LogError("No Crane Template Found: Attempted instantuate a Template that was not found.");
            return false;
        }

        //Lets instanuate the crane here.
        craneInstance = Instantiate(CraneTemplate) as Crane;

        //If we do hav an oject here 
        if (!craneInstance)
            return false;
        else
            return true;
    }

    void _checkControls()
    {
        //For now we return if there is no crane.
        //Below are all crane controls, safe to abord further code if we have no crane.
        if (!craneInstance)
        {
            Debug.LogError("No Crane Found: Attempted controls access without a valid Crane.");
            return;
        }

        //WE will do keyboard controsl test here for now. that basically calls the action funciton.
        if (Input.GetButtonDown("Jump"))
        {
           craneInstance.BallRelease();
        }

        //Call move on the crane instance and pass in the input axis. 
        craneInstance.MoveMe(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }


    //This is hte main function that the player calls when they are ready to start the game.
    public void GAME_Simulate()
    {
        //We relese the recking ball here.
        craneInstance.BallRelease();
    }

    public void GAME_RESETLEVEL()
    {
        //Get rid of the current reference.
        Destroy(craneInstance.gameObject);

        //Reload new reference from template.
        _instantiateFromTemplate();


        //call reset from the loader.
        loader.ClearStack();

        //TODO:Restore position and rotation.
    }

    public void GAME_LOADLEVEL()
    {
        loader.SpawnFromDataSet();
    }


    ///Question, do we place crane accessors here? or do places go to the crane directly? THis makes the code shorder on the accessors side.
    ///hmmm lets see how well this works out.
    ///



    //Here is a wrapper for a wrapper. Not sure if we need this but hey.
    //Can abstract this call later on when it comes to different gameOS scripts.
    public bool Grid
    {
        get
        {
            //We will do a check here.
            if (craneInstance)
                return craneInstance.GridView;

            //Sefault return of false is nothing can be found.
            return false;
        }

        set
        {
            if (craneInstance)
                craneInstance.GridView = value;
    
        }
    }



}
