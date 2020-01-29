using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float playerHealth = 1000f;
    public float damage = 0.1f;
    public GameObject EnemyPenguin;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, EnemyPenguin.transform.position);

        if (distance <= 2f)
        {
            print("Hello, I'm hurt!");
            playerHealth -= damage;
        }
    }
}
