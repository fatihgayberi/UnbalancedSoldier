using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCreate : MonoBehaviour
{
    EnemyArmy enemyArmy;
    public float spawnEnemySpeed;
    [SerializeField] Button soldierBtn;
    [SerializeField] List<GameObject> enemy;
    Vector3 enemySpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        enemyArmy = GetComponent<EnemyArmy>();
        soldierBtn.onClick.AddListener(EnemySpawner);
    }

    void EnemySpawner()
    {
        float positionZ = Random.Range(-4, 4);
        enemySpawnPoint = new Vector3(-4f, 0.5f, positionZ);
        GameObject createdEnemy;
        int poss = Random.Range(0, enemy.Count);

        createdEnemy = Instantiate(enemy[poss], enemySpawnPoint, Quaternion.identity);
        enemyArmy.EnemyArmyAdd(createdEnemy);
    }
}
