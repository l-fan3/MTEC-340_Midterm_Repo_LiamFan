using System;
using UnityEngine;

public class MBS_PlayerAttack : MonoBehaviour
{
    public float AttackRange = 3.0f;
    public int AttackDamage = 10;
    public LayerMask EnemyLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //play attack animation
        Debug.Log("Swing the Axe!");
        //detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, AttackRange, EnemyLayer);
    
        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(AttackDamage); 
        }
    
    }

}
