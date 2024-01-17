using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StoneShot : MonoBehaviour
{
<<<<<<<< HEAD:Is-the-order-a-Yubin/Assets/Script/GroundDragon/GroundSkill/StoneShot.cs
    public float speed = 10f;
    public float lifeTime = 2f;
========
    public float speed;
    public float lifeTime;
>>>>>>>> d302fb68edf0d2107bedb8c7c7bae3cc6dafa30f:Is-the-order-a-Yubin/Assets/Script/GroundDragon/SkillScript/StoneShot.cs
    // Start is called before the first frame update
    void Start()
    {
        // prefab을 시간에 맞게 지운다
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어 방향으로 발사체 발사
        float z = transform.rotation.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
