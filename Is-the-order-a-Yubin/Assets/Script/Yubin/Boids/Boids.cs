using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class Boids : MonoBehaviour
{
    // Boid 개체의 프리팹
    public BoidsAgent boidPrefab;

    // Boid 개체 리스트
    List<BoidsAgent> agents = new List<BoidsAgent>();

    // Boid 개체의 행동을 관리하는 스크립터블 오브젝트
    public BoidsBehavior behavior;

    // Boid 개체의 개수 설정
    [Range(10, 10000)]
    public int numberOfBoid = 250;

    // Boid 개체의 생성 밀도 설정
    public float AgentDensity = 0.08f;

    // 생성 범위
    public float spawnRadius = 10f;

    // Boid 개체의 이동 방향에 곱해지는 이동 계수
    [Range(1f, 100f)]
    public float driveFactor = 10f;

    // Boid 개체의 최대 이동 속도
    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    // 다른 Boids 개체를 감지하는 범위
    [Range(1f, 10f)]
    public float neighborRadius = 0.01f;

    // 다른 Boid 개체 회피 반경
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    // 제곱된 값들
    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    private void Start()
    {

        // 제곱 미리 계산
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        // 개체 생성 및 리스트에 추가
        for (int i = 0; i < numberOfBoid; i++)
        {
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle.normalized * Random.Range(0f, spawnRadius);
            BoidsAgent newAgent = Instantiate(boidPrefab, randomPosition, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
            newAgent.name = "Agent " + i;
            newAgent.Initalize(this);
            agents.Add(newAgent);
        }
    }
    private void Update()
    {
        // 각 개체의 주변을 확인
        foreach (BoidsAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

            // 행동 계산 behavior.CalculateMove() 매서드 사용
            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;

            // 속도 제한
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }

            // 이동
            agent.Move(move);
        }
    }

    // 주변 Boid 개체들을 리스트로 반환하는 메서드
    List<Transform> GetNearbyObjects(BoidsAgent agent)
    {
        List<Transform> context = new List<Transform>();

        // 주변에 있는 Boid 개체 감지
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);

        // 자기 자신의 Collider를 제외한 주변 객체들을 리스트에 추가
        foreach (Collider2D c in contextColliders)
        {
            if (c != agent.BoidCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }

    // 기즈모로 생성 범위 그리기
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.7f, 0.5f, 0.7f, 1.0f);
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
