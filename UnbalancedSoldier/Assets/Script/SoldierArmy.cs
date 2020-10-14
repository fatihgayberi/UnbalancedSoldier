using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SoldierArmy : MonoBehaviour
{
    [SerializeField] GameObject greenSoldier;
    [SerializeField] GameObject blueSoldier;
    [SerializeField] GameObject redSoldier;
    [SerializeField] GameObject purpleSoldier;
    [SerializeField] GameObject yellowSoldier;
    Vector3 soldierSpawnPoint;
    public List<GameObject> soldierArm = new List<GameObject>();

    public void SoldierCreator(float sliderValue)
    {
        GameObject soldier;
        float positionZ = Random.Range(-4, 4);
        soldierSpawnPoint = new Vector3(4f, 0.5f, positionZ);

        if (sliderValue <= 0.6f)
        {
            // Green
            soldier = Instantiate(greenSoldier, soldierSpawnPoint, Quaternion.identity);
        }
        else if (sliderValue <= 1.2f)
        {
            // Blue
            soldier = Instantiate(blueSoldier, soldierSpawnPoint, Quaternion.identity);
        }
        else if (sliderValue <= 1.8f)
        {
            // Red
            soldier = Instantiate(redSoldier, soldierSpawnPoint, Quaternion.identity);
        }
        else if (sliderValue <= 2.4f)
        {
            // Purple
            soldier = Instantiate(purpleSoldier, soldierSpawnPoint, Quaternion.identity);
        }
        else
        {
            // Yellow
            soldier = Instantiate(yellowSoldier, soldierSpawnPoint, Quaternion.identity);
        }

        if (soldier != null)
        {
            soldierArm.Add(soldier);
        }
    }

    public void SoldierArmRemove(GameObject soldier)
    {
        soldierArm.Remove(soldier);
    }

    public bool SoldierArmEmpty()
    {
        return soldierArm.Any();
    }

    public GameObject GetSoldier(int index)
    {
        return soldierArm[index];
    }

    public GameObject EnemyForTarget()
    {
        int poss;
        poss = Random.Range(0, soldierArm.Count);
        return soldierArm[poss];
    }
}
