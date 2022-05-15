using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPooler : MonoBehaviour
{
    public GameObject Obs1Prefab;
    public GameObject Obs2Prefab;
    public GameObject Obs3Prefab;
    public GameObject Obs4Prefab;
    public GameObject Obs5Prefab;
    public GameObject Obs6Prefab;
    public GameObject Obs7Prefab;
    public GameObject Obs8Prefab;
    public GameObject Obs9Prefab;
    public GameObject Obs10Prefab;
    public GameObject Obs11Prefab;
    public GameObject Obs12Prefab;
    public GameObject Obs13Prefab;
    public GameObject Obs14Prefab;

    GameObject[] obs1;
    GameObject[] obs2;
    GameObject[] obs3;
    GameObject[] obs4;
    GameObject[] obs5;
    GameObject[] obs6;
    GameObject[] obs7;
    GameObject[] obs8;
    GameObject[] obs9;
    GameObject[] obs10;
    GameObject[] obs11;
    GameObject[] obs12;
    GameObject[] obs13;
    GameObject[] obs14;

    GameObject[] targetPool;

    void Start()
    {
        obs1 = new GameObject[3];
        obs2 = new GameObject[3];
        obs3 = new GameObject[3];
        obs4 = new GameObject[3];
        obs5 = new GameObject[3];
        obs6 = new GameObject[3];
        obs7 = new GameObject[3];
        obs8 = new GameObject[3];
        obs9 = new GameObject[3];
        obs10 = new GameObject[3];
        obs11 = new GameObject[3];
        obs12 = new GameObject[3];
        obs13 = new GameObject[3];
        obs14 = new GameObject[3];

        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < obs1.Length; i++)
        {
            obs1[i] = Instantiate(Obs1Prefab);
            obs1[i].SetActive(false);
        }

        for (int i = 0; i < obs2.Length; i++)
        {
            obs2[i] = Instantiate(Obs2Prefab);
            obs2[i].SetActive(false);
        }

        for (int i = 0; i < obs3.Length; i++)
        {
            obs3[i] = Instantiate(Obs3Prefab);
            obs3[i].SetActive(false);
        }

        for (int i = 0; i < obs4.Length; i++)
        {
            obs4[i] = Instantiate(Obs4Prefab);
            obs4[i].SetActive(false);
        }

        for (int i = 0; i < obs5.Length; i++)
        {
            obs5[i] = Instantiate(Obs5Prefab);
            obs5[i].SetActive(false);
        }

        for (int i = 0; i < obs6.Length; i++)
        {
            obs6[i] = Instantiate(Obs6Prefab);
            obs6[i].SetActive(false);
        }

        for (int i = 0; i < obs7.Length; i++)
        {
            obs7[i] = Instantiate(Obs7Prefab);
            obs7[i].SetActive(false);
        }

        for (int i = 0; i < obs8.Length; i++)
        {
            obs8[i] = Instantiate(Obs8Prefab);
            obs8[i].SetActive(false);
        }

        for (int i = 0; i < obs9.Length; i++)
        {
            obs9[i] = Instantiate(Obs9Prefab);
            obs9[i].SetActive(false);
        }
        for (int i = 0; i < obs10.Length; i++)
        {
            obs10[i] = Instantiate(Obs10Prefab);
            obs10[i].SetActive(false);
        }
        for (int i = 0; i < obs11.Length; i++)
        {
            obs11[i] = Instantiate(Obs11Prefab);
            obs11[i].SetActive(false);
        }
        for (int i = 0; i < obs12.Length; i++)
        {
            obs12[i] = Instantiate(Obs12Prefab);
            obs12[i].SetActive(false);
        }
        for (int i = 0; i < obs13.Length; i++)
        {
            obs13[i] = Instantiate(Obs13Prefab);
            obs13[i].SetActive(false);
        }
        for (int i = 0; i < obs14.Length; i++)
        {
            obs14[i] = Instantiate(Obs14Prefab);
            obs14[i].SetActive(false);
        }

    }

    public GameObject MakeObject(string type)
    {
        switch (type)
        {
            case "obs1":
                targetPool = obs1;
                break;
            case "obs2":
                targetPool = obs2;
                break;
            case "obs3":
                targetPool = obs3;
                break;
            case "obs4":
                targetPool = obs4;
                break;
            case "obs5":
                targetPool = obs5;
                break;
            case "obs6":
                targetPool = obs6;
                break;
            case "obs7":
                targetPool = obs7;
                break;
            case "obs8":
                targetPool = obs8;
                break;
            case "obs9":
                targetPool = obs9;
                break;
            case "obs10":
                targetPool = obs10;
                break;
            case "obs11":
                targetPool = obs11;
                break;
            case "obs12":
                targetPool = obs12;
                break;
            case "obs13":
                targetPool = obs13;
                break;
            case "obs14":
                targetPool = obs13;
                break;
        }

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }
        return null;
    }
}

