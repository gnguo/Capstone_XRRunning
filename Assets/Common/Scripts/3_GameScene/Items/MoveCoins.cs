using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoins : MonoBehaviour
{
    Coins coinScript;
    public PlayerCtrl player;
    private GameScene gameScene;


    // Start is called before the first frame update
    private void Awake()
    {
        coinScript = gameObject.GetComponent<Coins>();
        player = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

   //private void OnTriggerEnter(Collider other)
   //{
   //    if (other.gameObject.tag == "Player_Bubble")
   //    {
   //        //Add count or give points etc etc.
   //        Destroy(gameObject);
   //        switch(coinScript.coinType)
   //        {
   //            case Coins.Coin_Type.GOID:
   //                player.coinScore += 3;
   //                break;
   //
   //            case Coins.Coin_Type.SILVER:
   //                player.coinScore += 2;
   //
   //                break;
   //
   //            case Coins.Coin_Type.BLONZE:
   //                player.coinScore++;
   //                break;
   //
   //        }
   //    }
   //}
}
