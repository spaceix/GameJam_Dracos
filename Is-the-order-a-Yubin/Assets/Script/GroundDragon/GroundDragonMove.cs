using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundDragonMove : MonoBehaviour
{
    public Transform Player;
    public float speed = 1;
    public double stoppingDistance = 3;
    public GroundDragonAttack groundDragonAttack;
    void Start()
    {
        GetComponent<GroundDragonAttack>();
    }
    void Update()
    {
        if (Player != null)
        {
            // 플레이어 방향으로 회전
            Vector2 newPos = Player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            // 플레이어와의 거리 계산
            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

            // 정지 거리보다 멀리 있고 공격 중이 아닌 경우에만 이동
            if (distanceToPlayer > stoppingDistance && !groundDragonAttack.isAttacking)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogWarning("Player reference is null. Assign a player to the GroundDragonMove script in the Inspector.");
        }
    }
}

