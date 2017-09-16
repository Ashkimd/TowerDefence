using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public CompleteLevel completeLevel;

    private void Start()
    {
        gameIsOver = false;
    }

    private void Update()
    {

        if (gameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;        
        completeLevelUI.SetActive(true);
        PlayerPrefs.SetInt("levelReached", completeLevel.levelToUnlock);
    }
}
