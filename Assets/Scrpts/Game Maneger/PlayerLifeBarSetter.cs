using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeBarSetter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image[] playerLife;
    private int health;
    // private float playerMa

    private void FixedUpdate()
    {

        health = GameManager.playerLifeCount;
        for (int i = 0; i < playerLife.Length; i++)
        {

            if (i < health)
            {

                playerLife[i].enabled = true;

            }

            else
            {

                playerLife[i].enabled = false;

            }


        }
    }




}
