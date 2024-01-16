using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Behavior/Alignment")]
// 정렬 규칙
public class AlignmentBehavior : FilteredBoidsBehavior
{
    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid)
    {
        // 주변에 개체가 없으면 그대로 이동하
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        // 이동 벡터
        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);

        // 주변에 있는 개체들의 위치를 누적
        foreach (Transform i in filteredContext)
        {
            alignmentMove += (Vector2)i.transform.up;
        }

        // 주변 개체들의 평균 방향 계산
        alignmentMove /= context.Count;

        // 이동 벡터 반환
        return alignmentMove;
    }
}
