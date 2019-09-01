using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BlockStack))]
public class BlockStackEditor : Editor
{
    //The data itself.
    private SerializedProperty blocks, dataRef;

    //Data access.
    private BlockStack myInstance;
    private BlockStackData blockdata;

    Rigidbody[] allTheBoxes;

    // Start is called before the first frame update
    private void OnEnable()
    {
        //Find our properities.
         blocks = serializedObject.FindProperty("Name");
        dataRef = serializedObject.FindProperty("data");

        ////Cast the target object into my instance?
        myInstance = (BlockStack)target;

        blockdata = myInstance.data;

        ////Go through the instance and grab the childrne?
        allTheBoxes = myInstance.GetComponentsInChildren<Rigidbody>();

    }

    //Inspector GUI function.
    public override void OnInspectorGUI()
    {


        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Name: " + blocks.stringValue  ) ;
        EditorGUILayout.Space();

        DrawDefaultInspector();


        // blockstack.Update();
        //serializedObject.Update();
    

        EditorGUILayout.LabelField("Data Object Name: ", blockdata.name);
        EditorGUILayout.LabelField("Data Object Title: ", blockdata.title);

        //for (int i = 0; i < blockdata.SpawnPoints.Length; i++)
        //{
        //    EditorGUILayout.Vector3Field("Spawn Point: ", blockdata.SpawnPoints[i]);

        //}

        foreach(Vector3 point in blockdata.SpawnPoints)
        {
            EditorGUILayout.Vector3Field("Spawn Point: ", point);
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (GUILayout.Button("Create Spwawner"))
        {
            GrabBlockData();
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        for(int i = 0; i < allTheBoxes.Length; i++)
        {
            EditorGUILayout.Vector3Field("Box Position: ", allTheBoxes[i].position);
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        //sblockserializedObject.ApplyModifiedProperties();
    }

    void GrabBlockData()
    {
        //Lets start by clearing out the list in the block data.
        blockdata.SpawnPoints.Clear();

        //Go through all the list and add the spawn points.
        for(int i = 0; i < allTheBoxes.Length; i++)
        {
            blockdata.SpawnPoints.Add(allTheBoxes[i].position);
        }

        //And thats it.
        
    }

    private void OnDisable()
    {
        //if()
    }
}
