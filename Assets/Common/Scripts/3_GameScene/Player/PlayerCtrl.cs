using MHomiLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    [Header("[컴포넌트들]")]
    [Space(10f)]
    /// <summary>
    /// 이펙트 리스트
    /// </summary>
    public List<GameObject> EffectList;

    /// <summary>
    /// 파티클 리스트
    /// </summary>
    public List<ParticleSystem> ShieldParticles;

    [SerializeField]
    private float dragDistance = 14.0f;
    private float dragDistanceY = 20;
    private float dragDistanceDownY = -20;

    private Vector3 touchStart;
    private Vector3 touchEnd;

    /// <summary>
    /// 쉴드 상태 저장 변수
    /// </summary>
    public int nShield;
    public int coinScore;

    private SkinnedMeshRenderer[] meshs;
    private PlayerTouchMovement movement;


    private GameScene gameScene;
    private GameInstance gameInstance;
    public Item_Collection itemCollection;

    public Animator anim;

    public HSpawnManager spawnManager;
    public CapsuleCollider capsuleCol;

    public bool IsHit = false;
    public bool PlayerDie = false;
    public bool IsSlied = false;

    [SerializeField]
    private Slider hpbar;


    public float maxHp = 100;
    public float curHp = 100;


    private void Awake()
    {
        movement = GetComponent<PlayerTouchMovement>();
        meshs = GetComponentsInChildren<SkinnedMeshRenderer>();
        gameScene = GameObject.Find("GameScene").GetComponent<GameScene>();
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();
    }

    void Start()
    {
        //gameScene.StartDelayTime();
        hpbar.value = (float)curHp / (float)maxHp;
        movement.moveSpeed = 30;
        Debug.Log(movement.moveSpeed);

    }

    void Update()
    {
        //if(!gameScene.IsStartDelay)
        //{
        HPHandle();

        if (Application.isMobilePlatform)
        {
            OnMobilePlatform();
        }
        else
        {
            OnPCPlatform();
        }
        //
    }

    //[사용자 정의 함수]==================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================

    void OnMobilePlatform()
    {
        if (Input.touchCount == 0)
            return;
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
        }

        else if (touch.phase == TouchPhase.Moved)
        {
            touchEnd = touch.position;

            OnDragXY();

        }
    }

    private void OnPCPlatform()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;

            if (!PlayerDie)
                OnDragXY();
        }
    }

    private void OnDragXY()
    {

        if (Mathf.Abs(touchEnd.x - touchStart.x) >= dragDistance && !movement.isJump && !IsSlied)
        {
            movement.MoveToX((int)Mathf.Sign(touchEnd.x - touchStart.x));
            return;
        }

        if (touchEnd.y - touchStart.y >= dragDistanceY)
        {
            movement.MoveToY();
            StartCoroutine(JumpOrDownTouchCoroutine());
            return;
        }

        if (touchEnd.y - touchStart.y <= dragDistanceDownY )
        {
            StartCoroutine(JumpOrDownTouchCoroutine());
            return;
        }
    }

    private void HPHandle()
    {
        //?????? ?????? hp???? ???????? ???????? ????
        hpbar.value = Mathf.Lerp(hpbar.value, (float)curHp / (float)maxHp, Time.deltaTime * 10);
    }



    public void HitObstacle()
    {
        if (curHp > 0 && !itemCollection.bPowerUp)
        {
            curHp -= 10;

            StartCoroutine(HitObstacleICoroutine());
        }

        if (curHp <= 0)
        {

            StartCoroutine(PlayerDeadCoroutine());
        }
    }

    IEnumerator PlayerDeadCoroutine()
    {
        PlayerDie = true;
        anim.SetTrigger("dieT");

        yield return new WaitForSeconds(0.5f);

        gameScene.PlayerDie();

        //gameoverUI start.
        //gameStop
    }

    IEnumerator HitObstacleICoroutine()
    {
        IsHit = true;
        if (IsHit)
        {
            foreach (SkinnedMeshRenderer mesh in meshs)
            {
                mesh.material.color = Color.red;
            }
            movement.moveSpeed = 17f;

        }

        yield return new WaitForSeconds(0.1f);

        IsHit = false;

        if (!IsHit)
        {
            foreach (SkinnedMeshRenderer mesh in meshs)
            {
                mesh.material.color = Color.white;
            }
            movement.moveSpeed = 30;
        }

    }


    IEnumerator JumpOrDownTouchCoroutine()
    {
        IsSlied = true;
        capsuleCol.enabled = false;

        if (movement.isJump)
        {
            //start Jumpanim trigger
            anim.SetBool("IsJump", true);
        }
        else
        {
            anim.SetBool("IsSlide", true);
        }

        yield return new WaitForSeconds(0.3f);

        IsSlied = false;

        if (anim.GetBool("IsJump") == true)
        {
            //start Jumpanim trigger
            anim.SetBool("IsJump", false);
        }

        else if (anim.GetBool("IsSlide") == true)
        {
            anim.SetBool("IsSlide", false);
        }

        yield return new WaitForSeconds(0.31f);

        capsuleCol.enabled = true;
        Debug.Log(capsuleCol.enabled);


    }

}
