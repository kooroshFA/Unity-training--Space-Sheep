using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private BarrierController Barrier;
    [SerializeField] private BarrierController Food;
    [SerializeField] private BarrierController Wolf;
    List<BarrierController> Barriers;
    float waitTime = 3;

    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("SpawnTime");
        Barrier.GetScreenBounds(Barrier.GetComponent<SpriteRenderer>());
        //InvokeRepeating("SpawnTime", 0.1f, Random.Range(2f, 3f));
        #region prepare Barrier List
        Barrier.downSpeed = 1f;
        Food.downSpeed = 1f;
        Wolf.downSpeed = 2f;
        Barriers = new List<BarrierController>();
        Barriers.Add(Barrier);
        Barriers.Add(Food);
        Barriers.Add(Wolf);
        #endregion
        StartCoroutine("SpawnTime");
        StartCoroutine("SpeedUp");
    }

    //void SpawnTime()
    //{
    //    rand = Random.Range(1, 30);
    //    //Debug.Log(rand);
    //    if (rand < 11)
    //        Spawn(Food);
    //    else if (rand < 26)
    //        Spawn(Barrier);
    //    else
    //        Spawn(Wolf);
    //}

    IEnumerator SpawnTime()
    {
        while(true)
        {
            rand = Random.Range(1, 30);
            if (rand < 11)
                Spawn(Food);
            else if (rand < 26)
                Spawn(Barrier);
            else
                Spawn(Wolf);
            yield return new WaitForSeconds(waitTime);
        }

    }

    IEnumerator SpeedUp()
    {
        while (waitTime>1)
        {
            yield return new WaitForSeconds(4f);
            foreach (BarrierController item in Barriers)
                item.downSpeed+=0.2f;
            waitTime -= 0.2f;
            yield return new WaitForSeconds(1f);
            Debug.Log("Up");
        }
    }


    void Spawn(BarrierController gameObject)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-Barrier.horizontalBound, Barrier.horizontalBound), Barrier.verticalBound + 2, 0);
        Instantiate(gameObject, spawnPos, Quaternion.identity);
    }

}
