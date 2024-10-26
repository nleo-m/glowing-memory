using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 0.25f, maxDistanceRatio = 15;
    Animator animator;

    float startPosX;
    (float min, float max) distance;
    bool hit = false;

    void Start()
    {
        startPosX = transform.position.x;
        distance = (startPosX - maxDistanceRatio, startPosX + maxDistanceRatio);

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (hit == false) transform.Translate(speed * Time.deltaTime, 0, 0);

        if (transform.position.x >= distance.max || transform.position.x <= distance.min) Destroy(gameObject);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.CompareTag("Player");

        if (isPlayer == false) {
            hit = true;
            animator.SetTrigger("Hit");
            StartCoroutine(destroy());
        }

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(1);
        }
    }

    IEnumerator destroy ()
    {
        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }
}
