using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] int health = 3;
    bool alreadyDead;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage = 0)
    {
        animator.SetTrigger("Hit");

        health -= damage;

        if (health <= 0 && !alreadyDead)
        {
            alreadyDead = true;
            StartCoroutine(Die());
            animator.SetTrigger("Die");
        }
    }

    IEnumerator Die ()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerBullet")) health -= 1;
    }
}
