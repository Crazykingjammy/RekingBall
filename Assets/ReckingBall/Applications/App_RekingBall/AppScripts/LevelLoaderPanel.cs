using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameKernal.System;
using RekingBall.Scriptables;



namespace RekingBall.Panels
{
    public class LevelLoaderPanel : WindowScriptBase
    {
        //Open value for the amount we want to cache from the beginning.
        [SerializeField] int fileIconCacheAmount = 20;

        [SerializeField] LibraryDirectory GameLibrary;

        //Field for the files layout grid.
        [SerializeField] GridLayoutGroup FilesLayout;

        //Toggle group for the grid.
        [SerializeField] ToggleGroup FilesLayoutGroup;

        //Dropdown UI to select the library from.
        [SerializeField] Dropdown LibraryDropDownList;

        [SerializeField] Text LevelTitle;

        //Reference to the files prefab.
        //Template Reference for a file.
        [SerializeField] FileIconToggle templateIcon;


        //List of created icons based on teh size of hte library.
        //Ideally we really want to handle this better.
        //Using a pool, perhaps extract this into a more generic system.
        //Ideally cache a pool in the beginning and use for multiple libraries.
        List<FileIconToggle> _iconList;

       
       
        // Update is called once per frame
        void Update()
        {

        }

        //Refresh view on enable.
        private void OnEnable()
        {
            //The false parameterwill indicate to action, or false triggering being made as we zero out the selection.
            FilesLayoutGroup.SetAllTogglesOff();

            //Boom, as it should be, only refresh as we enable or switch the content we are viewing.
            OnRefreshView();
        }

        //Callback for toggle change.
        public void OnFileSelected(int index)
        {
            GameLibrary.ActiveStackIndex = index;
            LevelTitle.text = GameLibrary.ActiveStack.title;
        }

        public void OnLibrarySelected(int index)
        {
            GameLibrary.ActiveLibraryIndex = index;
            Debug.Log("On Dropdown list sleected value! : " + index);

            OnRefreshView();
        }

        public void OnRefreshView()
        {
            //Set the toggle group to values off.
            FilesLayoutGroup.SetAllTogglesOff();

            //Lets go through and get the list of levels in the selected library.
            //And activate icons accordinly.
            for (int i = 0; i < GameLibrary.ActiveLibrary.LibrarySize; i++)
            {
                //Go through and label the files.
                //reference the current icon.
                FileIconToggle file = _iconList[i];

                //Set the label.
                file.Label = GameLibrary.GetObjectStackFromActiveLibraryAtIndex(i).name; //library.GetAtIndexAtSelectedLibrary(i).name;

                //Set the index value of the toggle.
                file.IndexReference = i;

                //Maybe we set the icon, depending on library?

                //Enable the obeject.
                file.gameObject.SetActive(true);
            }


            //Do we test if we ran out of icons in the cache to activate? Maybe somewhere.
        }

        public override void OnInit()
        {
            //Call base init.
            base.OnInit();


            //lets create that cache now.

            //Start by creating the list.
            _iconList = new List<FileIconToggle>();

            //Then we go through and create and disable the amount of icons we going to cache.
            for (int i = 0; i < fileIconCacheAmount; i++)
            {
                //Instanutate from the template here.
                //Setting the parent within the call.
                FileIconToggle file = Instantiate(templateIcon, FilesLayout.transform) as FileIconToggle;

                //push onto the list here.
                _iconList.Add(file);

                //Lets also disable them.
                //No need to set values here as they are set on refresh call.
                file.gameObject.SetActive(false);

                //Let us set the group.
                file.MyToggleGroup = FilesLayoutGroup;

                //Set the highlight color.
                //file.HighlightColor = _handler.SystemWindowColor;

                //And that should be it. List created and obtained. 
            }

            //update the dropdown based on whats in our library.
            List<string> library_list = new List<string>();

            foreach (StackLibrary lib in GameLibrary.AvailableLibraries)
            {
                library_list.Add(lib.name);
            }

            LibraryDropDownList.AddOptions(library_list);
        }


        public override void OnExit()
        {
            base.OnExit();
        }

    }

}
