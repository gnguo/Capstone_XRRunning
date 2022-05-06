using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlotSpanwer : MonoBehaviour
{
    private int initAmount = 7;
    private float plotSize = 60f;
    private float xPosLeft = -24.21f;
    private float xPosRight = 24.21f;
    private float lastZPos = -45f;

    public string[] plots;

    public ObjectManager objectManager;

    void Awake()
    {
        plots = new string[]{ "Plane_Left (0)", "Plane_Left (1)", "Plane_Left (2)",
                              "Plane_Left (3)", "Plane_Left (4)","Plane_Left (5)","Plane_Left (6)",
                              "Plane_Left (7)", "Plane_Left (8)","Plane_Left (9)","Plane_Left (10)",
                              "Plane_Left (11)", "Plane_Left (12)","Plane_Left (13)"};
    }

    private void Start()
    {
      for (int i = 0; i < initAmount; i++)
      {
          SpawnPlot();
     
      }
    }

    public void SpawnPlot()
    {
        StartCoroutine(SpawnPlotCoroutine());
    }

    IEnumerator SpawnPlotCoroutine()
    {
        //GameObject plotLeft = plots[Random.Range(0, plots.Count)];

        //GameObject plotRight = plots[Random.Range(0, plots.Count)];
        int ranplots = Random.Range(0, 13);
        float zPos = lastZPos + plotSize;

        //var plotL = Instantiate(plotLeft, new Vector3(xPosLeft, 0.025f, zPos), plotLeft.transform.rotation);
        //Instantiate(plotLeft, new Vector3(xPosLeft, 0.025f, zPos), plotLeft.transform.rotation); 
        GameObject plotL = objectManager.MakeObj(plots[ranplots]);
        plotL.transform.position = new Vector3(xPosLeft, 0.025f, zPos);
        plotL.transform.rotation = plotL.transform.rotation;


        //var plotR = Instantiate(plotRight, new Vector3(xPosRight, 0.025f, zPos), new Quaternion(0, 180, 0, 0));
        //Instantiate(plotRight, new Vector3(xPosRight, 0.025f, zPos), new Quaternion(0, 180, 0, 0));
        GameObject plotR = objectManager.MakeObj(plots[ranplots]);
        plotR.transform.position = new Vector3(xPosRight, 0.025f, zPos);
        plotR.transform.rotation = new Quaternion(0, 180, 0, 0);


        lastZPos += plotSize;

        yield return new WaitForSeconds(20f);

        plotL.SetActive(false);
        plotR.SetActive(false);


    }



    //Invoke("plotInvoke", 1f);


    public void plotInvoke()
    {
        gameObject.SetActive(false);

    }
    public void plotStartInvoke()
    {
        gameObject.SetActive(true);
    }


}
