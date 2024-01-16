using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum PlayerState
{
    Idle = 0,
    Move,
    Attack
}

public class PlayerFSM : MonoBehaviour
{
    
    private PlayerState playerState;

    private void Awake()
    {
        ChangeState(PlayerState.Idle);
    }

    private void Update()
    {
        if (Input.GetKeyDown("1")) ChangeState(PlayerState.Idle);
        else if (Input.GetKeyDown("2")) ChangeState(PlayerState.Move);
        else if (Input.GetKeyDown("3")) ChangeState(PlayerState.Attack);

        //UpdateState();
    }

    //private void UpdateState()
    //{
    //    switch(playerState)
    //    {
    //        case PlayerState.Idle:
    //            Debug.Log("대기중");
    //            break;
    //        case PlayerState.Move:
    //            Debug.Log("움직이는중");
    //            break;
    //        case PlayerState.Attack:
    //            Debug.Log("공격중");
    //            break;
    //    }
    //}

    private void ChangeState(PlayerState newState)
    {
        StopCoroutine(playerState.ToString());
        playerState = newState;
        StartCoroutine(playerState.ToString());
    }

    private IEnumerator Idle()
    {
        Debug.Log("비전투모드로 변경");
        Debug.Log("체력마력 회복");

        while(true)
        {
            Debug.Log("대기중");
            yield return null;
        }
    }
    private IEnumerator Move()
    {
        Debug.Log("이동속도 2");
        while(true)
        {
            Debug.Log("플레이어가 걸어갑니다");
            yield return null;
        }
    }
    
    private IEnumerator Attack()
    {
        Debug.Log("공격시작");
        while(true)
        {
            Debug.Log("공격하는중");
            yield return null;
        }
    }
}
