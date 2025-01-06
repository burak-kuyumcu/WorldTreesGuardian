using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour
{
    public GameObject[] lootItems;
    public GameObject dummyItem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropItem()
    {
        int chance1 = Random.Range(0, 10);
        int chance2 = Random.Range(0, 20);

        if (chance2 > chance1)
        {
            Instantiate(lootItems[Random.Range(0, lootItems.Length)], transform.position, transform.rotation);
        }
        else
        {
            Instantiate(dummyItem, transform.position, transform.rotation);
        }
    }
}
