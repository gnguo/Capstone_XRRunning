using MHomiLibrary;
using System.Collections;
using System.Collections.Generic;
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


    private void Start()
    {
        GotoLobbyScene();
    }
    //[사용자 정의함수]===================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================


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
