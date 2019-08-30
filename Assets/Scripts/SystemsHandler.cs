using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsHandler : MonoBehaviour
{
    //Reference for the color of all the windows.
    [SerializeField]
    Color WindowColor; 

    //The list of our windows for access. 
    [SerializeField]
    WindowObject[] Windows;
 
    // Start is called before the first frame update
    void Start()
    {
        //On start, go ahead and loop around and call all the windows awake functions.
        foreach (WindowObject window in Windows)
        {
            window.Init();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleWindow(int index)
    {
        //Call Close Window Function.
        Windows[index].CloseWindow();
    }

    public void ActivateWindow(int index)
    {
        //Check if the index is valid before we make our call.
        if (Windows[index] == null)
        {
            //No valid window available at index.
            //Hook for message to send.

            return;
        }

        //Call Activate Window Function.
        Windows[index].ActivateWindow();
    }


    /// Utility Functions
    /// Here we can place all our utility functions for system wide operations.
    /// Functions such as Update System Window Color
    /// Other optiosn such as languages should apply here..
    ///
    public void ApplySystemColor(Color color)
    {
        //First we actually set the system color.
        WindowColor = color;

        //Then we go through the list of winodows and apply their color.
        foreach (WindowObject window in Windows)
        {
            window.ApplyWindowColor(WindowColor);
        }

    }


    ///Accessors
    ///We will just have a nice neat little pile of accessor funcitons so we can keep control of when things are called.
    ///Will see how far this goes. if you are reading this, hello from the ground stages of this project. lol
    ///

    public Color SystemWindowColor
    {
        //Just return direct window color that was passed in.
        get{ return WindowColor; }
    }

    
}
