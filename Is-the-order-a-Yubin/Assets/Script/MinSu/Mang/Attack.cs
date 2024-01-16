using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullte;
    public Transform sPoint;
    public float timeBetweenShots;

    private float shotTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        Quaternion rotation=Quaternion.AngleAxis(angle-90,Vector3.forward);
        transform.rotation = rotation;

        if(Input.GetMouseButtonDown(0))
        {
            if(Time.time > shotTime)
            {
                Instantiate(bullte,sPoint.position,Quaternion.AngleAxis(angle-90,Vector3.forward));
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }
}
