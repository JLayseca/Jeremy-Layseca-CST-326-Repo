using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string gameSceneName;

    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }
}
