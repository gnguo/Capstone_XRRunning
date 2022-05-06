using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject coinDetectorObj;
    public PlayerCtrl player;

    public bool isMagnet;

    // Update is called once per frame
    public void ActivateCoin()
    {
        if(!isMagnet)
        {
            SoundManager.Play(E_SOUNLIST.E_EATCELL_1);
            player.EffectList[1].Play();

            StartCoroutine(ActivateCoinCoroutine());
        }
    }

    IEnumerator ActivateCoinCoroutine()
    {
        isMagnet = true;

        coinDetectorObj.SetActive(true);
        yield return new WaitForSeconds(4f);
        coinDetectorObj.SetActive(false);

        isMagnet = false;
    }

}
