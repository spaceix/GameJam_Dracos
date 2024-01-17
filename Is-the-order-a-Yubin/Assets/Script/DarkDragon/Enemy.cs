using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public string SkillName;        // 스킬 이름
    public float DelayTime;         // 쿨타임
    public float NowDelay = 0;      // 현재 쿨타임
    public float AtkField;          // 공격 범위
    public int AtkCode;             // 공격 코드 (FSM 호출)

    // 스킬 설정 함수
    public void SetSkill(string _SkillName, float _DelayTime, float _AtkField, int _AtkCode)
    {
        SkillName = _SkillName;
        DelayTime = _DelayTime;
        NowDelay = _DelayTime;
        AtkField = _AtkField;
        AtkCode = _AtkCode;
    }
}

public class Enemy : MonoBehaviour
{
    public string enemyName;        // 적 이름
    public int maxHp;               // 최대 체력
    public int nowHp;               // 현재 체력
    public bool isAttacking = false; // 공격 중인지 여부
    public float moveSpeed;         // 이동 속도
    public float fieldOfVision;     // 시야 범위

    public Skill[] SkillList;       // 스킬 리스트

    // DarkDragon 스킬 초기화 함수
    private void SetDarkDragonSkill()
    {
        SkillList = new Skill[6];

        for (int i = 0; i < SkillList.Length; i++)
            SkillList[i] = new Skill();

        SkillList[0].SetSkill("꼬리평타", 3f, 2f, 1);
        SkillList[1].SetSkill("발톱평타", 3f, 1f, 2);
        SkillList[2].SetSkill("원형불", 17.5f, 5f, 3);
        SkillList[3].SetSkill("먹이응집", 17.5f, 10f, 4);
        SkillList[4].SetSkill("원형화염구", 20f, 10f, 5);
        SkillList[5].SetSkill("부채꼴화염구", 12.5f, 15f, 6);
    }

    // 적 스탯 초기화 함수
    private void SetEnemyStatus(string _enemyName, int _maxHp, float _moveSpeed, float _fieldOfVision)
    {
        enemyName = _enemyName;
        maxHp = _maxHp;
        nowHp = _maxHp;
        moveSpeed = _moveSpeed;
        fieldOfVision = _fieldOfVision;
    }

    public Image nowHpbar;          // 현재 체력바
    public GameObject prfHpBar;     // 체력바 프리팹
    public GameObject canvas;       // 캔버스

    RectTransform hpBar;            // 체력바 RectTransform
    public float height = 1.7f;      // 체력바 높이

    public MoveScript Player;        // 플레이어 객체

    // 시작 시 호출되는 함수
    void Start()
    {
        // 체력바 생성 및 초기화
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
        SetEnemyStatus("DarkDragon", 1000, 3f, 500f);
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        SetDarkDragonSkill();
    }

    // 프레임마다 호출되는 함수
    void Update()
    {
        // 체력바 위치 업데이트
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }

    // 플레이어와의 충돌 시 호출되는 함수
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // 플레이어 공격 시 체력 감소 및 사망 체크
            if (Player.attacked)
            {
                nowHp -= Player.atkDmg;
                Player.attacked = false;

                if (nowHp <= 0) Die(); // 사망 처리
            }
        }
    }

    // 적 사망 처리 함수
    void Die()
    {
        GetComponent<EnemyAI>().enabled = false;    // 추적 비활성화
        GetComponent<Collider2D>().enabled = false; // 충돌체 비활성화
        Destroy(GetComponent<Rigidbody2D>());       // 중력 비활성화
        Destroy(gameObject, 3);                     // 3초 후 제거
        Destroy(hpBar.gameObject, 3);               // 3초 후 체력바 제거
    }
}
