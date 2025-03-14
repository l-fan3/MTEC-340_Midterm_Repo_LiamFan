using UnityEngine;

public class MBS_EnemyAttack : MonoBehaviour
{
    public float AttackRange = 2.0f;
    public int AttackDamage = 5;
    public float AttackCooldown = 1.5f; // Delay between attacks
    private float _lastAttackTime;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find player by tag
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distance to player: " + distanceToPlayer); // Add this line for debugging

        if (distanceToPlayer <= AttackRange && Time.time >= _lastAttackTime + AttackCooldown)
        {
            Attack();
            _lastAttackTime = Time.time;
        }
    }


    void Attack()
    {
        Debug.Log("Enemy attacks!");
        player.GetComponent<MBS_PlayerHealth>()?.TakeDamage(AttackDamage);
    }
}