using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour {

    public TMP_Text roundsText;

	public string menuSceneName = "MainMenu";

	//public SceneFader sceneFader;
    
    void OnEnable ()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        //sceneFader.FadeTo(menuSceneName);
    }
}