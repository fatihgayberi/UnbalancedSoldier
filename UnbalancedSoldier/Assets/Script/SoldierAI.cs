using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    EnemyArmy enemyArmy;
    PlatformEditor platformEditor;
    CharacterController controller;
    float moveSpeed = 3;
    public float soldierHealth;
    public float soldierDamage;
    GameObject enemyTarget;

    // Start is called before the first frame update
    void Start()
    {
        enemyArmy = FindObjectOfType<EnemyArmy>();
        platformEditor = FindObjectOfType<PlatformEditor>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        FindEnemyTarget();
    }

    void FindEnemyTarget()
    {
        if (enemyArmy.EnemyArmEmpty())
        {
            enemyTarget = enemyArmy.SoldierForTarget();
            if (enemyTarget.CompareTag("Enemy"))
            {
                Vector3 direction = enemyTarget.transform.position - transform.position;
                direction.Normalize();
                Vector3 velocity = direction * moveSpeed;
                controller.Move(velocity * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            int poss = Random.Range(0, 100);

            if (poss >= 50)
            {
                other.gameObject.GetComponent<EnemyAI>().SetSoldierHealth(soldierDamage);

                if (other.gameObject.GetComponent<EnemyAI>().GetSoldierHealth() <= 0f)
                {
                    other.gameObject.tag = "DeadEnemy";
                    enemyArmy.EnemyArmyRemove(other.gameObject);
                    Destroy(other.gameObject);
                    platformEditor.SoldierCounter();
                }
            }
        }
    }

    public void SetSoldierHealth(float health)
    {
        soldierHealth -= health;
    }

    public float GetSoldierHealth()
    {
        return soldierHealth;
    }
}
