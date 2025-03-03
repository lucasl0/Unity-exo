using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject player; // Assigner le joueur dans l'inspecteur

    public voidEventChannel onPlayerDeath;

    private bool isPaused = false;

    private void OnEnable()
    {
        onPlayerDeath.OnEventRaised += Die;
    }

    private void OnDisable()
    {
        onPlayerDeath.OnEventRaised -= Die;
    }

    private void Start()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void Die()
    {
        gameOverScreen.SetActive(true);
        LockPlayerMovement(true);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseScreen.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        LockPlayerMovement(isPaused);
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Réinitialiser le temps
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LockPlayerMovement(bool lockMovement)
    {
        if (player != null)
        {
            var playerController = player.GetComponent<playermovement>(); 
            if (playerController != null)
            {
                playerController.enabled = !lockMovement;
            }
        }
    }
}
