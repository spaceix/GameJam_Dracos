using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public enum DarkDragonState
{
    Idle = 0,       //¥Î±‚
    TailAttack,     //≤ø∏Æ∆Ú≈∏
    ClawsAttack,    //πﬂ≈È∆Ú≈∏
    FireCircle,     //ø¯«¸∫“
    EattingMob,     //∏‘¿Ã ≤¯æÓ¥Á±‚±‚
    CircleShoot,    //ø¯«¸»≠ø∞±∏
    FanShoot        //∫Œ√§≤√»≠ø∞±∏
}
public class DarkDragon : MonoBehaviour
{
    public GameObject prfFire;
    public Transform target;
    Vector3 whereToAtk;
    Vector3 playerPos;
    Enemy enemy;

    private DarkDragonState dragonState;

    // Start is called before the first frame update
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        ChangeState(DarkDragonState.Idle);
    }

    public void SetState(int num)
    {
        switch (num)
        {
            case 0: ChangeState(DarkDragonState.Idle); break;
            case 1: ChangeState(DarkDragonState.TailAttack); break;
            case 2: ChangeState(DarkDragonState.ClawsAttack); break;
            case 3: ChangeState(DarkDragonState.FireCircle); break;
            case 4: ChangeState(DarkDragonState.EattingMob); break;
            case 5: ChangeState(DarkDragonState.CircleShoot); break;
            case 6: ChangeState(DarkDragonState.FanShoot); break;
            default: break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void ChangeState(DarkDragonState newState)
    {
        StopCoroutine(dragonState.ToString());
        dragonState = newState;
        StartCoroutine(dragonState.ToString());
    }

    private IEnumerator Idle()
    {
        Debug.Log("∫Ò¿¸≈ı∏µÂ");

        while (true)
        {
            yield return null;
        }
    }
    private IEnumerator TailAttack()
    {
        int i = 0;
        Debug.Log("≤ø∏Æ∆Ú≈∏");

        while (i < 0)
        {
            Debug.Log("Ωÿæ◊");
        }

        enemy.isAttaking = false;

        ChangeState(DarkDragonState.Idle);
        yield return null;
    }

    private IEnumerator ClawsAttack()
    {
        int i = 0;
        Debug.Log("πﬂ≈È∆Ú≈∏");

        while (i < 0)
        {
            Debug.Log("ƒ·");
        }

        enemy.isAttaking = false;

        yield return null;
        ChangeState(DarkDragonState.Idle);
    }

    private IEnumerator FireCircle()
    {
        int i = 0;
        Debug.Log("»≠ø∞");

        while (i < 3)
        {
            i++;
            Debug.Log("∂—Ω√∂—Ω√");
            yield return new WaitForSeconds(1);
        }
        enemy.isAttaking = false;
        ChangeState(DarkDragonState.Idle);
    }

    private IEnumerator EattingMob()
    {
        int i = 0;
        Debug.Log("∏‘¿Ã≤¯æÓ¥Á±‚±‚");

        while (i < 3)
        {
            i++;
            Debug.Log("ƒÌøÕæ∆æ”");
            yield return new WaitForSeconds(1);
        }
        enemy.isAttaking = false;
        ChangeState(DarkDragonState.Idle);
    }

    private IEnumerator CircleShoot()
    {
        int i = 0;
        Debug.Log("ø¯«¸»≠ø∞±∏");

        while (i < 3)
        {
            i++;
            Circleshoot();
            Debug.Log("≈‰µµµµµæ");
            yield return new WaitForSeconds(1);
        }
        enemy.isAttaking = false;
        ChangeState(DarkDragonState.Idle);
    }

    private IEnumerator FanShoot()
    {
        int i = 0;
        Debug.Log("∫Œ√§≤√»≠ø∞±∏");

        while (i < 3)
        {
            i++;
            Fanshoot();
            Debug.Log("ΩπΩπΩπΩπ");
            yield return new WaitForSeconds(1);
        }
        enemy.isAttaking = false;
        ChangeState(DarkDragonState.Idle);
    }

    public Transform Target;

    private void Circleshoot()
    {
        //360π¯ π›∫π
        for (int i = 0; i < 360; i += 13)
        {
            GameObject temp = Instantiate(prfFire);
            Destroy(temp, 2f);
            temp.transform.position = transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    private void Fanshoot()
    {
        Vector3 vec = transform.rotation.eulerAngles;
        for (int i = 0; i < 60; i += 10)
        {
            GameObject temp = Instantiate(prfFire);
            Destroy(temp, 2f);
            temp.transform.position = transform.position;
            temp.transform.Rotate(new Vector3(vec.x, vec.y, vec.z - 30 + i));
        }
    }

}
