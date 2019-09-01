using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BlockStackScriptableObject", order = 1)]
public class BlockStackData : ScriptableObject
{
    [SerializeField]
    public string title = "[Enter Block Stack Title]";

    [SerializeField]
    public List<Vector3> SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
