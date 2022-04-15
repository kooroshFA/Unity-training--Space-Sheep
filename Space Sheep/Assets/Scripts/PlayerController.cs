using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : SceneController
{
    public event Action<bool> EatingFood;
    public event Action Accident;
    

    [SerializeField] private float playerMoveSpeed;
    private Vector2 input;
    private bool verticalMoveOn;
    private Rigidbody2D playerRB;
    public int score;
    public int lives = 2;

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

        if (lives == 0)
            Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            lives--;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Wolf")
            lives = 0;
        if (Accident != null)
            Accident();
        Debug.Log("Lives = "+lives);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            if (lives < 2)
            {
                lives++;
                if (EatingFood != null)
                    EatingFood(false);
            }
            else
            {
                score++;
                if (EatingFood != null)
                    EatingFood(true);
            }
            Destroy(collision.gameObject);

        }
        Debug.Log(score);
    }

}
