using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameKernal.System
{


   //This is an abstract class that will serve as a base communication between the window class and its script logic. 
    public class WindowScriptBase : MonoBehaviour
    {
        //we will just pass in the system ahndler for now. Should be a static global.
        //  [SerializeField]
        protected SystemsHandler _handler_;

        //List of virutal funcitons for scripts to override and apply logic for.
        virtual public void OnInit()
        {
            //Grab a handler from the scene. if there is one.
            _handler_ = FindObjectOfType<SystemsHandler>();
        }
        virtual public void OnExit() { }

        protected SystemsHandler _handler
        {
            get
            {
                if (_handler_)
                    return _handler_;

                _handler_ = FindObjectOfType<SystemsHandler>();

                return _handler_;

            }
        }

    }

}
