using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour
{
    public BulletData bulletData;

    //Variable for the bullets
    public float bulletSpeed = 10;
    public int bulletDamage = 25;
    public float maxDistance = 19;
    //References
    public Vector2 startPosition;
    private float conqueredDistance = 0;
    private Rigidbody2D rb2d;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rb2d.velocity = transform.up * this.bulletData.speed;
    }

    private void Update()
    {
        conqueredDistance = Vector2.Distance(transform.position, startPosition);
        if (conqueredDistance > bulletData.maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided" + collision.name);

        var damagable = collision.GetComponent<Damageable>();
        if (damagable != null)
        {
            damagable.Hit(bulletDamage);
        }


        DisableObject();
    }
}
