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
            [SerializeField] public Vector3 SpawnPoint;
            [SerializeField] public Quaternion SpawnRotation;
            [SerializeField] public Vector3 SpawnSize;
            [SerializeField] public BlockType type;
      
        }

        [SerializeField]
        public string title = "[Enter Block Stack Title]";

    
        [SerializeField] public List<TypeData> TypeInfo;

      


    }
}
