using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float angle = 10f;

    private float attackAngle;
    // Start is called before the first frame update
    void Start()
    {
        // prefab�� �ð��� �°� �����
        Destroy(gameObject, lifeTime);

        // �߻�ü ������ ���� ����
        attackAngle = Random.Range(-angle, angle);

        // �÷��̾� �������� �߻�ü �߻�
        float z = transform.rotation.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
