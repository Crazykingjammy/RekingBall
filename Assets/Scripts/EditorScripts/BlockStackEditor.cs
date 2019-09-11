using UnityEngine;
using UnityEditor;

using UnityEditorInternal;
using RekingBall.GameObjects.Managers;

namespace RekingBall.GameObjects.EditorScripts
{
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


            //Draw the name of the block stack.
            //No need, but just learnign the editor calls.
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Name: " + blocks.stringValue);
            EditorGUILayout.Space();

            //Call draw default inspecto so we can link our scriptable object.
            EditorGUILayout.Space();
            DrawDefaultInspector();
            EditorGUILayout.Space();


            //Display the data name, and the data Title. 
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Data Object Name: ", blockdata.name);
            EditorGUILayout.LabelField("Data Object Title: ", blockdata.title);
            EditorGUILayout.Space();

            //Draw out the spawn points data first.
            foreach (Vector3 point in blockdata.SpawnPoints)
            {
                EditorGUILayout.Vector3Field("Spawn Point: ", point);
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            //Crete a button to transfer the data.
            if (GUILayout.Button("Serialize"))
            {
                GrabBlockData();
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            //Display the positon data for the child objects in the stack.
            for (int i = 0; i < allTheBoxes.Length; i++)
            {
                EditorGUILayout.Vector3Field("Box Position: ", allTheBoxes[i].position);
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            //Not sure if this line is needed, keeping it here for now.
            serializedObject.ApplyModifiedProperties();

        }

        void GrabBlockData()
        {
            //Lets start by clearing out the list in the block data.
            blockdata.SpawnPoints.Clear();

            //Go through all the list and add the spawn points.
            for (int i = 0; i < allTheBoxes.Length; i++)
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
}
