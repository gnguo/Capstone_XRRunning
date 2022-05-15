using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item_Collection : MonoBehaviour
{

    public bool bPowerUp;

    public PlayerCtrl player;

    public GameObject coinDetectorObj;
    public GameObject powerUp_Img;

    public PlayerTouchMovement touchmove;
    //public ItemCtrl items;

    public SphereCollider sphereCol;


    void Start()
    {
        coinDetectorObj.SetActive(false);

    }
    //[사용자 정의 함수]==================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    public void ItemSpawn()
    {
        int randomNum = Random.Range(0, 6);

        if (randomNum == 0 || randomNum == 1) 
        {
            GameObject Heart = ObjectPooler.SpawnFromPool("Heart", Vector2.zero);
            Debug.Log("hp 나와용");
        }
        
        else if (randomNum == 4) 
        {
            GameObject PowerUp = ObjectPooler.SpawnFromPool("PowerUp", Vector2.zero);
            Debug.Log("PowerUp 나와용");

        }
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
        //player.capsuleCol.enabled = false;
        Debug.Log(player.gameObject.layer);

        yield return new WaitForSeconds(3f);

        //player.capsuleCol.enabled = true;
        powerUp_Img.SetActive(false);


        bPowerUp = false;
        touchmove.moveSpeed = 30f;
        Debug.Log("ihihihihihihiihihihhihi");

    }
}
