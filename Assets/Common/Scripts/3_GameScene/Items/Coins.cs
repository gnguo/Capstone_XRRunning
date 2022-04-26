using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public enum Coin_Type { GOID, SILVER, BLONZE };
    public Coin_Type coinType;

    public float moveSpeed = 30;
    public PlayerCtrl player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>();

    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin_Detector")
        {
            //coinMoveScript.enabled = true;
            MoveCoins();
        }

        if (other.gameObject.tag == "Player_Bubble")
        {
            //Add count or give points etc etc.
            switch (coinType)
            {
                case Coin_Type.GOID:
                    player.coinScore += 3;

                    break;

                case Coin_Type.SILVER:
                    player.coinScore += 2;

                    break;

                case Coin_Type.BLONZE:
                    player.coinScore++;
                    this.gameObject.SetActive(false);
                    //Debug.Log(this);

                    break;

            }
        }

    }

    void MoveCoins()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
        moveSpeed * Time.deltaTime);

    }
}
