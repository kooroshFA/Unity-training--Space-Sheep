using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideMoves : MonoBehaviour
{
    BarrierController barrierController;
    Vector3 goTo;

    void Start()
    {
        barrierController = gameObject.GetComponent<BarrierController>();
        goTo = transform.position;
    }

    void Update()
    {
        if (Random.Range(1, 30) == 7)
            goTo = new Vector3(Random.Range(-barrierController.horizontalBound, barrierController.horizontalBound)
                              ,transform.position.y
                              ,1);
        
        transform.position = Vector3.Lerp(transform.position
                                          ,goTo
                                          ,Time.smoothDeltaTime);
    }
}
