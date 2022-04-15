using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image firstLife;
    [SerializeField] private Image secondLife;
    [SerializeField] private Text loose;

    // Start is called before the first frame update
    void Start()
    {
        player.EatingFood += EatingFood;
        player.Accident += Accident;
    }

    private void Accident()
    {
        switch(player.lives)
        {
            case 0:
                firstLife.gameObject.SetActive(false);
                secondLife.gameObject.SetActive(false);
                loose.gameObject.SetActive(true);
                break;
            case 1:
                firstLife.gameObject.SetActive(true);
                secondLife.gameObject.SetActive(false);
                break;
            case 2:
                firstLife.gameObject.SetActive(true);
                secondLife.gameObject.SetActive(true);
                break;
        }
    }

    private void EatingFood(bool lifeISFull )
    {
        if (lifeISFull)
            scoreText.text = player.score.ToString();
        else
            secondLife.gameObject.SetActive(true);
    }

}
