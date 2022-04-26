using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject coinDetectorObj;

    // Start is called before the first frame update
    void Start()
    {
        //coinDetectorObj = GameObject.FindGameObjectWithTag("Coin_Detector");
        //coinDetectorObj.SetActive(false);

    }

    // Update is called once per frame
    public void ActivateCoin()
    {
        Debug.Log("�Լ������Ϳ�");
        StartCoroutine(ActivateCoinCoroutine());
        Destroy(transform.GetChild(0).gameObject);
    }

    IEnumerator ActivateCoinCoroutine()
    {
        coinDetectorObj.SetActive(true);
        yield return new WaitForSeconds(6f);
        coinDetectorObj.SetActive(false);
    }

}
