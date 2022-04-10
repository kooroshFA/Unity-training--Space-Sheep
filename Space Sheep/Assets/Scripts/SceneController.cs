using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    protected float verticalBound;
    protected float horizontalBound;

    protected float playerHalfHeight;
    protected float playerHalfWidth;

    public void GetScreenBounds(SpriteRenderer playerSprite)
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerHalfHeight = playerSprite.bounds.size.y / 2;
        playerHalfWidth = playerSprite.bounds.size.x / 2;
        horizontalBound = screenBounds.x - playerHalfWidth;
        verticalBound = screenBounds.y - playerHalfHeight;
    }
    
}
