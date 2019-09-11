using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "RekingBall/BlockStack Library", order = 2)]
public class StackLibrary : ScriptableObject
{
    //A list to store the library.
    //Should be dynamic to load from files so we keep it as a list and not array.
    //Although we can make a static array every time we load a library list, but lets jsut say list is fast enough.
    [SerializeField] List<BlockStackData> Library;


    public BlockStackData GetAtIndex(int index = 0)
    {
        //Probally do some boundary checking.

        return Library[index];
    }
}
        