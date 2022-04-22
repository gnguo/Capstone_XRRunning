using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public enum Coin_Type { GOID, SILVER, BLONZE };
    public Coin_Type coinType;

    MoveCoins coinMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        coinMoveScript = gameObject.GetComponent<MoveCoins>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin_Detector")
        {
            coinMoveScript.enabled = true;
        }
    }
}
