using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    List<GameObject> enemyArm = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyArmyAdd(GameObject enemy)
    {
        enemyArm.Add(enemy);
    }
    public void EnemyArmyRemove(GameObject enemy)
    {
        enemyArm.Remove(enemy);
    }

    public GameObject GetEnemy(int index)
    {
        return enemyArm[index];
    }

    public bool EnemyArmEmpty()
    {
        return enemyArm.Any();
    }

    public GameObject SoldierForTarget()
    {
        int poss;
        poss = Random.Range(0, enemyArm.Count);
        return enemyArm[poss];
    }
}
