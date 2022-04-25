using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public enum Coin_Type { GOID, SILVER, BLONZE };
    public Coin_Type coinType;

    public float moveSpeed = 30;
    public PlayerCtrl player;


    // Start is called before the first frame update
    void Start()
    {
        //coinMoveScript = gameObject.GetComponent<MoveCoins>();
        player = GameObject.Find("Player").GetComponent<PlayerCtrl>();

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin_Detector")
        {
            //coinMoveScript.enabled = true;
            MoveCoins();
            Debug.Log("HIHIIHHHIIHIHh=========");
        }

        if (other.gameObject.tag == "Player")
        {
            //Add count or give points etc etc.
            Destroy(gameObject);
        }
    }

    void MoveCoins()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
        moveSpeed * Time.deltaTime);

    }
}
