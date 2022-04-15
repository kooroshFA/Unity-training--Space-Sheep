using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private BarrierController Barrier;
    [SerializeField] private BarrierController Food;
    [SerializeField] private BarrierController Wolf;

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
        rand = Random.Range(1, 30);
        Debug.Log(rand);
        if (rand < 11)
            Spawn(Food);
        else if (rand < 26)
            Spawn(Barrier);
        else
            Spawn(Wolf);
    }


    void Spawn(BarrierController gameObject)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-Barrier.horizontalBound, Barrier.horizontalBound), Barrier.verticalBound + 2, 0);
        Instantiate(gameObject, spawnPos, Quaternion.identity);
    }

}
