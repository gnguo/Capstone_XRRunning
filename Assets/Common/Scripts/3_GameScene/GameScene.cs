using MHomiLibrary;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : HSingleton<GameScene>
{

    protected GameScene() { }

    public bool IsPause = false;

    public GameObject pausePanel;
    public GameObject playerDeadPanel;
    public GameObject OptionPanel;

    public GameObject StartTimeImg;

    public float StartdelayT;
    public bool IsStartDelay = false;

    public TextMeshProUGUI coinT;
    public TextMeshProUGUI time_text;
    public TextMeshProUGUI time_text_die;

    ItemCtrl itemctrl;


    private GameObject player;

    /// <summary>
    /// UI타이머 설정
    /// </summary>
    public float startTime;
    float sec;
    float min;

    private void Awake()
    {
        itemctrl = GameObject.FindGameObjectWithTag("Items").GetComponent<ItemCtrl>();
    }
    private void Start()
    {
        GotoLobbyScene();
        player = GameObject.Find("Player");
        StartCoroutine("UI_Time");
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
            pausePanel.SetActive(false);
            OptionPanel.SetActive(false);
            return;
        }
    }

    public void GoToReGameBtn()
    {
        IsPause = false;
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
