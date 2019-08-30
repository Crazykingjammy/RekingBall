using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an abstract class that will serve as a base communication between the window class and its script logic. 
public class WindowScriptBase : MonoBehaviour
{

    //List of virutal funcitons for scripts to override and apply logic for.
    virtual public void OnInit() { }
}
