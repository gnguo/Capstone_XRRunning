using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{

    public Item_Collection itemCollection;

    public List<ItemCtrl> Items;

    public enum eItem { Heart, PowerUp, Magnet };
    public eItem itemType;

    public int nIndex;

    public bool bUse;

    public short nType;

    public bool bPowerUp;

    public PlayerCtrl player;

    public GameObject coinDetectorObj;
    public GameObject powerUp_Img;

    public PlayerTouchMovement touchmove;
    //public ItemCtrl items;

    public SphereCollider sphereCol;


    void Awake()
    {
        Items = new List<ItemCtrl>();
        EnableItem();

        int nCount = transform.childCount;

        for (int i = 0; i < nCount; i++)
        {
            ItemCtrl Item = transform.GetChild(i).GetComponent<ItemCtrl>();
            Items.Add(Item);
        }
    }

    private void Start()
    {

        //coinDetectorObj = GameObject.FindGameObjectWithTag("Coin_Detector");
        itemCollection.coinDetectorObj.SetActive(false);
    }

    public void FullHealth()
    {
        if (player.curHp < player.maxHp)
        {
            player.curHp = 100;
        }
    }


    // Update is called once per frame
    public void ActivateCoin()
    {
        Debug.Log("함수에들어와여");
        StartCoroutine(ActivateCoinCoroutine());
        // Destroy(transform.GetChild(0).gameObject);
    }

    IEnumerator ActivateCoinCoroutine()
    {
        coinDetectorObj.SetActive(true);
        yield return new WaitForSeconds(6f);
        coinDetectorObj.SetActive(false);
    }

    //public void PowerUp()
    //{
    //    StartCoroutine(PowerUpCoroution());
    //}
    //
    //IEnumerator PowerUpCoroution()
    //{
    //    touchmove.moveSpeed = 60f;
    //    bPowerUp = true;
    //    powerUp_Img.SetActive(true);
    //    player.capsuleCol.enabled = false;
    //    Debug.Log(player.gameObject.layer);
    //
    //    yield return new WaitForSeconds(3f);
    //
    //    player.capsuleCol.enabled = true;
    //    powerUp_Img.SetActive(false);
    //
    //
    //    bPowerUp = false;
    //    touchmove.moveSpeed = 30f;
    //    Debug.Log("ihihihihihihiihihihhihi");
    //
    //}

    public void EnableItem()
    {
        gameObject.SetActive(true);
    }


    public void DisableItem()
    {
        GameObject Particle = GameInstance.I.CreatePrefab("DESTORY_EFFECT", 0, player.transform.position, Vector3.one * 4f, Quaternion.identity);
        Destroy(Particle, 3f);
        SoundManager.Play(E_SOUNLIST.E_EATCELL_1);

        nType = -1;
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_Bubble"))
        {

            if (!player.PlayerDie)
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
                        ActivateCoin();
                        DisableItem();
                        break;

                }

            }
        }
        else
            return;
    }

}
