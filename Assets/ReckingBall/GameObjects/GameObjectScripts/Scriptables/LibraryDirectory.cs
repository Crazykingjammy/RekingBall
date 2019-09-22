using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scriptables.References;

namespace RekingBall.Scriptables
{
    [CreateAssetMenu(fileName = "Data", menuName = "RekingBall/Library Directory", order = 3)]
    public class LibraryDirectory : ScriptableObject
    {

        //List of libraries for the catelog.
        [SerializeField] List<StackLibrary> Catelogue;

        //Universal reference for the selcted index. (level)
        [SerializeField] IntReference StackLevelIndex;

        //Universal reference for the selected library in the directory.
        [SerializeField] IntReference LibraryIndex;



        //Accessor to the selected library.
        //This is mainly a overrride function that may not need to be used. 
       public StackLibrary GetStackLibraryAtIndex(int index = -1)
        {
            //Should be okay for boundary checking?
            if (index < 0 || index > Catelogue.Count)
                index = LibraryIndex.Value;

            return Catelogue[index];
        }

        public BlockStackData GetStackInSelectedLibrary(int index = -1)
        {
            if (index < 0 || index > SelectedStackInLibrary.LibrarySize)
                index = StackLevelIndex.Value;

            return SelectedStackInLibrary.Stack[index];
        }

        ///Accessors and stuff that we may need.
        ///

            //to be updated to contain a list of libraries that are unlocked or not.
        public List<StackLibrary> AvailableLibraries => Catelogue;

        //Simple accessor to get current,
        public StackLibrary SelectedStackInLibrary
        {
            get { return GetStackLibraryAtIndex(SelectedLibraryIndex); }
        }

        public BlockStackData SelectedStackInSelectedLibrary
        {
            //get { return SelectedStackInSelectedLibrary.getatin}
            get { return SelectedStackInLibrary.GetAtIndexAtSelectedLibrary(StackLevelIndex.Value); }
        }

        public int SelectedStackIndex
        {
            get { return StackLevelIndex.Value; }
            set
            {
                //Probaly do some logic or function calls here?
                StackLevelIndex.SetValue(value);
            }
        }

        public int SelectedLibraryIndex
        {
            get { return LibraryIndex.Value; }
            set
            {
                //Make sure value is not out of range.
                //if(value > )

                //Probally do some logic or functon calls here.
                LibraryIndex.SetValue(value);
            }

        }

    }

}
