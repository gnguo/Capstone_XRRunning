using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JObstaclesSpanwer : MonoBehaviour
{
    public string[] Obs;
    private float ObstaclesSize = 120f;
    private float lastZPos = -60f;

    public ObstaclesPooler obsPooler;
    PlayerCtrl player;

    private void Awake()
    {
        Obs = new string[]{ "obs1", "obs2", "obs3",
                              "obs4", "obs5","obs6","obs7",
                              "obs8", "obs9","obs10","obs11",
                              "obs12", "obs13","obs14"};

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>();

    }
    public void SpawnObstacle()
    {
        int ranplots = Random.Range(0, 13);

        GameObject Obstacle = obsPooler.MakeObject(Obs[ranplots]);
        float zPos = player.transform.position.z + ObstaclesSize;

        Obstacle.transform.position = new Vector3(0, 0.025f, zPos);

    }

}