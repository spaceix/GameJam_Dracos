using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    public float speed = 20;

    Rigidbody rigidbody;
    Vector3 movement;

    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1;
    public bool attacked = false;
    public Image nowHpbar;

    float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fire")
        {
            nowHp -= 5;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        if (timer > 0.25f)
        {
            if (collision.tag == "filed")
                nowHp -= 1;
            timer = 0;
        }
    }

    void Start()
    {
        maxHp = 50;
        nowHp = 50;
        atkDmg = 30;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.up * Time.deltaTime * speed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.up * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - transform.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            attacked = true;
        }
    }
}
