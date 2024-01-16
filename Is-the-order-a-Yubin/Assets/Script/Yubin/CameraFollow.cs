using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f; // 카메라 이동 속도

    void LateUpdate()
    {
        if (target != null)
        {
            // 플레이어의 현재 위치
            Vector3 desiredPosition = target.position;


            // 현재 카메라의 위치에서 플레이어의 위치로 부드럽게 이동
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // 카메라 위치 업데이트
            transform.position = smoothedPosition;
        }
    }
}
