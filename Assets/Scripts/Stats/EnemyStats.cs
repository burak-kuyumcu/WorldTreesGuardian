using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{

    public override void Start()
    {
        base.Start();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        Destroy(gameObject, 2);
    }
}
