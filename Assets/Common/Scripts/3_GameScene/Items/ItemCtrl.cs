using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public int nIndex;

    public bool bUse;

    public short nType;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCtrl player = other.transform.parent.GetComponent<PlayerCtrl>();

        if(player)
        {
            if(!player.IsHit && !player.PlayerDie)
            {

            }
        }
    }

    public void EnableItem()
    {
        bUse = true;
        gameObject.SetActive(true);
    }

    public void DisableItem()
    {
        GameObject Particle = GameInstance.I.CreatePrefab("",0, transform.position, Vector3.one * 4f, Quaternion.identity);
        Destroy(Particle, 3f);

        bUse = false;
        nType = -1;
        gameObject.SetActive(false);
    }
}
