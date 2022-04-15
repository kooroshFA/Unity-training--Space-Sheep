using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : SceneController
{
    public float downSpeed;

    void Start()
    {
        //downSpeed = 1;
        if(verticalBound == 0)
            GetScreenBounds(this.GetComponent<SpriteRenderer>());
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * downSpeed);

        if (transform.position.y < - verticalBound -1.5)
            Destroy(gameObject);

        //Debug.Log("Barrier: /n Screen: " + horizontalBound + "," + verticalBound + "/n Height" +playerHalfHeight);
    }

}
