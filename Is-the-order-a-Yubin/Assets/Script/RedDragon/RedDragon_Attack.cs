using UnityEngine;

public class RedDragon_Attack : MonoBehaviour
{
    public Vector3 startSize = new Vector3(0.1f, 0.1f, 1.0f);
    public Vector3 targetSize = new Vector3(1.0f, 1.0f, 1.0f);

    public Color startColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    public Color targetColor = new Color(1.0f, 0.0f, 0.0f, 0.0f);
    public Color finalColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);

    public float animationDuration = 2.0f;
    public float fadeDuration = 2.0f;
    public float moveSpeed = 4.0f;

    private float elapsedTime = 0.0f;

    private Vector3 originalSize;
    private Color originalColor;

    public GameObject player;
    public GameObject bulletPrefab;

    private bool hasRandomRotation = false;

    private int AtkStyle = 1;

    void Start()
    {
        AtkStyle = FindObjectOfType<RedDragon_Move>().AtkStyle;

        if (AtkStyle == 1)
        {
            startSize = new Vector3(0.3f, 0.3f, 0.3f);
            targetSize = new Vector3(1.3f, 1.3f, 1.3f);
            moveSpeed = 7;

        }
        else if (AtkStyle == 3)
        {
            moveSpeed = 17;
            startSize = new Vector3(1f, 1f, 1f);
            targetSize = new Vector3(2.3f, 2.3f, 2.3f);
        }
        else if (AtkStyle == 4)
        {
            moveSpeed = 10;
            startSize = new Vector3(1f, 1f, 1f);
            targetSize = new Vector3(2f, 2f, 2f);
        }
        else if (AtkStyle == 5)
        {
            moveSpeed = 8;
            startSize = new Vector3(0.5f, 0.5f, 0.5f);
            targetSize = new Vector3(3f, 3f, 3f);
            Color startColor = new Color(0.0f, 0.0f, 1.0f, 0.0f);
            Color targetColor = new Color(0.0f, 0.0f, 1.0f, 0.0f);  // ÆÄ¶õ»ö
        }

        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg);
        else
            Debug.LogWarning("Player not found. Make sure the player has the 'Player' tag.");

        originalSize = new Vector3(0.1f, 0.1f, 1.0f);
        originalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        Invoke("DestroyGameObject", animationDuration + fadeDuration);
    }

    private void Update()
    {
        MoveObject();
        AnimateSize(targetSize);
        AnimateColor(targetColor, finalColor);
    }

    void DestroyGameObject()
    {
        SetObjectSize(targetSize);
        SetObjectColor(finalColor);
        Destroy(gameObject);
    }

    void AnimateSize(Vector3 target)
    {
        elapsedTime += Time.deltaTime;
        SetObjectSize(Vector3.Lerp(originalSize, target, Mathf.Clamp01(elapsedTime / animationDuration)));
    }

    void AnimateColor(Color target, Color final)
    {
        elapsedTime += Time.deltaTime;
        SetObjectColor(Color.Lerp(originalColor, target, Mathf.Clamp01(elapsedTime / fadeDuration)));

        if (elapsedTime >= fadeDuration)
            Destroy(gameObject);
    }

    void MoveObject()
    {
        if (!hasRandomRotation)
        {
            transform.Rotate(Vector3.forward * Random.Range(-6.0f, 6.0f));
            hasRandomRotation = true;
        }

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (bulletPrefab != null)
        {
            GameObject tempObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Rigidbody2D bulletRigidbody = tempObject.GetComponent<Rigidbody2D>();
            if (bulletRigidbody != null)
                bulletRigidbody.velocity = transform.right * moveSpeed;
            else
                Debug.LogWarning("Rigidbody2D not found. Make sure the bullet prefab has a Rigidbody2D component.");
        }
    }

    void SetObjectSize(Vector3 newSize) => transform.localScale = newSize;

    void SetObjectColor(Color newColor)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
            renderer.material.color = newColor;
        else
            Debug.LogWarning("Renderer not found. Make sure the object has a Renderer component.");
    }
}