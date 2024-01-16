using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 분리 규칙
[CreateAssetMenu(menuName = "Boids/Behavior/Separation")]
public class SeparationBehavoior : FilteredBoidsBehavior
{
    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid)
    {
        // 근처에 개체가 없다면 움직이지 않음
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        // 이동 벡터
        Vector2 separationMove = Vector2.zero;

        // 근처에 있는 개체의 수
        int nSeparation = 0;

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        // 주변 개체들을 검사하여 행동 적용
        foreach (Transform i in filteredContext)
        {
            if (Vector2.SqrMagnitude(i.position - agent.transform.position) < boid.SquareAvoidanceRadius)
            {
                nSeparation++;
                separationMove += (Vector2)(agent.transform.position - i.position);
            }
        }

        // 근처에 개체가 존재하면 이동 벡터를 근처 개체의 평균 방향으로 조정
        if (nSeparation > 0)
        {
            separationMove /= nSeparation;
        }

        // 이동 벡터 반환
        return separationMove;
    }
}
