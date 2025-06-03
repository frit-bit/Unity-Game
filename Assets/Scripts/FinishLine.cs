using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="Player") {
            Invoke("FinishGame", 2);
        }
    }
    private void FinishGame(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}