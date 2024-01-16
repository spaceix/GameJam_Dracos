using System.Collections;
using UnityEngine;

public class RedDragon_Move : MonoBehaviour
{
    public Transform Player;
    public float speed = 1;
    public float stoppingDistance = 0.3f;
    public GameObject flamePrefab;

    public int AtkStyle = 1;

    private bool isAttacking = false;

    void Update()
    {
        if (Player != null)
        {
            Vector3 directionToPlayer = Player.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

            // Check if the distance is less than or equal to 5 and isAttacking
            if (distanceToPlayer <= 6.5 && !isAttacking)
            {
                StartCoroutine(AttackMultipleTimes(Random.Range(10, 300), 0.02f));
            }

            if (distanceToPlayer > stoppingDistance && !isAttacking)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogWarning("Player reference is null. Assign a player to the RedDragon_Move script in the Inspector.");
        }
    }

    IEnumerator AttackMultipleTimes(int count, float interval)
    {
        isAttacking = true;

        AtkStyle = Random.Range(1, 101);
        if (AtkStyle >= 1 && AtkStyle <= 30)
        {
            AtkStyle = 1;
        }
        else if (AtkStyle <= 60)
        {
            AtkStyle = 2;
        }
        else if (AtkStyle <= 75)
        {
            AtkStyle = 3;
        }
        else if (AtkStyle <= 90)
        {
            AtkStyle = 4;
        }
        else
        {
            AtkStyle = 5;
        }
           

        for (int i = 0; i < count; i++)
        {
            Attack();
            yield return new WaitForSeconds(interval);
        }
        isAttacking = false;
    }

    void Attack()
    {
       
        if (flamePrefab != null)
        {
            Instantiate(flamePrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Flame Prefab is not assigned. Assign a prefab to the RedDragon_Move script in the Inspector.");
        }
    }
}
