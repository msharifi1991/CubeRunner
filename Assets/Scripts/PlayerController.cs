using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;
    public TextMeshProUGUI looseText;
    public TextMeshProUGUI scoreText;

    private bool gameFinished = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

        void Update()
    {
        if (!gameFinished)
        {
            if (Input.GetMouseButtonDown(0) && canJump)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!gameFinished && collision.gameObject.tag == "Ground") { 
        
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!gameFinished && collision.gameObject.tag == "Ground") { 
        
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameFinished && other.gameObject.tag == "Obstacle")
        {
            gameFinished = true;

            // Display the player's score message
           // scoreText.text = "Your Score: " + GameManager.score.ToString();
            scoreText.gameObject.SetActive(true);

            // Disable the player's movement
            rb.isKinematic = true;

            Time.timeScale = 0;


            // Start the coroutine to reload the game after a delay
            StartCoroutine(ReloadGameAfterDelay(2.0f));
        }
    }

    IEnumerator ReloadGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene("Game");
    }
}
