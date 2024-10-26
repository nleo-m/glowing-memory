using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] [Range(0,5)] float cooldown;
    [SerializeField] GameObject shooter;
    Coroutine cooldownCoroutine;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetButton("Fire1")) 
            if (cooldownCoroutine == null) Shoot();
    }

    void Shoot () {
        float isFacingRight = Mathf.Sign(shooter.transform.localScale.x);
        int zRotation = isFacingRight == 1 ? 0 : -180;

        Instantiate(bullet, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, zRotation, 0f));
        cooldownCoroutine = StartCoroutine(clearCooldown());
    }

    IEnumerator clearCooldown ()
    {
        yield return new WaitForSeconds(cooldown);
        cooldownCoroutine = null;
    }
}
