using MHomiLibrary;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameScene : HSingleton<GameScene>
{

    protected GameScene() { }

    public bool IsPause = false;

    public GameObject pausePanel;
    public GameObject playerDeadPanel;
    public GameObject OptionPanel;
    public GameObject ReStartPanel;

    public GameObject StartTimeImg;

    public float StartdelayT;
    public bool IsStartDelay = false;

    /// <summary>
    /// UI text모음
    /// </summary>
    public TextMeshProUGUI coinT;
    public TextMeshProUGUI coinT_die;
    public TextMeshProUGUI distance_text;
    public TextMeshProUGUI distance_text_die;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI score_text_die;
    public TextMeshProUGUI time_text;
    public TextMeshProUGUI time_text_die;

    public TextMeshProUGUI StartTimeT;
    public GameObject StartPanel;

    //ItemCtrl itemctrl;
    GameInstance gameInstance;

    /// <summary>
    /// UI타이머 설정
    /// </summary>
    private GameObject player;
    public float startTime;

    float timeT = 3;

    float sec;
    float min;

    public List<Image> StarImgs;

    private void Awake()
    {
        //itemctrl = GameObject.FindGameObjectWithTag("Items").GetComponent<ItemCtrl>();
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();

    }
    private void Start()
    {
        GotoLobbyScene();
        player = GameObject.Find("Player");
        StartCoroutine("UI_Time");

        Invoke("InvokeStartT", 3.1f);
        for (int i = 0; i < 3; i++)
        {
            Color color = StarImgs[i].GetComponent<Image>().color;
            color.a = 0f;
            StarImgs[i].GetComponent<Image>().color = color;
        }
    }
    public void Update()
    {
        GameStartTimer();

        coinT.text = gameInstance.coinScore.ToString();
        coinT_die.text = coinT.text;

        gameInstance.stage01Distance = Mathf.RoundToInt((player.transform.position.z + 12.2f)) / 20;
        gameInstance.stage01Score = (gameInstance.stage01Distance * 10) + (int)(Time.deltaTime + 100);
            //(distance * 5) + (int)(Time.deltaTime + 100);

        distance_text.text = gameInstance.stage01Distance.ToString() + "M";
        distance_text_die.text = gameInstance.stage01Distance.ToString() + "M";

        score_text.text = gameInstance.stage01Score.ToString();
        score_text_die.text = gameInstance.stage01Score.ToString();

        gameInstance.Stage01Star(StarImgs);
    }

    //[사용자 정의함수]===================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    IEnumerator UI_Time()
    {
        while (true)
        {
            startTime += Time.deltaTime;
            sec = (int)(startTime % 60);
            min = (int)(startTime / 60 % 60);

            time_text.text = string.Format("{0:00}:{1:00}", min, sec);
            time_text_die.text = string.Format("{0:00}:{1:00}", min, sec);


            yield return null;
        }
    }

    void GameStartTimer()
    {
        if(!gameInstance.Stage01Start)
        {
            StartPanel.SetActive(true);

            if (Mathf.Floor(timeT) <= 0)
                return;

            else
            {
                timeT -= Time.deltaTime;

                StartTimeT.text = Mathf.Floor(timeT).ToString();

            }
        }
    }

    void InvokeStartT()
    {
        gameInstance.Stage01Start = true;
        StartPanel.SetActive(false);
    }

    public void StartDelayTime()
    {
        StartdelayT -= Time.deltaTime * 1f;

        if (StartdelayT > 0)
        {
            IsStartDelay = true;

            StartTimeImg.SetActive(true);
        }
        else if (StartdelayT <= 0)
        {
            IsStartDelay = false;
            StartTimeImg.SetActive(false);
        }


    }

    private void GotoLobbyScene()
    {
        if (GameObject.Find("GameInstance") == null)
            SceneManager.LoadScene("0_IntroScene");
    }

    public void GamePause()
    {
        //gamePause시 공통사항들...sound 등
        IsPause = true;

        Time.timeScale = 0;

    }
    public void PlayerDie()
    {
        GamePause();

        print("PlayerDie실행됨"); //x
        playerDeadPanel.SetActive(true);
        //gameover 결과 추가....
    }
    public void GamePauseBtn()
    {
        GamePause();
        pausePanel.SetActive(true);      
    }
    
    public void GoToGameBtn()
    {
        if (IsPause)
        {
            Time.timeScale = 1;
            IsPause = false; 
            
            if (ReStartPanel)
            {
                ReStartPanel.SetActive(false);
            }

            pausePanel.SetActive(false);
            OptionPanel.SetActive(false);
            return;
        }
    }

    public void RestartQBtn()
    {
        ReStartPanel.SetActive(true);
    }

    public void GoToReGameBtn()
    {
        IsPause = false;
        gameInstance.Stage01Start = false;

        Time.timeScale = 1;
        //fade in fade out? 넣어야할듯 , UI초기화도 필요
        SceneManager.LoadScene("2_LobbyScene");  //3_GameScene
        
    }

    public void GoToOptionBtn()
    {
        OptionPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void GoToBackBtn()
    {
        OptionPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void GoToQuitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
  

}
