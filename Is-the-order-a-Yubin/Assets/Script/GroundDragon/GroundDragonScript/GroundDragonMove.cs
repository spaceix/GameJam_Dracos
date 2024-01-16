using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundDragonMove : MonoBehaviour
{
    public GameObject Player;
    public float speed = 1;
    public double stoppingDistance = 3;

    private GroundDragonAttack groundDragonAttack;
    void Start()
    {
        groundDragonAttack = GetComponent<GroundDragonAttack>();
    }
    void Update()
    {
        if (Player != null)
        {
            // �÷��̾� �������� ȸ��
            Vector2 newPos = Player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            // �÷��̾���� �Ÿ� ���
            float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

            // ���� �Ÿ����� �ָ� �ְ� ���� ���� �ƴ� ��쿡�� �̵�
            if (distanceToPlayer > stoppingDistance && !groundDragonAttack.isAttacking)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
}

