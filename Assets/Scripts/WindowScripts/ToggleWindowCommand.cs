using System;
using UnityEngine;
using Scriptables.Variables;
using Scriptables.GameEvents;

public class ToggleWindowCommand : MonoBehaviour
{
    //handle of the window to toggle.
    [SerializeField] IntVariable WindowHandle;

    //The event to open and close
    [SerializeField] IntGameEvent OpenWindowEvent;

    //The event to open and close // to be used if there is a toggle.
    //[Serializable] IntGameEvent CloseWindowEvent;

    //Callback function.
    public void OpenWindow()
    {
        //Raise the open window event at the value of hte handle window.
        OpenWindowEvent.Raise(WindowHandle.Value);
    }


}
