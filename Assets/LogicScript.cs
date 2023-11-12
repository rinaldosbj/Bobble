using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class LogicScript : MonoBehaviour
{
   public int playerScore = 0;
   public Text scoreText;
   public GameObject gameOverScreen;

   public GameObject game;

   public GameObject startScreen;

   private PipeSpawnerScript pipeSpawner;
   public GameObject pipe;

   public GameObject score;

   public bool startedGame = false;

   public float difficultyTriggersInSpacesOf = 4;

   public bool increasedDifficulty = false;
   private float timer = 0;
     public float timeInterval = 2;

     private bool transitionOccured = false;

    [ContextMenu("Increase Score")]
   public void AddScore() 
   {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
   }

   void Update()
   {
          if (playerScore%difficultyTriggersInSpacesOf == 0 && !increasedDifficulty && playerScore != 0){
               increaseDifficulty();
          }
          else if (playerScore%difficultyTriggersInSpacesOf != 0) {
               increasedDifficulty = false;
          }

          // if (Input.GetKeyDown(KeyCode.Escape)){
          //      Application.Quit();
          // }

          if (Input.GetKeyDown(KeyCode.Space) && !startedGame && transitionOccured) {
               startGame();
               startedGame = true;
          }

          if (timer < timeInterval && !transitionOccured){ 
            timer += Time.deltaTime; 
          } else {
               if (!transitionOccured) {
                    transitionOccured = true;
                    startScreen.SetActive(true);
               }
          }
   }

   public void restarGame() 
   {
        backToMenu();
        startGame();
   }

   public void backToMenu() 
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void gameOver() 
   {
        gameOverScreen.SetActive(true);
   }

   public void increaseDifficulty()
   {
          if (!increasedDifficulty){
               increasedDifficulty = true;
               if (pipeSpawner.spawnRate > 0.8f){
                    pipeSpawner.spawnRate -= 0.1f;
               }
               else {
                    pipeSpawner.spawnRate = 0.8f;
               }
               if (pipe.GetComponent<PipeScript>().moveSpeed < 13) {
                    pipe.GetComponent<PipeScript>().moveSpeed += 0.02f;
               }
               Debug.Log($"Increased Difficulty {playerScore}");
          }
   }

   public void startGame()
   {
     game.SetActive(true);
     score.SetActive(true);
     startScreen.SetActive(false);
     pipeSpawner = GameObject.FindGameObjectWithTag("PipeSpawner").GetComponent<PipeSpawnerScript>();
     pipe.GetComponent<PipeScript>().moveSpeed = 0.5f;
   }


}
