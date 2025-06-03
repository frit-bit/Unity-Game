using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int highScore;
    void Awake() {
        instance = this;
    }
    public void Start(){
        Debug.Log("Game Started");
//      LoadCoins();
//      LoadHC();
    }
    public void HighScore() {
        if (CoinScript.instance.coinValue>highScore){
            highScore = CoinScript.instance.coinValue;
            Debug.Log("New High Score: " + CoinScript.instance.coinValue);
            SaveHC();
        }
    } 
    void Update() {

    }
    public void SaveCoins(){
        PlayerPrefs.SetInt("Coins", CoinScript.instance.coinValue);
        PlayerPrefs.Save();
    }
    public void LoadCoins(){
        CoinScript.instance.coinValue = PlayerPrefs.GetInt("Coins");
        Debug.Log("Coins Loaded: " + CoinScript.instance.coinValue);
        CoinScript.instance.coinText.text = CoinScript.instance.coinValue.ToString();
    } 
    public void SaveHC(){
        PlayerPrefs.SetInt("High Score", highScore);
        PlayerPrefs.Save();
    }
    public void LoadHC(){
        highScore = PlayerPrefs.GetInt("High Score");
        Debug.Log("High Score: " + highScore);
    }
}
