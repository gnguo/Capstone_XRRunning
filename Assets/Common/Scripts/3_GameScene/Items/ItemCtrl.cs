using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{

    private Item_Collection itemCollection;

    public List<ItemCtrl> Items;

    public enum eItem { Heart, PowerUp, Magnet };
    public eItem itemType;

    public int nIndex;

    public bool bUse;

    void Awake()
    {
        itemCollection = GameObject.Find("GameScene").GetComponent<Item_Collection>();
    }

    private void Start()
    {

        //coinDetectorObj = GameObject.FindGameObjectWithTag("Coin_Detector");
    }

    public void FullHealth()
    {
        if (itemCollection.player.curHp < itemCollection.player.maxHp)
        {
            itemCollection.player.curHp = 100;
        }
    }


    public void EnableItem()
    {
        gameObject.SetActive(true);
    }


    public void DisableItem()
    {
        SoundManager.Play(E_SOUNLIST.E_EATCELL_1);

        gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_Bubble"))
        {

            if (!itemCollection.player.PlayerDie)
            {
                switch (itemType)
                {
                    case eItem.Heart:
                        FullHealth();
                        DisableItem();
                        break;

                    case eItem.PowerUp:
                        itemCollection.PowerUp();
                        DisableItem();
                        break;

                    case eItem.Magnet:
                        itemCollection.ActivateCoin();
                        DisableItem();
                        break;
                }
            }
        }
        else
            return;
    }

}
