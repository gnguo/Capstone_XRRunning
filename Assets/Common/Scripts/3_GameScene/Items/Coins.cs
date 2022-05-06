using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public enum Coin_Type { GOID, SILVER, BLONZE };
    public Coin_Type coinType;

    public float moveSpeed = 10;
    public GameObject player;
    public GameInstance gameInstance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();


    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        SoundManager.Play(E_SOUNLIST.E_EATCELL_1);

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
                    gameInstance.coinScore += 3;

                    break;

                case Coin_Type.SILVER:
                    gameInstance.coinScore += 2;

                    break;

                case Coin_Type.BLONZE:
                    gameInstance.coinScore++;
                    this.gameObject.SetActive(false);

                    break;
            }
        }
    }

    void MoveCoins()
    {
        transform.position = Vector3.MoveTowards(player.transform.position, player.transform.position,
        moveSpeed * Time.deltaTime);
        Debug.Log("MoveCoins");

    }
}
