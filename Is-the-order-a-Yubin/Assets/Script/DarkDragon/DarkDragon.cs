using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

// 드래곤의 상태를 정의하는 열거형
public enum DarkDragonState
{
    Idle = 0,       // 대기
    TailAttack,     // 꼬리 평타
    ClawsAttack,    // 발톱 평타
    FireCircle,     // 원형 불
    EattingMob,     // 먹이 끌어당기기
    CircleShoot,    // 원형 화염구
    FanShoot        // 부채꼴 화염구
}

public class DarkDragon : MonoBehaviour
{
    // 화염구 프리팹 및 목표 위치
    public GameObject prfFire;
    public Transform target;

    // 적 캐릭터 및 먹이 끌어당기는 영역 관련 변수
    Enemy enemy;
    GameObject eatfield;

    Skill[] SkillList;

    // 현재 드래곤의 상태
    private DarkDragonState dragonState;

    // 시작 시 호출되는 함수
    private void Awake()
    {
        // 먹이 끌어당기는 영역 초기화
        eatfield = transform.GetChild(0).gameObject;
        eatfield.SetActive(false);

        // 적 캐릭터 및 초기 상태 설정
        enemy = GetComponent<Enemy>();
        SkillList = enemy.SkillList;
        ChangeState(DarkDragonState.Idle);
    }

    // 상태를 설정하는 함수
    public void SetState(int num)
    {
        switch (num)
        {
            case 0: ChangeState(DarkDragonState.Idle); break;
            case 1: ChangeState(DarkDragonState.TailAttack); break;
            case 2: ChangeState(DarkDragonState.ClawsAttack); break;
            case 3: ChangeState(DarkDragonState.FireCircle); break;
            case 4: ChangeState(DarkDragonState.EattingMob); break;
            case 5: ChangeState(DarkDragonState.CircleShoot); break;
            case 6: ChangeState(DarkDragonState.FanShoot); break;
            default: break;
        }
    }

    // 현재 상태에 따라 동작을 수행하는 함수
    private void ChangeState(DarkDragonState newState)
    {
        // 이전 상태 코루틴 정지
        StopCoroutine(dragonState.ToString());

        // 새로운 상태로 변경 및 해당 상태 코루틴 시작
        dragonState = newState;
        StartCoroutine(dragonState.ToString());
    }

    // 대기 상태에 대한 코루틴
    private IEnumerator Idle()
    {
        Debug.Log("비전투모드");

        while (true)
        {
            yield return null;
        }
    }

    // 꼬리 평타에 대한 코루틴
    private IEnumerator TailAttack()
    {
        int i = 0;
        Debug.Log("꼬리평타");
        HitPlayer(6);

        enemy.isAttacking = false;

        // 대기 상태로 전환
        ChangeState(DarkDragonState.Idle);
        yield break;
    }

    // 발톱 평타에 대한 코루틴
    private IEnumerator ClawsAttack()
    {
        int i = 0;
        Debug.Log("발톱평타");

        //while (i < 0)
        //{
            HitPlayer(8);
        //}

        enemy.isAttacking = false;

        // 대기 상태로 전환
        ChangeState(DarkDragonState.Idle);
        yield break;
    }

    // 원형 불에 대한 코루틴
    private IEnumerator FireCircle()
    {
        int i = 0;
        Debug.Log("화염");
        eatfield.gameObject.SetActive(true);

        while (i < 5)
        {
            i++;
            yield return new WaitForSeconds(1);
        }

        eatfield.gameObject.SetActive(false);
        enemy.isAttacking = false;

        // 대기 상태로 전환
        ChangeState(DarkDragonState.Idle);
    }

    // 먹이 끌어당기기에 대한 코루틴
    private IEnumerator EattingMob()
    {
        int i = 0;
        while (i < 3)
        {
            i++;
            yield return new WaitForSeconds(1);
        }

        enemy.isAttacking = false;

        // 대기 상태로 전환
        ChangeState(DarkDragonState.Idle);
    }

    // 원형 화염구에 대한 코루틴
    private IEnumerator CircleShoot()
    {
        int i = 0;
        Debug.Log("원형화염구");

        while (i < 3)
        {
            i++;
            Circleshoot();
            yield return new WaitForSeconds(1);
        }

        enemy.isAttacking = false;

        // 대기 상태로 전환
        ChangeState(DarkDragonState.Idle);
    }

    // 부채꼴 화염구에 대한 코루틴
    private IEnumerator FanShoot()
    {
        int i = 0;
        Debug.Log("부채꼴화염구");

        while (i < 3)
        {
            i++;
            Fanshoot();
            yield return new WaitForSeconds(1);
        }

        enemy.isAttacking = false;

        // 대기 상태로 전환
        ChangeState(DarkDragonState.Idle);
    }

    // 원형 화염구 생성 함수
    private void Circleshoot()
    {
        // 360도 반복
        for (int i = 0; i < 360; i += 13)
        {
            GameObject temp = Instantiate(prfFire);
            Destroy(temp, 2f);
            temp.transform.position = transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    // 부채꼴 화염구 생성 함수
    private void Fanshoot()
    {
        Vector3 vec = transform.rotation.eulerAngles;
        // 60도씩 증가하면서 10번 반복
        for (int i = 0; i < 60; i += 10)
        {
            GameObject temp = Instantiate(prfFire);
            Destroy(temp, 2f);
            temp.transform.position = transform.position;
            temp.transform.Rotate(new Vector3(vec.x, vec.y, vec.z - 30 + i));
        }
    }

    private void HitPlayer(int i)
    {
        GameObject target = GameObject.Find("Player");
        target.GetComponent<MoveScript>().nowHp -= i;
    }
}
