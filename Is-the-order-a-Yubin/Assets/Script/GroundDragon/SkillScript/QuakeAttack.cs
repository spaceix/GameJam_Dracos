using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class QuackAttack : MonoBehaviour
{
    public GameObject quakePrefab; // 균열 Prefab

    private float skillInterval = 2f; // 쿨타임 간격 (초)
    private float skillTimer = 0f; // 쿨타임 타이머

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
            skillTimer = 0f; // 타이머 초기화
        }
    }
}
