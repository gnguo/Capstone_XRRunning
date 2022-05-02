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
        itemCollection = GameObject.Find("Item_Collection").GetComponent<Item_Collection>();
    }

    //ÃÊ±âÈ­
    private void OnEnable()
    {
        
        float x = Random.Range(-3.6f, 3.6f);
        float z = itemCollection.player.transform.position.z + 42;

        Vector3 position = new Vector3(x, 0, z);

        this.transform.position = position;

        Debug.Log(position);
        Invoke(nameof(DeactiveDelay), 5);
    }

    void DeactiveDelay() => gameObject.SetActive(false);

    private void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
        CancelInvoke();
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
        else
            return;
    }

}
