using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptables.Variables;

public class SystemsHandler : MonoBehaviour
{
    //Reference for the color of all the windows.
    [SerializeField] ColorVariable ThemeColor;

    //Why not have a reference to the UIDRAGGER so we can update the info.
   [SerializeField] UIDRAGGER _uiDraggerReference;

    //The list of our windows for access. 
    [SerializeField]
    List<WindowObject> Windows;



    //Internal functions.
    void CalculateWindowIndexList()
    {
        //Create a counter.
        int index = 0;
        //Go through the list and set the index.
        foreach (WindowObject window in Windows)
        {
            //Set the index that the HandleName is stored in.
            window.HandleIndex = index;

            //iterate the index.
            index++;
        }
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
    public void ApplyThemeColor()
    {
        //Then we go through the list of winodows and apply their color.
        foreach (WindowObject window in Windows)
        {
            window.ApplyWindowColor(SystemWindowColor) ;
        }

        

    }

    public void RegisterWindow(WindowObject window)
    {
        //Why not just call the init here. makes it feel more official.
        window.Init();

        //Add it to the systems list.
        Windows.Add(window);

        //Dont forget to add it to the UIDRAGGPANEL list.
        _uiDraggerReference.UIPanels.Add(window.WindowHandleImage);

        CalculateWindowIndexList();
    }

    ///Accessors
    ///We will just have a nice neat little pile of accessor funcitons so we can keep control of when things are called.
    ///Will see how far this goes. if you are reading this, hello from the ground stages of this project. lol
    ///

    public Color SystemWindowColor
    {
        //Just return direct window color that was passed in.
        get { return ThemeColor.Value; }
  //      set { ThemeColor.SetValue(value);  }
    }

   

}
