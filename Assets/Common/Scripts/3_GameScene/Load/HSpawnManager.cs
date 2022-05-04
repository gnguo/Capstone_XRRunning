using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSpawnManager : MonoBehaviour
{
    HRoadSpawn roadSpawn;
    JPlotSpanwer plotSpawner;
    public JObstaclesSpanwer obstaclesSpawner;
    public Item_Collection itemColletction;

    void Start()
    {
        roadSpawn = GetComponent<HRoadSpawn>();
        plotSpawner = GetComponent<JPlotSpanwer>();
        obstaclesSpawner = GetComponent<JObstaclesSpanwer>();
    }

   
    void Update()
    {
        
    }

    public void SpawnTriggerEnter()
    {
        roadSpawn.MoveRoad();
        plotSpawner.SpawnPlot();
        itemColletction.ItemSpawn();
    }



}
