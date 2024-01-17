using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DustAttack : MonoBehaviour
{
    public GameObject dustPrefab; // ���� Prefab

    private float skillInterval = 2f; // ��Ÿ�� ���� (��)
    private float skillTimer = 0f; // ��Ÿ�� Ÿ�̸�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        skillTimer += Time.deltaTime;

        if (skillTimer >= skillInterval)
        {
            for (int i = 0; i < 30; i++)
                Instantiate(dustPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
            skillTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }
}
