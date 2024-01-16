using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Behavior/Stay In Radius")]
public class StayInRadiusBehavior : BoidsBehavior
{
    // 중심 위치
    public Vector2 center;

    // 반경
    public float radius = 15;

    // Boids 개체의 이동을 계산
    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids flock)
    {
        // 중심 위치와 객체의 현재 위치 간의 거리 벡터 계산
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        
        // 거리 비율 계산
        float t = centerOffset.magnitude / radius;

        // 거리 비율이 0.9보다 작으면 정지 상태로 반환
        if (t < 0.9f)
        {
            return Vector2.zero;
        }

        // 거리 비율의 제곱에 비례하여 중심 방향으로 이동하는 벡터 반환
        return centerOffset * t * t;
    }
}
