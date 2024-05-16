using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public GameObject explosion;

    public float playerRange = 10f;

    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    public bool doesEnemyShoot;
    public float fireRate = 0.5f;
    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;

    public int meeleeDamage = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            rb.velocity = playerDirection.normalized * moveSpeed;

            if(doesEnemyShoot )
            {
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerController.instance.TakeDamage(meeleeDamage);
        }
        Debug.Log("collider triggered");
    }

    public void TakeDamage()
    {
        health--;
        if(health <= 0 )
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
