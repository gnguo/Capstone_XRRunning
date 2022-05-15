using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCtrl : MonoBehaviour
{
    private void Update()
    {
        if(this.gameObject.activeSelf)
            Invoke(nameof(DeactiveDelay), 8);
    }

    void DeactiveDelay() => gameObject.SetActive(false);

    private void OnDisable()
    {
        CancelInvoke();
    }

}
