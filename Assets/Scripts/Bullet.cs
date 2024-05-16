using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;

    public float bulletSpeed = 5f;

    private Rigidbody2D rb;

    private Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;
    }
    private void Update()
    {
        rb.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerController.instance.TakeDamage(damage);
            
            Destroy(gameObject);
        }
    }
}
