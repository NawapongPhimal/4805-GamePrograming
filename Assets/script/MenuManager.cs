using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        int Levelindex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(Levelindex);
    }
}
