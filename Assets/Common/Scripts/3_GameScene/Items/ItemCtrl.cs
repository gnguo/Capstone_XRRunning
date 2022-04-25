using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public enum eItem { Heart, PowerUp, Magnet };
    public eItem itemType; 
    public int value;

    public int nIndex;

    public bool bUse;

    public short nType;

    public Item_Collection itemCollection;

    public CapsuleCollider capsuleCol;

    private void Awake()
    {
        //Magnet magnetItem = GetComponent<Magnet>();
    }
    private void Start()
    {
        EnableItem();

        //coinDetectorObj = GameObject.FindGameObjectWithTag("Coin_Detector");
        itemCollection.coinDetectorObj.SetActive(false);
    }

    public void EnableItem()
    {
        if (!bUse)
        {
            bUse = true;
            gameObject.SetActive(true);
        }
    }


    public void DisableItem()
    {
        GameObject Particle = GameInstance.I.CreatePrefab("DESTORY_EFFECT", 0, transform.position, Vector3.one * 4f, Quaternion.identity);
        Destroy(Particle, 3f);
        SoundManager.Play(E_SOUNLIST.E_EATCELL_1);

        bUse = false;
        nType = -1;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (capsuleCol)
        {
            if (!itemCollection.player.PlayerDie)
            {
                switch (itemType)
                {
                    case eItem.Heart:
                        itemCollection.FullHealth();
                        DisableItem();
                        break;
                    case eItem.PowerUp:
                        itemCollection.PowerUp();
                        DisableItem();
                        break;
                    case eItem.Magnet:
                        itemCollection.ActivateCoin();
                        Debug.Log("ihihihihihihiihihihhihi");
                        DisableItem();
                        break;
                }

            }
        }
        else
            return;
    }

}
