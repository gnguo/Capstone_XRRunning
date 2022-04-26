using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemColCtrl : MonoBehaviour
{

    public PlayerCtrl player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrigger"))
        {
            player.spawnManager.SpawnTriggerEnter();

        }
        
        if (other.CompareTag("SpawnTrigger"))
        {
            GameObject Particle = GameInstance.I.CreatePrefab("DESTORY_EFFECT", 0, player.transform.position, Vector3.one * 4f, Quaternion.identity);
        }
    }

}
