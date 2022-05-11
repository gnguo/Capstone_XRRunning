using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPosCtrl : MonoBehaviour
{
    public Transform PlayerPos;

    private void Update()
    {
        if(PlayerPos.position.x > 0)
        {
            float x = this.transform.position.x - PlayerPos.transform.position.x;

            Vector3 Pos = new Vector3(x, this.transform.position.y, this.transform.position.z);

            this.transform.position = Pos;

            return;
        }

        if (PlayerPos.position.x <0)
        {
            float x = this.transform.position.x + PlayerPos.transform.position.x;

            Vector3 Pos = new Vector3(x, this.transform.position.y, this.transform.position.z);

            this.transform.position = Pos;
            return;
        }

        if (PlayerPos.position.x == 0)
        {
            Vector3 Pos = new Vector3(0, this.transform.position.y, this.transform.position.z);

            this.transform.position = Pos;
            return;
        }
    }
}
