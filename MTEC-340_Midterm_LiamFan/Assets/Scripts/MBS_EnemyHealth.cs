using UnityEngine;

public class MBS_EnemyHealth : MonoBehaviour
{
    public int health = 30;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy Defeated!");
    }
}