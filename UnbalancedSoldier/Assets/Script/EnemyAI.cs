using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    SoldierArmy soldierArmy;
    PlatformEditor platformEditor;
    CharacterController controller;
    float moveSpeed = 3;
    public float enemyHealth;
    public float enemyDamage;
    GameObject soldierTarget;


    // Start is called before the first frame update
    void Start()
    {
        soldierArmy = FindObjectOfType<SoldierArmy>();
        platformEditor = FindObjectOfType<PlatformEditor>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        FindSoldierTarget();
    }

    void FindSoldierTarget()
    {
        if (soldierArmy.SoldierArmEmpty())
        {
            soldierTarget = soldierArmy.EnemyForTarget();
            if (soldierTarget.CompareTag("Soldier"))
            {
                Vector3 direction = soldierTarget.transform.position - transform.position;
                direction.Normalize();
                Vector3 velocity = direction * moveSpeed;
                controller.Move(velocity * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Soldier"))
        {
            int poss = Random.Range(0, 100);

            if (poss >= 50)
            {
                other.gameObject.GetComponent<SoldierAI>().SetSoldierHealth(enemyDamage);

                if (other.gameObject.GetComponent<SoldierAI>().GetSoldierHealth() <= 0f)
                {
                    other.gameObject.tag = "DeadSoldier";
                    soldierArmy.SoldierArmRemove(other.gameObject);
                    Destroy(other.gameObject);
                    platformEditor.EnemyCounter();
                }
            }
        }
    }

    public void SetSoldierHealth(float health)
    {
        enemyHealth -= health;
    }

    public float GetSoldierHealth()
    {
        return enemyHealth;
    }
}
