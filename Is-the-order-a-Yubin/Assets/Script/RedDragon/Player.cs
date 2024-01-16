using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public int PlayerHP = 1000;

    // 추가: 감지할 프리팹을 Inspector에서 설정
    public GameObject prefabToDetect;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    // 추가: 충돌 감지
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == prefabToDetect)
        {
            // 특정 프리팹과 충돌했을 때 실행할 코드
            Debug.Log("프리팹에 닿았습니다!");

            // 추가: HP 감소 및 디버그 출력
            PlayerHP -= 1;
            Debug.Log("플레이어 HP: " + PlayerHP);

            // 추가: HP가 0이하로 떨어졌을 때의 처리
            if (PlayerHP <= 0f)
            {
                Debug.Log("플레이어가 사망했습니다!");
                // 원하는 사망 처리를 여기에 추가
            }
        }
    }
}
