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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fire")
        {
            nowHp -= 5;
            Destroy(collision.gameObject);
        }
    }

    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }
    void SetAttackSpeed(float speed)
    {
        //animator.SetFloat("attackSpeed", speed);
        atkSpeed = speed;
    }

    void Start()
    {
        maxHp = 50;
        nowHp = 50;
        atkDmg = 30;
        //animator = GetComponent<Animator>;
        SetAttackSpeed(1.5f);
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
            AttackTrue();
        }
    }
}
