using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI enemiesCountText;


    public int score = 0;
    public int health;

    Bazooka player;

    bool isGameActive = false;         

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenuWin;
    [SerializeField] GameObject gameOverMenuLose;       

    [SerializeField] Button startGameBtn;
    [SerializeField] Button instructionsBtn;
    [SerializeField] Button pauseGameBtn;
    [SerializeField] Button quitGameBtn;
    [SerializeField] Button returnToGameMenuBtn;

    ProjectileSpawner projectileSpawner;


    public bool CheckIfGameIsActive()
    {
        return isGameActive;
    }

    public bool isGamePaused = false;

    PlayerController playerController;

    AudioSource audioSource;

    [SerializeField] AudioClip explosion;

    int pickupTimer = 10;
    float nextPickupTimer = 0;
    float setNextPickupSpawnTime;

    [SerializeField] GameObject pickup;

    int _enemiesDown = 0;

    public int EnemiesDown 
    { 
        get 
        { 
            return _enemiesDown;
        }

        set 
        { 
            _enemiesDown = value;            

        }
    }

    EnemySpawner enemySpawner;


    // Start is called before the first frame update
    void Start()
    {
        
        //Shows the cursor
        Cursor.visible = true;

        player = GameObject.Find("Bazooka").GetComponent<Bazooka>();

        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();

        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

        projectileSpawner = GameObject.Find("ProjectileSpawner").GetComponent<ProjectileSpawner>();


        pauseMenu.SetActive(false);

        enemiesCountText.text = "Enemies left: ";


    }

    // Update is called once per frame
    void Update()
    {

        setNextPickupSpawnTime = Random.Range(10, 20);

        nextPickupTimer += Time.deltaTime;


        if (projectileSpawner.hasPickup == true)
        {
            StartCoroutine(PickupTimer());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (health == 0)
        {
            Time.timeScale = 0;
            GameOverLose();
        }

        if (EnemiesDown == 40)
        {
            Time.timeScale = 0;
            gameOverMenuWin.SetActive(true);
        }

        enemiesCountText.text = "Enemies left: " + (enemySpawner.enemyCount - EnemiesDown);
    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Kills: " + score;
    }

    public void UpdateHealthText(int currentHealth)
    {
        health = currentHealth;
        healthText.text = "Health: " + currentHealth;
    }

    public void GameOverWin()
    {
        gameOverMenuWin.SetActive(true);
    }
    public void GameOverLose()
    {
        gameOverMenuLose.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);

        isGameActive = true;
        UpdateScore(0);

        UpdateHealthText(player.GetHealth());

        // Locks the cursor
        Cursor.lockState = CursorLockMode.Locked;

        audioSource.Play();

        SpawnNextPickup();

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void PlayExplosionSound()
    {
        audioSource.PlayOneShot(explosion);
    }

    public IEnumerator PickupTimer()
    {
        
        yield return new WaitForSeconds(pickupTimer);
        projectileSpawner.hasPickup = false;


        if (nextPickupTimer > setNextPickupSpawnTime)
            {
                SpawnNextPickup();
                nextPickupTimer = 0;
            }

        
    }
    void SpawnNextPickup()
    {
        Vector3 pickupPos = new Vector3(
            player.transform.position.x + Random.Range(-30, 30),
            1.07f,
            player.transform.position.z + Random.Range(-30, 30)
            );

        Instantiate(pickup, pickupPos, pickup.transform.rotation);
    }

    public void UnpauseButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        AudioListener.pause = false;
        isGamePaused = false;
        Cursor.visible = false;

    }
}
