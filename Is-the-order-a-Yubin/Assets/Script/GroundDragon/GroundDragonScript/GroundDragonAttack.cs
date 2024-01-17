using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundDragonAttack : MonoBehaviour
{
    public GameObject stonePrefab; // 돌 Prefab
    public GameObject terrainPrefab; // 지형 Prefab

    public GameObject dustRangePrefab; // 먼지 범위 Prefab
    public GameObject skillRangePrefab; // 스킬 범위 Prefab
    public GameObject sPoint;

    public QuackAttack quackAttack;


    public bool isAttacking = false; // 공격 중인지 여부를 나타내는 변수
    public float nomalAttackCooldownTime = 2f; // 쿨타임 간격 (초)

    private float cooldownTimer = 0f; // 쿨타임 타이머
    private int skill = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Attack();
    }
    private void Attack()
    {

        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= nomalAttackCooldownTime)
        {
            switch (skill)
            {
                case 3:
                    Terrain();
                    break;
                case 6:
                    ShowSkillRange();
                    ShowDustSRange();
                    break;
                default:
                    StoneAttack();
                    break;
            }
            cooldownTimer = 0f; // 타이머 초기화
        }
        else
            isAttacking = false;

    }
    private void StoneAttack()
    {
        isAttacking = true;
        Instantiate(stonePrefab, sPoint.transform.position, sPoint.transform.rotation);
        skill++;
    }
    private void Terrain()
    {
        isAttacking = true;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(terrainPrefab, transform.position, transform.rotation);
        }
        skill++;
    }
    private void ShowDustSRange()
    {
        isAttacking = true;
        Instantiate(dustRangePrefab, transform.position, Quaternion.identity);
        skill = 0;
    }
    private void ShowSkillRange()
    {
        isAttacking = true;
        Instantiate(skillRangePrefab, transform.position, Quaternion.identity);
        skill = 0;
    }

}
