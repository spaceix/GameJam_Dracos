using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustGeneration : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float angle = 20f;

    private float attackAngle;

    public Vector3 startSize = new Vector3(1f, 1f, 1f);
    public Vector3 targetSize = new Vector3(1.5f, 1.5f, 1.5f);

    public Color startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    public Color targetColor = new Color(1.0f, 0.0f, 0.0f, 0.0f);

    public float animationDuration = 2.0f;
    public float fadeDuration = 2.0f;

    private float elapsedTime = 0.0f;
    private Vector3 originalSize;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        // prefab을 시간에 맞게 지운다
        Destroy(gameObject, lifeTime);

        // 발사체 무작위 각도 설정
        attackAngle = Random.Range(-angle, angle);

        // 색 바꾸기
        originalColor = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        float z = transform.rotation.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad + attackAngle), Mathf.Sin(z * Mathf.Deg2Rad + attackAngle));
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        AnimateColor();
        AnimateSize(targetSize);
    }

    void AnimateColor()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / fadeDuration);
        Color newColor = Color.Lerp(originalColor, targetColor, t);
        SetObjectColor(newColor);
    }

    void AnimateSize(Vector3 target)
    {
        elapsedTime += Time.deltaTime;
        SetObjectSize(Vector3.Lerp(originalSize, target, Mathf.Clamp01(elapsedTime / animationDuration)));
    }
    void SetObjectSize(Vector3 newSize) => transform.localScale = newSize;

    void SetObjectColor(Color newColor)
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = newColor;
        }
        else
        {
            Debug.LogWarning("Renderer not found. Make sure the object has a Renderer component.");
        }
    }
}
