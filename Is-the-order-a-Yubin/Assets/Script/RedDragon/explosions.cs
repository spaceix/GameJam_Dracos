using System.Collections;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    public GameObject explosionPrefab; // Inspector에서 프리팹을 할당하세요.

    private int AtkStyle = 1;

    private Transform playerTransform;

    void Start()
    {
        StartCoroutine(SpawnExplosions());
    }

    IEnumerator SpawnExplosions()
    {
        while (true)
        {
            Debug.Log("SpawnExplosions()");
            yield return new WaitForSeconds(1f);

            AtkStyle = FindObjectOfType<RedDragon_Move>().AtkStyle;
            if (AtkStyle == 2)
            {
                // 플레이어의 현재 위치를 가져옵니다.
                playerTransform = FindObjectOfType<RedDragon_Move>().Player;

                if (playerTransform != null)
                {
                    Debug.Log("Player Transform is not null.");
                    // 주변에 폭발 애니메이션을 생성합니다.
                    yield return StartCoroutine(SpawnExplosionsInSquareRegion(3, 3f)); // 3개의 폭발을 상하좌우 10의 영역으로 생성합니다.
                }
                else
                {
                    Debug.LogWarning("Player Transform is null. Make sure the RedDragon_Move script has a valid reference to the player.");
                }
            }
        }
    }

    // 상하좌우 영역 내에서 지정된 수만큼 폭발 애니메이션을 생성하는 메서드입니다.
    IEnumerator SpawnExplosionsInSquareRegion(int count, float regionSize)
    {
        for (int i = 0; i < count; i++)
        {
            // 랜덤한 X와 Y 오프셋을 계산합니다.
            float xOffset = Random.Range(-regionSize, regionSize);
            float yOffset = Random.Range(-regionSize, regionSize);

            // X와 Y 오프셋을 플레이어의 위치에 적용합니다.
            Vector3 spawnPosition = new Vector3(xOffset, yOffset, 0f) + playerTransform.position;

            // 폭발 애니메이션을 생성합니다.
            GameObject explosion = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);

            // 폭발 애니메이션에 Animator 컴포넌트가 있다면 애니메이션을 재생합니다.
            Animator animator = explosion.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("PlayAnimationTrigger");
            }

            // 기다립니다.
            yield return new WaitForSeconds(1.0f); // 필요에 따라 시간을 조정하세요.

            // 생성된 폭발 애니메이션을 파괴합니다.
            Destroy(explosion);
        }
    }
}
