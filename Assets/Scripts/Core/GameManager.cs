
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsPaused { get; private set; }
    public int CurrentLevel = 1;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0f;
        UIManager.Instance.ShowPause(true);
    }

    public void ResumeGame()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        UIManager.Instance.ShowPause(false);
    }

    public void NextLevel()
    {
        CurrentLevel++;
        Debug.Log("Carregando próxima fase...");
    }

    public void GameOver()
    {
        Debug.Log("Fim da partida. O jogador caiu diante da escuridão.");
        UIManager.Instance.ShowGameOver();
    }
}
