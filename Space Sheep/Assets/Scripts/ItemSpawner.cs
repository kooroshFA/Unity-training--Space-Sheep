using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private BarrierController Barrier;
    [SerializeField] private BarrierController Food;

    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("SpawnTime");
        Barrier.GetScreenBounds(Barrier.GetComponent<SpriteRenderer>());
        InvokeRepeating("SpawnTime", 0.1f, Random.Range(2f, 3f));
    }

    void SpawnTime()
    {
        rand = Random.Range(1, 11);
        if (rand > 6)
            Spawn(Food);
        else
            Spawn(Barrier);
    }


    void Spawn(BarrierController gameObject)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-Barrier.horizontalBound, Barrier.horizontalBound), Barrier.verticalBound + 2, 0);
        Instantiate(gameObject, spawnPos, Quaternion.identity);
    }

}
