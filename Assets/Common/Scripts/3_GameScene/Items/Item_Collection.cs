using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item_Collection : MonoBehaviour
{
    public List<ItemCtrl> Items;

    public bool bUse;
    public bool bPowerUp;
    public short nType;

    public PlayerCtrl player;

    public GameObject coinDetectorObj;
    public GameObject powerUp_Img;
    public PlayerTouchMovement touchmove;
    void Awake()
    {
        Items = new List<ItemCtrl>();

        int nCount = transform.childCount;

        for (int i = 0; i < nCount; i++)
        {
            ItemCtrl Item = transform.GetChild(i).GetComponent<ItemCtrl>();
            Items.Add(Item);
        }
    }

    void Start()
    {

    }


    void Update()
    {

    }

    //[사용자 정의 함수]==================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================




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

    public void PowerUp()
    {
        StartCoroutine(PowerUpCoroution());
    }

    IEnumerator PowerUpCoroution()
    {
        touchmove.moveSpeed = 60f;
        bPowerUp = true;
        powerUp_Img.SetActive(true);
        player.capsuleCol.enabled = false;
        Debug.Log(player.gameObject.layer);

        yield return new WaitForSeconds(5f);
        player.capsuleCol.enabled = true;
        powerUp_Img.SetActive(false);

        bPowerUp = false;
        touchmove.moveSpeed = 30f;
    }

}
