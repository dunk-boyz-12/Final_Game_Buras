using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public Transform Player;
    private readonly int maxHealth = 100;
    public int currHealth;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currHealth -= damage;
        animator.SetTrigger("takeDamage");
        if(currHealth <= 1)
        {
            Die();
        }
        animator.SetBool("isDead", true);
    }

    void Die()
    {
        //play animation & disable enemy
        animator.SetBool("isDead",true);
        Destroy(gameObject);
    }

}
