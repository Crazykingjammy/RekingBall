using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLoader : MonoBehaviour
{
    [SerializeField]
    BlockStackData data;

    [SerializeField]
    Block Reference;

    List<Block> ItemPool;


    // Start is called before the first frame update
    void Start()
    {
        //Instantuate the lsit.
        ItemPool = new List<Block>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFromDataSet()
    {
        //Go through all of the spawn points.
        foreach(Vector3 position in data.SpawnPoints)
        {
            SpawnBlockAtPosition(position);
        }
    }


    void SpawnBlockAtPosition(Vector3 position)
    {
        Block b = null;

        //Check if we have an item in the pool.
        if(ItemPool.Count > 0)
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

    }



    public void ReturnToPool(Block b)
    {
        //Should already be deactivated at this point.
        ItemPool.Add(b);

        //Function already called its own reset.
    }
}
