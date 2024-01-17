using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class QuackAttack : MonoBehaviour
{
    public GameObject quakePrefab; // �տ� Prefab

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
            Instantiate(quakePrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
            skillTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }
}
