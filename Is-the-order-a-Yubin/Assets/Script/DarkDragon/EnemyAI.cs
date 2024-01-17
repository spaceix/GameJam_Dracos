using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EnemyAI : MonoBehaviour
{
    // 타겟 및 적 캐릭터 관련 변수
    public Transform target;
    Enemy enemy;
    DarkDragon dd;

    void Start()
    {
        // DarkDragon 및 Enemy 컴포넌트 가져오기
        dd = GetComponent<DarkDragon>();
        enemy = GetComponent<Enemy>();
    }

    // 스킬 딜레이 감소 함수
    void DecreaseDelay()
    {
        // 모든 스킬의 딜레이를 감소시킴
        for (int i = 0; i < enemy.SkillList.Length; i++)
        {
            enemy.SkillList[i].NowDelay -= Time.deltaTime;
            if (enemy.SkillList[i].NowDelay < 0)
                enemy.SkillList[i].NowDelay = 0;
        }
    }

    void Update()
    {
        // 스킬 딜레이 감소 함수 1초마다 호출
        Invoke("DecreaseDelay", 1f);
        // 타겟과의 거리 계산
        float distance = Vector3.Distance(transform.position, target.position);

        // 시야 범위 안에 들어올 때
        if (distance <= enemy.fieldOfVision)
        {
            FaceTarget(); // 타겟을 바라보기

            // 공격 중이면 타겟을 향해 이동
            if (enemy.isAttacking)    
                MoveToTarget();
            else
            {
                List<Skill> skill = new List<Skill>();

                // 사용 가능한 스킬을 찾아 리스트에 추가
                for (int i = 0; i < enemy.SkillList.Length; i++)
                {
                    if (enemy.SkillList[i].NowDelay == 0)
                        if (distance <= enemy.SkillList[i].AtkField)
                            skill.Add(enemy.SkillList[i]);
                }

                // 사용 가능한 스킬이 있으면 랜덤으로 선택하여 타겟 공격
                if (skill.Count > 0)
                {
                    int i = Random.Range(0, skill.Count);
                    AttackTarget(skill[i]);
                    skill.Clear();
                }
                else
                    MoveToTarget();
            }
        }
    }

    // 타겟을 향해 이동하는 함수
    void MoveToTarget()
    {
        Vector3 directionToPlayer = target.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.Translate(Vector3.right * enemy.moveSpeed * Time.deltaTime);
    }

    // 타겟을 향해 바라보는 함수
    void FaceTarget()
    {
        // 타겟이 왼쪽에 있으면 스케일을 -1로 설정하여 좌우 반전
        if (target.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // 타겟이 오른쪽에 있으면 스케일을 1로 설정
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // 타겟을 공격하는 함수
    void AttackTarget(Skill nowSkill)
    {

        //평타 스킬 딜레이 공유를 위한 조건 처리
        if (nowSkill.AtkCode == 0)
        {
            Skill friendSkill = enemy.SkillList[nowSkill.AtkCode + 1];
            friendSkill.NowDelay = friendSkill.DelayTime;

        }
        if (nowSkill.AtkCode == 1)
        {
            Skill friendSkill = enemy.SkillList[nowSkill.AtkCode - 1];
            friendSkill.NowDelay = friendSkill.DelayTime;
        }
        nowSkill.NowDelay = nowSkill.DelayTime;

        // 공격 중인 상태로 설정하고 DarkDragon 상태 변경 및 딜레이 충전
        enemy.isAttacking = true;
        dd.SetState(nowSkill.AtkCode);
    }
}
