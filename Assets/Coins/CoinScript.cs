using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CoinScript : MonoBehaviour {
    public static CoinScript instance;
    public AudioSource audioSource;
    public AudioClip collectSound;

    public TextMeshProUGUI coinText;
    public int coinValue = 0;
    private int maxCoins;
    void Awake(){
        instance = this;
    }
    void Start(){
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }
    void Update(){
        if (coinValue == maxCoins) {
            Debug.Log("All Coins Collected");
        }

    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Coin") {
            coinValue++;
            coinText.text = coinValue.ToString();
//          CoinManager.instance.SaveCoins();
            CoinManager.instance.HighScore();
            audioSource.PlayOneShot(collectSound);
            Destroy(collision.gameObject,0.1f);
        }
    }
}
