using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    public float startSpeed = 10f;

    public float health = 100;

    public int worth = 50;

    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            Perish();
        }
    }

    public void Slow(float percent)
    {
        speed = startSpeed * (1f - percent);
    }

    void Perish()
    {
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
    
        Destroy(gameObject);
    }

    
}
