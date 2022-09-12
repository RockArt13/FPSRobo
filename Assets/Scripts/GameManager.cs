using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemiesCount = 0;

    public int level = 0;

   

    public int destroyedBoxes = 0;

    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;

    public Text levelNumber;
    public Text currentLevel;
    public Text killCount;
    public Text killCountEndMenu;
    public Text destroyedItemCount;
    public Text timerText;

    float timer = 0.0f;



    public GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //killCount.text = "Kill Count: " + EnemyController.killedEnemies;
        timer += Time.deltaTime;

        if (enemiesCount == 0)
        {
            level++;
            NextLevel(level);
            levelNumber.text = "Level: " + level.ToString();
        }

        KillCounter();
        DistroyedItemCounter();
        
    }

    public void NextLevel(int round)
    {
        for (var x = 0; x<round; x++)
        { 
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

            spawnedEnemy.GetComponent<EnemyController>().gameManager = GetComponent<GameManager>();
            enemiesCount++;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Destroy(levelNumber);
        Destroy(killCount);
        Destroy(destroyedItemCount);
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
        currentLevel.text = level.ToString();
        killCountEndMenu.text = EnemyController.killedEnemies.ToString();
        timerText.text = Mathf.Round(timer).ToString() + "sec";
    }

    public void KillCounter()
    {
        killCount.text = "Kill Count: " + EnemyController.killedEnemies.ToString();
    }

    public void DistroyedItemCounter()
    {
        destroyedItemCount.text = "Distroyed Boxes: " + ItemController.destroyedItem.ToString();

    }
}
