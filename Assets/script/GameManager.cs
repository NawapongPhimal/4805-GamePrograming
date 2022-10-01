using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HealthDisplay displayplayerhealth;
    [SerializeField] int health = 3;

    private void Awake()
    {

        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            //DontDestroyOnLoad(gameObject);
            Destroy(gameObject);
        }
        else
        {
            displayplayerhealth.HealthUpdate(health);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("is destroy");
    }

    public void TriggernextScene()
    {
        StartCoroutine(LoadnextScene());
    }

    public void ProcessPlayerDeath()
    {
        health--;
        displayplayerhealth.HealthUpdate(health);
        if (health == 0) { LoadMainMenu(); }
        else { Loadlevel(CurrentBuildIndex()); }
    }

    public void TakeDamage()
    {
        ProcessPlayerDeath();
    }


    private IEnumerator LoadnextScene()
    {
        //var nextSceneBuild = SceneManager.GetActiveScene().buildIndex + 1;
        var nextSceneBuild = CurrentBuildIndex() + 1;
        if (nextSceneBuild == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneBuild = 0;
        }

        yield return new WaitForSeconds(1f);

        //SceneManager.LoadScene(nextSceneBuild);
        Loadlevel(nextSceneBuild);
        DOTween.KillAll();
    }

    private int CurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void Loadlevel(int Levelindex)
    {
        SceneManager.LoadScene(Levelindex);
    }

    public void LoadMainMenu()
    {
        Loadlevel(0);
        Destroy(gameObject);
    }

}
