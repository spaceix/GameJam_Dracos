using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float speed = 5f; // 이동 속도
    public float maxX = 5f;  // 최대 x
    public float minX = -5f; // 최소 x
    public float maxY = 5f;  // 최대 y
    public float minY = -5f; // 최소 y

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize();

        float clampedX = Mathf.Clamp(transform.position.x + movement.x * speed * Time.deltaTime, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y + movement.y * speed * Time.deltaTime, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector3(minX, minY, 0f), new Vector3(minX, maxY, 0f));
        Gizmos.DrawLine(new Vector3(minX, maxY, 0f), new Vector3(maxX, maxY, 0f));
        Gizmos.DrawLine(new Vector3(maxX, maxY, 0f), new Vector3(maxX, minY, 0f));
        Gizmos.DrawLine(new Vector3(maxX, minY, 0f), new Vector3(minX, minY, 0f));
    }
}
