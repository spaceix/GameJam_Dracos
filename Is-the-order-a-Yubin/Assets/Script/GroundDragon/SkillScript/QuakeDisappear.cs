using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeDisappear : MonoBehaviour
{
    public float lifeTime;
    private float lifeTimeR;
    private CircleCollider2D circleCollider2D;

    void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // prefab을 시간에 맞게 지운다
        Destroy(gameObject, lifeTime);
        lifeTimeR += Time.deltaTime;

        if (lifeTimeR >= lifeTime - 1)
        {
            circleCollider2D.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
