using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverRestart : MonoBehaviour
{
    public Scene loadscene;
    public void playAgain()
    {
        SceneManager.LoadScene(loadscene.ToString());

    }
}
