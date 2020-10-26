using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformEditor : MonoBehaviour
{
    public Sprite[] allNumber;
    [SerializeField] GameObject enemyImage;
    [SerializeField] GameObject soldierImage;
    [SerializeField] GameObject enemyCommander;
    [SerializeField] GameObject soldierCommander;
    [SerializeField] GameObject winPanel;
    [SerializeField] Text winText;
    float scoreEnemy = 0;
    float scoreSoldier = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyCounter()
    {
        scoreEnemy += 1;
        soldierCommander.transform.position = new Vector3(soldierCommander.transform.position.x, 5 - (scoreEnemy / 2), soldierCommander.transform.position.z);
        enemyImage.GetComponent<UnityEngine.UI.Image>().sprite = allNumber[(int)scoreEnemy];
        if (scoreEnemy == 10)
        {
            winPanel.gameObject.SetActive(true);
            winText.text = "Win Enemy";
            Time.timeScale = 0;
        }

    }

    public void SoldierCounter()
    {
        scoreSoldier += 1;
        soldierImage.GetComponent<UnityEngine.UI.Image>().sprite = allNumber[(int)scoreSoldier];
        enemyCommander.transform.position = new Vector3(enemyCommander.transform.position.x, 5 - (scoreSoldier / 2), enemyCommander.transform.position.z);
        if (scoreSoldier == 10)
        {
            winPanel.gameObject.SetActive(true);
            winText.text = "Win Soldier";
            Time.timeScale = 0;
        }
    }
}
