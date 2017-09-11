using UnityEngine;

public class CompleteLevel : MonoBehaviour {

    public string mainMenu = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public void Menu()
    {
        sceneFader.FadeTo(mainMenu);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}
