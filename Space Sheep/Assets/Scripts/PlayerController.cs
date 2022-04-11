using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SceneController
{
    [SerializeField] private float playerMoveSpeed;
    private Vector2 input;
    private bool verticalMoveOn;
    private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        input = Vector2.zero;
        playerRB = gameObject.GetComponent<Rigidbody2D>();

        GetScreenBounds(this.GetComponent<SpriteRenderer>());
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        //Calculate Velocity due to player input
        input.x = Input.GetAxis("Horizontal") * 2 * playerMoveSpeed;
        if (verticalMoveOn)
            input.y = Input.GetAxis("Vertical") * playerMoveSpeed;
        playerRB.velocity = input;

        //Stay in Bounds
        Vector2 limitPos = new Vector2(Mathf.Clamp(transform.position.x, -1 * horizontalBound, horizontalBound),
                                       Mathf.Clamp(transform.position.y, -1 * verticalBound, verticalBound));
        transform.position = limitPos;

        #endregion

        //Debug.Log("Player: /n Screen: " + horizontalBound + "," + verticalBound + "/n Height" + playerHalfHeight);
    }
}
