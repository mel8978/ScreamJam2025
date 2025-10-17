using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    public Button startButton;
    public Button quitButton;
    public Button resumeButton;
    public Button menuButton;

    private void Awake()
    {
        // Singleton pattern to persist manager between scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            startButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }

        resumeButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);

        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(ReturnToMenu);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "FirstLevel" && Keyboard.current.pKey.isPressed || Keyboard.current.escapeKey.isPressed)
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstLevel");

        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        resumeButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);

        SceneManager.LoadScene("StartMenu");

        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;

        resumeButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        resumeButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
    }
}
