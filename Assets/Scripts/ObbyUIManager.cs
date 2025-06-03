using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObbyUIManager : MonoBehaviour {
    public GameObject MainMenu, QuitConfirmationPanel;
    public void StartGame(){
        SceneManager.LoadScene(1);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PlayAgain(){
        SceneManager.LoadScene(0);
    }
    public void EnableQuitConfirmation(){
        MainMenu.SetActive(false);
        QuitConfirmationPanel.SetActive(true);
    }
    public void EnableMainMenu(){
        MainMenu.SetActive(true);
        QuitConfirmationPanel.SetActive(false);
    }
    public void ToggleSound(){
        if (AudioListener.pause == false){
            AudioListener.pause = true;
        }
        else {
            AudioListener.pause = false;
        }
    }
}
//Corutine and Invoke