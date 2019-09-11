using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameKernal.System
{
    public class AppHandler : WindowScriptBase
    {
        //Refference for the applications scene.
        public string myScene;

        //Application windows list.
        WindowObject[] _AppWindows;

        // Start is called before the first frame update
        void Start()
        {
            //Call our base init, which will give us references.
            base.OnInit();

            //When the app starts, go through and grab all the windows in children.
            _AppWindows = GetComponentsInChildren<WindowObject>(true);

            //Iterate through and call init.
            foreach (WindowObject window in _AppWindows)
            {
                //Add it to the systems handler.
                _handler.RegisterWindow(window);
            }

            //Load the games scene.
            SceneManager.LoadSceneAsync(myScene, LoadSceneMode.Additive);


        }



        //Accessors.


        // Update is called once per frame
        void Update()
        {

        }

    }
}
