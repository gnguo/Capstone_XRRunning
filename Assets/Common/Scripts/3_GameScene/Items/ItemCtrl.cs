using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{

    private Item_Collection itemCollection;
    private Magnet magnet;

    public enum eItem { Heart, PowerUp, Magnet };
    public eItem itemType;

    public int nIndex;

    public bool bUse;

    void Awake()
    {
        itemCollection = GameObject.Find("Item_Collection").GetComponent<Item_Collection>();
    }

    //ÃÊ±âÈ­
    private void OnEnable()
    {
        int ranNum = Random.Range(0, 3);
        float z = itemCollection.player.transform.position.z;

        switch (ranNum)
        {
            case 0:
                this.transform.position = new Vector3(3.6f, 0, z);

                Invoke(nameof(DeactiveDelay), 5);
                break;

            case 1:
                this.transform.position = new Vector3(0, 0, z);

                Invoke(nameof(DeactiveDelay), 5);
                break;

            case 2:
                this.transform.position = new Vector3(-3.6f, 0, z);

                Invoke(nameof(DeactiveDelay), 5);
                break;

        }
    }

    void DeactiveDelay() => gameObject.SetActive(false);

    private void OnDisable()
    {
        switch (itemType)
        {
            case eItem.Heart:
                ObjectPooler.ReturnToPool(gameObject);
                CancelInvoke();
                break;

            case eItem.PowerUp:
                ObjectPooler.ReturnToPool(gameObject);
                CancelInvoke();
                break;

            case eItem.Magnet:
                break;
        }
    }


    public void FullHealth()
    {
        if (itemCollection.player.gameInstance.curHp < itemCollection.player.gameInstance.maxHp)
        {
            itemCollection.player.gameInstance.curHp = 100;
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
                }
        }
        else
            return;
    }

}
