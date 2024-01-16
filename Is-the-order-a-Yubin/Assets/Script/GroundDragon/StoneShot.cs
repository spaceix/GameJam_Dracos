using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneShot : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float angle = 10f;

    private float attackAngle;
    // Start is called before the first frame update
    void Start()
    {
        // 돌을 시간에 맞게 지운다
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        float z = transform.rotation.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
