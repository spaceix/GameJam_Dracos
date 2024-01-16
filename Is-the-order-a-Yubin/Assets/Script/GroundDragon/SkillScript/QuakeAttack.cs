using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class QuackAttack : MonoBehaviour
{
    public GameObject quakePrefab; // �տ� Prefab

    public float skillInterval = 2f; // ��Ÿ�� ���� (��)
    private float skillTimer = 0f; // ��Ÿ�� Ÿ�̸�

    // Start is called before the first frame update
    void Start()
    {
        skillTimer += Time.deltaTime;

        if (skillTimer >= skillInterval)
        {
            Destroy(gameObject);
            skillTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
