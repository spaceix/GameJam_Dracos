using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundDragonAttack : MonoBehaviour
{
    public GameObject stonePrefab; // 돌 Prefab
    public GameObject terrainPrefab; // 지형 Prefab
    public GameObject dustPrefab; // 먼지 Prefab
    public GameObject skillRangePrefab; // 스킬 범위 Prefab
    public GameObject sPoint;

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
        Attack();
    }
    private void Attack()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= nomalAttackCooldownTime)
        {
            if (skill == 3)
                Terrain();
            else if (skill == 6)
                ShowSkillRange();
            else
                StoneAttack();
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
            Instantiate(terrainPrefab, sPoint.transform.position, sPoint.transform.rotation);
        skill++;
    }
    private void QuakeSkillAttack()
    {
        isAttacking = true;
        for (int i = 0; i < 20; i++)
            Instantiate(dustPrefab, transform.position, transform.rotation);
    }
    private void ShowSkillRange()
    {
        isAttacking = true;
        Instantiate(skillRangePrefab, transform.position, transform.rotation);
        skill = 0;
    }

}
