using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeAttack : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float angle = 10f;
    public Vector3 startSize = new Vector3(1f, 1f, 1f);
    public Vector3 targetSize = new Vector3(1.5f, 1.5f, 1.5f);

    public Color startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    public Color targetColor = new Color(1.0f, 0.0f, 0.0f, 0.0f);
    public float animationDuration = 2.0f;
    public float fadeDuration = 2.0f;

    private float elapsedTime = 0.0f;
    private Vector3 originalSize;
    private Color originalColor;

    private float attackAngle;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        attackAngle = Random.Range(-angle, angle);
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
