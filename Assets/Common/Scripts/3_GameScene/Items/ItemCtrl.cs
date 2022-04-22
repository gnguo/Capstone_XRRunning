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

    public PlayerCtrl player;

    public Magnet magnetItem;

    private void Awake()
    {
        magnetItem = GetComponent<Magnet>();
    }
    private void Start()
    {
        EnableItem();
    }

    private void OnTriggerEnter(Collider other)
    {
        //PlayerCtrl player = other.transform.parent.GetComponent<PlayerCtrl>();

        if(player)
        {
            if(!player.IsHit && !player.PlayerDie)
            {
                switch(itemType)
                {
                    case eItem.Heart:
                        DisableItem();
                        FullHealth();
                        break;
                    case eItem.PowerUp:
                        DisableItem();
                        StartCoroutine(PowerUpCoroution());
                        break;
                    case eItem.Magnet:
                        DisableItem();
                        magnetItem.ActivateCoin();
                        break;
                }

            }
        }
    }

    public void EnableItem()
    {
        if(!bUse)
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

    public void FullHealth()
    {
        if(player.curHp < player.maxHp)
        {
            player.curHp = 100;
        }
    }
    
    IEnumerator PowerUpCoroution()
    {
        PlayerTouchMovement touchSpeed = GetComponent<PlayerTouchMovement>();
        float moveSpeed = touchSpeed.moveSpeed;
        
        moveSpeed = moveSpeed * 1.5f;
        player.gameObject.layer = 10;

        yield return new WaitForSeconds(5);
        player.gameObject.layer = 6;

        moveSpeed = touchSpeed.moveSpeed;
    }
}
