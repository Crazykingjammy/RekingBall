using UnityEngine;
using System.Collections.Generic;
using RekingBall.GameObjects;

namespace RekingBall.Scriptables
{

    [CreateAssetMenu(fileName = "Data", menuName = "RekingBall/BlockType", order = 2)]
    public class BlockType : ScriptableObject
    {
        //Reference to the prefab that is this type.
        //Can be more generic gameobject prefab i suppose.
        //Perhaps later this can be expanded.
        [SerializeField] Block Prefab;

        //Seralize just to get out of creating new?
        //Seralize for records anyway?
        [SerializeField] List<Block> ItemPool;
        [SerializeField] List<Block> TotalPool;

        //Accessor to the prefab.
        public Block Template => Prefab;


        public Block RequestType()
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
                //b.transform.localPosition = offset;
               // b.gameObject.SetActive(true);

                //Then we return.
                return b;
            }

            //If we dont have an item in the pool.
            //Create a block and and send it off.
            b = Instantiate<Block>(Template);

            //Set the local position.
            //b.transform.localPosition = offset;
            

            //As we create a new box, lets keep track of it in the total pool.
            TotalPool.Add(b);


            //here is when we can add to our local lists.
            //And register to our local callback.


            return b;
        }

        //We want a callback whenever our type resets.
        public void OnTypeReset(Block b)
        {
            //Should already be deactivated at this point.
            ItemPool.Add(b);
        }

        //CLEANUP
        private void OnDestroy()
        {
            ItemPool.Clear();
            TotalPool.Clear();
        }
        private void OnEnable()
        {
            ItemPool.Clear();
            TotalPool.Clear();
        }
    }

}
