using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidRespawn : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag=="Player"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
