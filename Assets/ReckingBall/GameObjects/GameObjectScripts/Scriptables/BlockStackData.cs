using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RekingBall.Scriptables
{
    [CreateAssetMenu(fileName = "Data", menuName = "RekingBall/BlockStack", order = 1)]
    public class BlockStackData : ScriptableObject
    {
        [SerializeField]
        public string title = "[Enter Block Stack Title]";

        [SerializeField]
        public List<Vector3> SpawnPoints;




    }
}
