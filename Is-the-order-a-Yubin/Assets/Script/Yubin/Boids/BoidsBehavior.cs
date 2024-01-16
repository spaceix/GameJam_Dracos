using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BoidsBehavior 추상 클래스
public abstract class BoidsBehavior : ScriptableObject
{
    // CalculateMove() 각 개체가 어떻게 움직일지 계산하는 추상 메서드
    //Parameters:
    // - agent: 현재 Boids 객체
    // - context: 주변 개체의 Transform 목록
    // - boid: Boids에 속하는 객체
    // Returns:
    // - 다음 프레임에 이동할 방향을 나타내는 벡터
    public abstract Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid);
}
