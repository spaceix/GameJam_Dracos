using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundDragonAttack : MonoBehaviour
{
    public GameObject stonePrefab; // �� Prefab
    public GameObject terrainPrefab; // ���� Prefab
    public GameObject dustPrefab; // ���� Prefab
    public GameObject skillRangePrefab; // ��ų ���� Prefab
    public GameObject sPoint;
    public QuackAttack quackAttack;
    public bool isAttacking = false; // ���� ������ ���θ� ��Ÿ���� ����
    public float nomalAttackCooldownTime = 2f; // ��Ÿ�� ���� (��)

    private float skillTimer = 0f;
    private float cooldownTimer = 0f; // ��Ÿ�� Ÿ�̸�
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
            if (skill == 3)
                Terrain();
            else if (skill == 6)
                QuakeSkill();
            else
                StoneAttack();
            cooldownTimer = 0f; // Ÿ�̸� �ʱ�ȭ
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
            Instantiate(terrainPrefab, sPoint.transform.position, sPoint.transform.rotation);
        }
        skill++;
    }
    private void QuakeSkill()
    {
        isAttacking = true;
        Instantiate(skillRangePrefab, transform.position, Quaternion.identity);

        skillTimer += Time.deltaTime;

        if (skillTimer >= quackAttack.skillInterval)
        {
            for (int i = 0; i < 20; i++)
                Instantiate(dustPrefab, transform.position, transform.rotation);
            skillTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }

        skill = 0;
    }
    private void ShowSkillRange()
    {

    }

}
