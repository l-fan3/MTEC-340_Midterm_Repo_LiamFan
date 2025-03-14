using System;
using UnityEngine;

public class MBS_PlayerAttack : MonoBehaviour
{
    public float AttackRange = 5.0f;
    public int AttackDamage = 10;
    public LayerMask EnemyLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click once per attack
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Swing the Axe!");

        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, AttackRange, EnemyLayer);

        // Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<MBS_EnemyHealth>()?.TakeDamage(AttackDamage); 
        }
    }

    // Draw the attack radius in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}