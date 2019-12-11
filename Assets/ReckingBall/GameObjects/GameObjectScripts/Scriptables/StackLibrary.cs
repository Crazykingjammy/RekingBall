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
        [SerializeField] List<BlockStackData> StackList;

    

        public BlockStackData GetObjectAtIndex(int index = -1)
        {
            //Probally do some boundary checking.
            if (index < 0)
                index = 0;

            return StackList[index];
        }


        //Accessors for utilities and such.

        //Grab access to the count of the selcted library.
        public int LibrarySize => StackList.Count;


        public List<BlockStackData> ObjectList=> StackList;


    }

}
        