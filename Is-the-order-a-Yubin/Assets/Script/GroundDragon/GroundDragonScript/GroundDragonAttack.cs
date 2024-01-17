using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundDragonAttack : MonoBehaviour
{
    public GameObject stonePrefab; // �� Prefab
    public GameObject terrainPrefab; // ���� Prefab

    public GameObject dustRangePrefab; // ���� ���� Prefab
    public GameObject skillRangePrefab; // ��ų ���� Prefab
    public GameObject sPoint;

    public QuackAttack quackAttack;


    public bool isAttacking = false; // ���� ������ ���θ� ��Ÿ���� ����
    public float nomalAttackCooldownTime = 2f; // ��Ÿ�� ���� (��)

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
