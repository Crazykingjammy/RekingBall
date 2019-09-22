using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameKernal.System
{
    //Loads and unloads the apps.
    public class AppLoader : MonoBehaviour
    {

        [SerializeField] List<AppHandler> appHandlers;



        public void LOAD_APPLICATION(int index)
        {
            //maybe we check here if the index is valid.
            if (index > appHandlers.Count)
                Debug.LogError("Application Out Of Range! :: " + index);

            //Create the reking ball app.
            Instantiate(appHandlers[index], this.transform);
        }

    }

}
