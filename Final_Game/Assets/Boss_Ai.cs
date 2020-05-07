using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Boss_Ai : MonoBehaviour
{
    public Rigidbody2D boss;
    public Transform Player;
    private readonly float followSpeed = 3f;
    private int maxHealth = 100;
    public int currHealth;
    private float patrolRange = 5f;
    private float attackRange = 2f;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform; //find player position
        boss = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (math.abs(Player.transform.position.x - boss.transform.position.x) < 5 || math.abs(Player.transform.position.y - boss.transform.position.y) < 5)
        {
            Vector2 targPos = new Vector2(Player.position.x, boss.position.y);
            Vector2 newPos = Vector2.MoveTowards(boss.position, Player.position, followSpeed * Time.deltaTime);
            boss.MovePosition(newPos);
        }
        //to flip boss facing direction
        if ((Player.transform.position.x - boss.transform.position.x) < 0)
        {
            boss.transform.eulerAngles = new Vector2(0, 180);
        }
        if ((Player.transform.position.x - boss.transform.position.x) > 0)
        {
            boss.transform.eulerAngles = new Vector2(0, 0);
        }
        //to trigger attack animation
        if (Vector2.Distance(Player.position, boss.position) < attackRange)
        {
            boss.GetComponent<Animator>().SetBool("isAttacking",true);
        }
        if (Vector2.Distance(Player.position, boss.position) > attackRange)
        {
            boss.GetComponent<Animator>().SetBool("isAttacking", false);
        }
        if(currHealth <= 1)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        boss.GetComponent<Animator>().SetTrigger("takeDamage");
        currHealth -= damage;
        if(currHealth <= 1)
        {
            Die();
        }
        boss.GetComponent<Animator>().SetBool("isDead", false);
    }

    void Die()
    {
        boss.GetComponent<Animator>().SetBool("isDead", true);
        Destroy(gameObject);
    }
}
