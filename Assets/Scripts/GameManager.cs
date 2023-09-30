using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Obstacle;
    public Transform spawnPoint;
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;

    void Start()
    {
       
    }

       void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 2f);

            yield return new WaitForSeconds(waitTime);
            Instantiate(Obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    void ScoreUp() {

        score++;
        scoreText.text = score.ToString();
    }
    public void GameStart() {

        player.SetActive(true);
       scoreText.gameObject.SetActive(true);
        playButton.SetActive(false);
        Time.timeScale = 1;
        score = 0;
        StartCoroutine("SpawnObstacles");

        InvokeRepeating("ScoreUp", 2f, 0.5f);
    }
}
