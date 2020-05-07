using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    private float attackRange = .5f;
    public LayerMask EnemyLayer;
    public int attackDamage = 51;
    public int attackDamage2 = 75;
    public int attackDamage3 = 100;
    private float attackRate = 2f;
    private float nextAttack = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Semicolon) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }

    public void Attack()
    {
        animator.SetTrigger("attack"); //play animation

        //detect enemies, store in array
        Collider2D Enemies = Physics2D.OverlapCircle(attackPoint.position, attackRange, EnemyLayer);

        //damage them
        if(Enemies != null)
        {
            if(Enemies.GetComponent<Enemy>())
            {
                if (Enemies.CompareTag("E_Animal"))
                {
                    Enemies.GetComponent<Enemy>().TakeDamage(attackDamage3);
                }
                if (Enemies.CompareTag("Enemy"))
                {
                    Enemies.GetComponent<Enemy>().TakeDamage(attackDamage2);
                }
            }
            if (Enemies.GetComponent<Boss_Ai>())
            {
                Enemies.GetComponent<Boss_Ai>().TakeDamage(attackDamage); ;
            }
            //Enemies.GetComponent<Boss_Ai>().TakeDamage(attackDamage);
            //TakeDamage(attackDamage);
            Debug.Log("attakc");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

}
