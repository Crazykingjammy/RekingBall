using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// TODO:: make this generic.
/// </summary>
namespace RekingBall.Scriptables
{
    [CreateAssetMenu(fileName = "Data", menuName = "RekingBall/BlockStack", order = 1)]
    public class BlockStackData : ScriptableObject
    {
        [System.Serializable]
        public class TypeData
        {
            //All the data that we want to store, pos, rot, size, and type.
            [SerializeField] public Vector3 SpawnPoint;
            [SerializeField] public Quaternion SpawnRotation;
            [SerializeField] public Vector3 SpawnSize;
            [SerializeField] public BlockType type;
      
        }

        //Give the library a title shall we, here we have the defaul string.
        [SerializeField]
        public string title = "[Enter Block Stack Title]";
        

        //Here we have the actual field decleared of the type data to store all the block info we need.
        [SerializeField] public List<TypeData> TypeInfo;

      


    }
}
