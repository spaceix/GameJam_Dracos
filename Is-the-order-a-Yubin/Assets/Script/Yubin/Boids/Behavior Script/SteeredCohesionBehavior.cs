using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 결합 규칙
[CreateAssetMenu(menuName = "Boids/Behavior/SteeredCohesion")]
public class SteeredCohesionBehavior : FilteredBoidsBehavior
{
    // 기존 이동 방향
    Vector2 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid)
    {
        // 근처에 개체가 없다면 움직이지 않음
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        // 이동 벡터
        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);

        // 주변에 있는 개체들의 위치를 누적
        foreach (Transform i in filteredContext)
        {
            cohesionMove += (Vector2)i.position;
        }

        // 주변 개체들의 평균 위치
        cohesionMove /= context.Count;

        // 평균 위치로 이동
        cohesionMove -= (Vector2)agent.transform.position;

        // 부드러운 이동을 적용하여 현재 이동 방향을 새로운 이동 방향으로 조정
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);

        // 이동 벡터 반환
        return cohesionMove;
    }
}
