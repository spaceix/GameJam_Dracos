using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StoneShot : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        // prefab�� �ð��� �°� �����
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾� �������� �߻�ü �߻�
        float z = transform.rotation.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
