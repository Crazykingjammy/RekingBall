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



  
        ///Accessors and stuff that we may need.
        ///

            //to be updated to contain a list of libraries that are unlocked or not.
        public List<StackLibrary> AvailableLibraries => Catelogue;

        //Simple accessor to get current,
        //Library Container.
        public StackLibrary ActiveLibrary
        {
            get { return GetLibraryAtIndex(ActiveLibraryIndex); }
        }

        //Object Container.
        public BlockStackData ActiveStack
        {
            //get { return SelectedStackInSelectedLibrary.getatin}
            get { return ActiveLibrary.GetObjectAtIndex(StackLevelIndex.Value); }
        }


        //Function that returns library at specified index.
        public StackLibrary GetLibraryAtIndex(int index = -1)
        {
            //Should be okay for boundary checking?
            if (index < 0 || index > Catelogue.Count)
                index = LibraryIndex.Value;

            return Catelogue[index];
        }

        //Return ObjectStack at the given index, with the given active library.
        public BlockStackData GetObjectStackFromActiveLibraryAtIndex(int index = -1)
        {
            if (index < 0 || index > ActiveLibrary.LibrarySize)
                index = StackLevelIndex.Value;

            return ActiveLibrary.ObjectList[index];
        }



        public int ActiveStackIndex
        {
            get { return StackLevelIndex.Value; }
            set
            {
                //Probaly do some logic or function calls here?
                StackLevelIndex.SetValue(value);
            }
        }

        public int ActiveLibraryIndex
        {
            get { return LibraryIndex.Value; }
            set
            {              
                //Probally do some logic or functon calls here.
                LibraryIndex.SetValue(value);
            }

        }

    }

}
