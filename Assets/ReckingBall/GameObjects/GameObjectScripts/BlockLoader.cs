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

        //Quick accessor for selected blockstack. 
        BlockStackData data => Library.CurrentStack;// .GetAtIndexAtSelectedLibrary(SelectedLevel);

        [SerializeField]
        Block Reference;

        List<Block> ItemPool;
        List<GameObject> TotalPool;


        // Start is called before the first frame update
        void Start()
        {
            //Instantuate the lsit.
            ItemPool = new List<Block>();
            TotalPool = new List<GameObject>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SpawnFromDataSet()
        {
            //Go through all of the spawn points.
            //foreach (Vector3 position in data.SpawnPoints)
            //{
            //    SpawnBlockAtPosition(position);
            //}

           // data.so

            foreach(BlockStackData.TypeData blockinfo in data.TypeInfo)
            {
                //SpawnBlockAtPosition(blockinfo.type, blockinfo.SpawnPoint);
                SpawnBlock(blockinfo);

            }


        }

        public void ClearStack()
        {
            //foreach(Block child in GetComponentsInChildren<Block>()  )
            //{
            //    child.gameObject.SetActive(false);
            //}

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

        void SpawnBlockAtPosition(BlockType type, Vector3 pos)
        {
            Block b = null;

            b = type.RequestType();

            //Set the transform and the parent.
            b.transform.SetParent(this.transform);
            b.transform.localPosition = pos;

            //Activate.
            b.gameObject.SetActive(true);

            //Add to the total pool.
            TotalPool.Add(b.gameObject);

        }

        void SpawnBlockAtPosition(Vector3 position)
        {
            Block b = null;

            //Check if we have an item in the pool.
            if (ItemPool.Count > 0)
            {
                //Then we just grab the most recent and activate and set value.
                b = ItemPool[0];

                //Remote from the list of pool.
                ItemPool.RemoveAt(0);

                //Set the block position. and values.
                b.transform.localPosition = position;
                b.gameObject.SetActive(true);

                //Then we return.
                return;
            }

            //If we dont have an item in the pool.
            //Create a block and and send it off.
            b = Instantiate<Block>(Reference, this.transform);

            //Set the local position.
            b.transform.localPosition = position;
            b.SetParentLoader(this);

            //As we create a new box, lets keep track of it in the total pool.
            TotalPool.Add(b.gameObject);

            data.title = "A New Level an be Saved!";

        }



        public void ReturnToPool(Block b)
        {
            //Should already be deactivated at this point.
            ItemPool.Add(b);

            //Function already called its own reset.
        }
    }

}
