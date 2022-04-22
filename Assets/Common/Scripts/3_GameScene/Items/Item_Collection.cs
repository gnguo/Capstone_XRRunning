using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item_Collection : MonoBehaviour
{
    public List<ItemCtrl> Items;

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


}
