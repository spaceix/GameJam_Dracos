using UnityEngine;

public class PlayerTest: MonoBehaviour
{
    public float speed = 5f; // 플레이어 이동 속도

    void Update()
    {
        // 키 입력을 감지하여 이동
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 이동 방향 계산
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize(); // 대각선 이동 속도 보정

        // 플레이어 이동
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
