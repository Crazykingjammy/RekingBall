using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptables.References;

namespace RekingBall.Scriptables
{
    


    [CreateAssetMenu(fileName = "Data", menuName = "RekingBall/BlockStack Library", order = 2)]
    public class StackLibrary : ScriptableObject
    {
        //A list to store the library.
        //Should be dynamic to load from files so we keep it as a list and not array.
        //Although we can make a static array every time we load a library list, but lets jsut say list is fast enough.
        [SerializeField] List<BlockStackData> Library;

        //Universal reference for the selected index.
        //Will be used for functions to just reutrn library at hand.
        [SerializeField] IntReference SelectedIndex;

        //This should be an open list
        //The list shoudl fill up from file system.
        //Librar_Extention[i] = new List<BlockStackData> _fromFile;


        public BlockStackData GetAtIndexAtSelectedLibrary(int index = -1)
        {
            //Probally do some boundary checking.
            if (index < 0)
                index = SelectedIndex.Value;

            return Library[index];
        }


        //Accessors for utilities and such.

            //Grab access to the count of the selcted library.
        public int SelectedLibrarySize => Library.Count;

        //Easy setter once there is only one library.
        public List<BlockStackData> SelectedLibrary => Library;

        //Grab the current stack for level loading and such.
        public BlockStackData CurrentStack => Library[SelectedIndex.Value];

        //Grab and set the selected index.
        public int SelectedIndexAtSelectedLibrary
        {
            get { return SelectedIndex.Value; }
            set { SelectedIndex.SetValue(value); }
        }

    }

}
        