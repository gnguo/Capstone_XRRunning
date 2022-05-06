using System.Collections;
using System.Collections.Generic;
using MHomiLibrary;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//using DG.Tweening;

public class LobbyScene : HSingleton<LobbyScene>


//HSingleton<LobbyScene>
{
    protected LobbyScene() { }

    public RectTransform CanvasTM;

    public GameObject OptionPanel;

    public TextMeshProUGUI coinT;
    public TextMeshProUGUI coinT_Shop;

    public GameObject shopPanel;

    GameInstance gameInstance;

    bool isStage01;
    bool isStage02;


    private void Awake()
    {
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();
    }


    void Start()
    {
        GotoIntroScene();
    }

    /// <summary>
    /// 로고씬으로 가기^^^ 고고싱
    /// </summary>
    private void GotoIntroScene()
    {
       //if (GameObject.Find("GameInstance") == null)
       //    SceneManager.LoadScene("1_LoginScene");
    }

    void Update()
    {
        coinT.text = gameInstance.coinScore.ToString();
        coinT_Shop.text = gameInstance.coinScore.ToString();

    }
    //[사용자 정의함수]===================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================

    public void StageBtn01()
    {
        isStage01 = true;
        
        if (isStage02)
            isStage02 = false;

        shopPanel.SetActive(true);
    }
    
    public void StageBtn02()
    {
        isStage02 = true;

        if (isStage01)
            isStage01 = false;

        shopPanel.SetActive(true);
    }

    /// <summary>
    /// 게임씬으로고고싱
    /// </summary>
    public void GotoGameScene()
    {
        StartCoroutine(GoToGameSceneCoroutine());
    }

    IEnumerator GoToGameSceneCoroutine()
    {
        if (isStage01)
        {
            SoundManager.Play(E_SOUNLIST.E_SHOTBULLET);

            if (GameInstance.I.CreatePopupLoading(CanvasTM))
            {
                Debug.Log("개개개개개개개개개");
            }

            yield return new WaitForSeconds(0.5f);

            SceneManager.LoadScene("3_GameScene");

            isStage01 = false;
        }

        else if (isStage02)
        {
            SoundManager.Play(E_SOUNLIST.E_SHOTBULLET);

            if (GameInstance.I.CreatePopupLoading(CanvasTM))
            {
                Debug.Log("개개개개개개개개개");
            }

            yield return new WaitForSeconds(0.5f);

            SceneManager.LoadScene("4_GameScene");

            isStage02 = false;
        }

    }

    public void GoToOptionBtn()
    {
        OptionPanel.SetActive(true);
       
    }
    public void GoToBackBtn()
    {
        OptionPanel.SetActive(false);
        
    }

    public void GoToLobbyScene()
    {
        shopPanel.SetActive(false);
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
