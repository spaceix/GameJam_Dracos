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
        // prefab을 시간에 맞게 지운다
        Destroy(gameObject, lifeTime);

        // 발사체 무작위 각도 설정
        attackAngle = Random.Range(-angle, angle);

        // 플레이어 방향으로 발사체 발사
        float z = transform.rotation.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
