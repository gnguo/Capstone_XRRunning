using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JObstaclesSpanwer : MonoBehaviour
{
    private int initAmount = 14;
    private float ObstaclesSize = 30f;
    private float xPos = 0f;
    private float lastZPos = -60f;

    private void Start()
    {
      // for (int i = 0; i < initAmount; i++)
      // {
      //     SpawnObstacle();
      // }
    }
    private void Update()
    {
    }

    public void SpawnObstacle()
    {
        int ranNum = Random.Range(0, 14);

        if(ranNum ==0)
        {
            GameObject OBS1 = ObjectPooler.SpawnFromPool("OBS1",Vector2.zero);
        }

        else if(ranNum ==1)
        {
            GameObject OBS2 = ObjectPooler.SpawnFromPool("OBS2", Vector2.zero);
        }

        else if(ranNum ==2)
        {
            GameObject OBS3 = ObjectPooler.SpawnFromPool("OBS3", Vector2.zero);
        }

        else if(ranNum ==3)
        {
            GameObject OBS4 = ObjectPooler.SpawnFromPool("OBS4", Vector2.zero);
        }

        else if(ranNum ==4)
        {
            GameObject OBS5 = ObjectPooler.SpawnFromPool("OBS5", Vector2.zero);
        }

        else if(ranNum ==5)
        {
            GameObject OBS6 = ObjectPooler.SpawnFromPool("OBS6", Vector2.zero);
        }

        else if(ranNum ==6)
        {
            GameObject OBS7 = ObjectPooler.SpawnFromPool("OBS7", Vector2.zero);
        }

        else if(ranNum ==7)
        {
            GameObject OBS8 = ObjectPooler.SpawnFromPool("OBS8", Vector2.zero);
        }

        else if(ranNum ==8)
        {
            GameObject OBS9 = ObjectPooler.SpawnFromPool("OBS9", Vector2.zero);
        }

        else if(ranNum ==9)
        {
            GameObject OBS10 = ObjectPooler.SpawnFromPool("OBS10", Vector2.zero);
        }

        else if(ranNum ==10)
        {
            GameObject OBS11 = ObjectPooler.SpawnFromPool("OBS11", Vector2.zero);
        }

        else if(ranNum ==11)
        {
            GameObject OBS12 = ObjectPooler.SpawnFromPool("OBS12", Vector2.zero);
        }

        else if(ranNum ==13)
        {
            GameObject OBS13 = ObjectPooler.SpawnFromPool("OBS13", Vector2.zero);
        }

        else if(ranNum ==14)
        {
            GameObject OBS14 = ObjectPooler.SpawnFromPool("OBS14", Vector2.zero);
        }
        return;
    }

}