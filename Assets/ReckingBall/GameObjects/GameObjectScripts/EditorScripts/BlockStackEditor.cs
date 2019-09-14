using RekingBall.GameObjects.Managers;
using RekingBall.Scriptables;

using UnityEditorInternal;
using UnityEditor;
using UnityEngine;
using RekingBall.GameObjects;

namespace RekingBall.GameObjects.EditorScripts
{
    [CustomEditor(typeof(BlockStack))]
    public class BlockStackEditor : Editor
    {
        //The data itself.
        private SerializedProperty blocks;

        //Data access.
        private BlockStack myInstance;
        private BlockStackData blockdata;

        Rigidbody[] allTheBoxes;
        Block[] allTheBlocks;

        public BlockStackEditor()
        {
        }

        // Start is called before the first frame update
        private void OnEnable()
        {
            //Find our properities.
            blocks = serializedObject.FindProperty("Name");
            // dataRef = serializedObject.FindProperty("data");

            ////Cast the target object into my instance?
            myInstance = (BlockStack)target;

            blockdata = myInstance.data;

            ////Go through the instance and grab the childrne?
            allTheBoxes = myInstance.GetComponentsInChildren<Rigidbody>();

            allTheBlocks = myInstance.GetComponentsInChildren<Block>();

        }

        //Inspector GUI function.
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

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
            //foreach (Vector3 point in blockdata.SpawnPoints)
            //{
            //    EditorGUILayout.Vector3Field("Spawn Point: ", point);
            //}

            foreach(BlockStackData.TypeData blocktype in blockdata.TypeInfo)
            {               
                EditorGUILayout.LabelField(blocktype.type.name);
                EditorGUILayout.Vector3Field("Position: ",blocktype.SpawnPoint);
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

                if(allTheBlocks[i] != null)
                    EditorGUILayout.LabelField(allTheBlocks[i].Type.name);


            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            //Not sure if this line is needed, keeping it here for now.
            serializedObject.ApplyModifiedProperties();

        }

        void GrabBlockData()
        {
            //Lets start by clearing out the list in the block data.
            //blockdata.SpawnPoints.Clear();
            blockdata.TypeInfo.Clear();

            //Go through all the list and add the spawn points.
            for (int i = 0; i < allTheBoxes.Length; i++)
            {      
               //Grab the type data.
                BlockStackData.TypeData type = new BlockStackData.TypeData();

                //Set teh parameters.
                //Grabbing the transform data from the boxes.
                //i think local data(scale and rotaiton) would work.
                type.SpawnPoint = allTheBoxes[i].position;
                type.SpawnSize = allTheBoxes[i].transform.localScale;
                type.SpawnRotation = allTheBoxes[i].transform.localRotation;

                if (allTheBlocks[i] != null)
                    type.type = allTheBlocks[i].Type;

                blockdata.TypeInfo.Add(type);
            }



            //And thats it.

        }


    }
}