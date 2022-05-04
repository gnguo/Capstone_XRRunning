using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCtrl : MonoBehaviour
{
    private float ObstaclesSize = 30f;
    private float lastZPos = -60f;

    PlayerCtrl player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>();

    }
    private void OnEnable()
    {
        float zPos = player.transform.position.z + ObstaclesSize;

        this.transform.position = new Vector3(0, 0.025f, zPos);

        Invoke(nameof(DeactiveDelay), 5);
    }

    void DeactiveDelay() => gameObject.SetActive(false);

    private void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
        CancelInvoke();
    }
}
