using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public float speed;
    public float lifeTime = 20f;
    public float angle = 20f;

    public float nomalStopTime = 2f;
    private float stopTimer = 0f;

    private bool move = true;
    private float attackAngle;

    public GameObject skillRangePrefab;

    private Rigidbody2D rigid2D;
    private CapsuleCollider2D capsuleCollider2D;

    // Start is called before the first frame update
    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    void Start()
    {
        // prefab�� �ð��� �°� �����
        Destroy(gameObject, lifeTime);
        // �߻�ü ������ ���� ����
        attackAngle = Random.Range(-angle, angle);
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾� �������� �߻�ü �߻�
        if (move)
        {
            float z = transform.rotation.eulerAngles.z;
            Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad + attackAngle), Mathf.Sin(z * Mathf.Deg2Rad + attackAngle));
            rigid2D.velocity = direction * speed;
            capsuleCollider2D.enabled = false;
        }

        stopTimer += Time.deltaTime;
        if (stopTimer >= nomalStopTime)
        {
            if (move)
            {
                Instantiate(skillRangePrefab, transform.position, Quaternion.identity);
                rigid2D.velocity = Vector2.zero;
                rigid2D.constraints = RigidbodyConstraints2D.FreezeAll;
                capsuleCollider2D.enabled = true;
                move = false;
            }
            stopTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }
}
