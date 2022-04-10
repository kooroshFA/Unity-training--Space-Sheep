using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : PlayerController
{
    public float downSpeed;

    override protected void Start()
    {
        base.Start();
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * downSpeed);
        //Debug.Log(horizontalBound + "," + verticalBound);
        if (transform.position.y < - verticalBound -5)
            Destroy(gameObject);
    }

}
