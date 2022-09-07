using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public float health = 100;
    public float lookRad = 10f;
    NavMeshAgent agent;
    Transform target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = gamemanager.instance.player.transform;
    }
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRad)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                // atack  the target 
                // face the target 
            }
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRad);
    }
}
