using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Behavior/Composite")]
// 행동 조합
public class CompositeBehavior : BoidsBehavior
{
    // 행동들의 배열
    public BoidsBehavior[] behaviors;

    // 각 행동에 대한 가중치 배열
    public float[] weights;

    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid)
    {
        // 가중치 배열와 행동 배열의 길이가 일치하지 않으면 오류, 빈 벡터 반환
        if (weights.Length != behaviors.Length)
        {
            Debug.LogError("가중치 배열과 행동 배열의 길이가 다름" + name, this);
            return Vector2.zero;
        }

        // 최종 이동 벡터
        Vector2 move = Vector2.zero;

        // 각 행동에 대한 가중치를 곱하여 부분 이동 벡터 계산
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partialMove = behaviors[i].CalculateMove(agent, context, boid) * weights[i];

            if (partialMove != Vector2.zero)
            {
                // 부분 이동 벡터의 제곱 길이가 가중치의 제곱보다 큰 경우에는 백터의 크기 조절
                if (partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    // partialMove의 방향을 유지하며 크기를 1로 조정
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }

                // 최종 이동 벡터에 부분 이동 벡터 더하기
                move += partialMove;
            }
        }
        // 최종 이동 벡터 반환
        return move;
    }
}
