using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public int obstacleCount = 5;
    public float minX = -15f;
    public float maxX = 15f;
    public float minY = -5f;
    public float maxY = 5f;
    public GameObject obstaclePrefab;

    void Start()
    {
        GenerateObstacles();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(maxX, minY, 0));
        Gizmos.DrawLine(new Vector3(maxX, minY, 0), new Vector3(maxX, maxY, 0));
        Gizmos.DrawLine(new Vector3(maxX, maxY, 0), new Vector3(minX, maxY, 0));
        Gizmos.DrawLine(new Vector3(minX, maxY, 0), new Vector3(minX, minY, 0));
    }

    void GenerateObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            GameObject obstacle = Instantiate(obstaclePrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
            obstacle.name = "Obstacle" + i;

            obstacle.transform.parent = transform;
        }
    }
}
