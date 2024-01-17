using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    // 이동 속도
    public float speed = 20;

    // 리지드바디와 이동 벡터
    Rigidbody rigidbody;
    Vector3 movement;

    // 체력 및 공격 관련 변수
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1;
    public bool attacked = false;
    public Image nowHpbar;

    // 피격 관련 타이머
    float timer;

    // 충돌 발생 시 호출되는 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // "fire" 태그의 오브젝트와 충돌 시
        if (collision.tag == "fire")
        {
            nowHp -= 5;
            Destroy(collision.gameObject);
        }
    }

    // 충돌 지속 중 호출되는 함수
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        // 0.25초마다 "filed" 태그의 오브젝트와 충돌 시 체력 감소
        if (timer > 0.25f)
        {
            if (collision.tag == "filed")
                nowHp -= 1;
            timer = 0;
        }
    }

    // 시작 시 호출되는 함수
    void Start()
    {
        // 초기값 설정
        maxHp = 50;
        nowHp = 50;
        atkDmg = 30;
        rigidbody = GetComponent<Rigidbody>();
    }

    // 프레임마다 호출되는 함수
    void Update()
    {
        // 현재 체력바 업데이트
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;

        // 키보드 입력에 따른 이동 처리
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.up * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.up * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - transform.right * Time.deltaTime * speed;
        }
        // 스페이스바 입력 시 공격 플래그 설정
        else if (Input.GetKey(KeyCode.Space))
        {
            attacked = true;
        }
    }
}
