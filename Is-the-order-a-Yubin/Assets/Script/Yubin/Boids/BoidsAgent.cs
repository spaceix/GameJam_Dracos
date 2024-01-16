using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BoidsAgent : MonoBehaviour
{

    Boids agentBoid;
    public Boids AgentBoid {  get { return agentBoid; } }
    Collider2D boidCollider;
    public Collider2D BoidCollider { get { return boidCollider; } }

    private void Start()
    {
        boidCollider = GetComponent<Collider2D>();
    }

    public void Initalize(Boids boid)
    {
        agentBoid = boid;
    }

    // Move()는 Boid 개체를 주어진 속도로 이동시키는 메서드
    // Parameters:
    // - velocity: Boid 개체가 이동할 방향과 속도를 나타내는 벡터
    public void Move(Vector2 velocity)
    {
        // 개체의 방향을 velocity로 설정
        transform.up = velocity;

        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
