using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundDragonAttack : MonoBehaviour
{
    public GameObject stonePrefab; // 발사체 이미지
    public GameObject dustPrefab; // 발사체 이미지
    public bool isAttacking = false; // 공격 중인지 여부를 나타내는 변수
    public float nomalAttackCooldownTime = 2f; // 쿨타임 간격 (초)

    private float cooldownTimer = 0f; // 쿨타임 타이머
    public int skill = 0;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= nomalAttackCooldownTime)
        {
            skill++;
            if (skill > 3)
                DustAttack();
            else
                StoneAttack();


            isAttacking = false;
            cooldownTimer = 0f; // 타이머 초기화
        }
        
    }
    void StoneAttack()
    {
        isAttacking = true;
            Instantiate(stonePrefab, transform.position, transform.rotation);
    }
    void DustAttack()
    {
        isAttacking = true;
        for (int i = 0; i < 20;i++)
            Instantiate(dustPrefab, transform.position, transform.rotation);
        skill = 0;
    }
    
}
