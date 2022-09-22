using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {

        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            DontDestroyOnLoad(gameObject);
            //Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void TriggernextScene()
    {
        StartCoroutine(LoadnextScene());
    }

    public void ProcessPlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TakeDamage()
    {
        ProcessPlayerDeath();
    }


    private IEnumerator LoadnextScene()
    {
        var nextSceneBuild = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneBuild == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneBuild = 0;
        }

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(nextSceneBuild);
    }


}
