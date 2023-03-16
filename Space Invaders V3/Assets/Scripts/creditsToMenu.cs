using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsToMenu : MonoBehaviour
{
    public string menuSceneName;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToSwitch());
    }

   
    IEnumerator WaitToSwitch()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(menuSceneName, LoadSceneMode.Single);
    }
}
