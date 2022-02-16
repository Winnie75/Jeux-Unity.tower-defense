using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    private void Awake()
    {
        instance = this;
        
    }

    [Header("PLAYER STATS")]
    public int score;
    public Text textScore;

    public int money;
    public Text textMoney;

    public int vie;
    public Text textVie;

    [Header("SETUP UNITY")]
    public GameObject playerInfos;
    public GameObject looseScreen;
    public GameObject winScreen;
    public GameObject managers;
    public GameObject menuScreen;
    public GameObject infoScreen;
    

    private void Start()
    {
        menuScreen.SetActive(true);
        managers.SetActive(false);
        infoScreen.SetActive(false);
        looseScreen.SetActive(false);
        winScreen.SetActive(false);

        money = 100;
        textScore.text = "Score : " + score.ToString();
        textMoney.text = "Argent : " + money.ToString();
        textVie.text = "Vie : " + vie.ToString();
    }



    public void AugmenterScore(int _gain)
    {

        //score = score + _gain;

        score += _gain;

        textScore.text = "Score : " + score.ToString();

    }

    public void GagnerPerdreArgent(int _valeur)
    {

        //score = score + _gain;

        money += _valeur;

        textMoney.text = "Argent : " + money.ToString();

    }


    public void PerdreVie(int _valeur)
    {

        vie -= _valeur;

        textVie.text = "Vie : " + vie.ToString();

        if(vie <= 0)
        {
            Loose();
        }

    }

    public void Win()
    {
        winScreen.SetActive(true);
        managers.SetActive(false);
        playerInfos.SetActive(false);
        Time.timeScale = 0;

    }


    void Loose()
    {
        looseScreen.SetActive(true);
        managers.SetActive(false);
        playerInfos.SetActive(false);
        Time.timeScale = 0;


    }

 
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }


}
