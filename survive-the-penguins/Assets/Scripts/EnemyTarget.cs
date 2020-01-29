using UnityEngine;
using UnityEngine.AI;

public class EnemyTarget : MonoBehaviour
{
    public float health = 50f;
    public float mobDistanceRun = 4f;
    public GameObject player;

    private NavMeshAgent mob;

    void Start()
    {
        mob = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        //Run towards player

        if (distance < mobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            mob.SetDestination(newPos);
            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

}
