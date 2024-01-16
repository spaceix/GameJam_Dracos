using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirPrf : MonoBehaviour
{
    public float Speed = 10f;
    private void Start()
    {
        Destroy(gameObject, 2f);            //생성으로부터 2초 후 삭제
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (Speed * Time.deltaTime), Space.Self);
    }
}