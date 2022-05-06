using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOffField : MonoBehaviour
{
    public Image image;
    private void Start()
    {
        Color color = image.color;

        for (int i = 100; i >= 0; i--)                         
        {
            color.a -= Time.deltaTime * 0.06f;
            image.color = color;
            Debug.Log(color.a);
        }
    }

}