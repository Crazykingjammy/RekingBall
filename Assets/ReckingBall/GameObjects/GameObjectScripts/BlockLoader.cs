using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptables.References;
using RekingBall.Scriptables;

namespace RekingBall.GameObjects.Managers
{
    public class BlockLoader : MonoBehaviour
    {
        [SerializeField]
        StackLibrary Library;

        [SerializeField]
        IntReference SelectedLevel;

        //The only refernece the block loader needs, is the game directory. right? needs somewhere to look.
        [SerializeField] LibraryDirectory loaderDirectory;


        //Quick accessor for selected blockstack. 
       // BlockStackData data => Library.CurrentStack;// .GetAtIndexAtSelectedLibrary(SelectedLevel);
        BlockStackData data => loaderDirectory.SelectedStackInSelectedLibrary;


        [SerializeField]
        Block Reference;


        List<GameObject> TotalPool;


        // Start is called before the first frame update
        void Start()
        {
            //Instantuate the list.
            TotalPool = new List<GameObject>();

        }

        
        public void SpawnFromDataSet()
        {
            foreach(BlockStackData.TypeData blockinfo in data.TypeInfo)
            {
                //SpawnBlockAtPosition(blockinfo.type, blockinfo.SpawnPoint);
                SpawnBlock(blockinfo);

            }


        }

        public void ClearStack()
        {
            foreach (GameObject child in TotalPool)
            {
                child.SetActive(false);
            }

            //Clear the list once we clear the stack.
            TotalPool.Clear();
        }

        void SpawnBlock(BlockStackData.TypeData block)
        {
            //Create an instance.
            Block b = null;


            b = block.type.RequestType();

            //Set the transform and the parent.
            b.transform.SetParent(this.transform);
            b.transform.localPosition = block.SpawnPoint;

            //Setting rotation and scale.
            b.transform.localScale = block.SpawnSize;
            b.transform.localRotation = block.SpawnRotation;

            //Activate.
            b.gameObject.SetActive(true);

            //Add to the total pool.
            TotalPool.Add(b.gameObject);
        }

        
    }

}
