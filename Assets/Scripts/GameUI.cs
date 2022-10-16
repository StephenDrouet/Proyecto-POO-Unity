using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public bool isLife { get; private set; }
    
    private float timeGame;
    private float score;
    public int health;

    public TextMeshProUGUI timeGameTxt;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI healthTxt;
    public TextMeshProUGUI addTimeTxt;
    public GameObject GameOverUI;
    public Animator panelAnim;
    public Animator shakeCamera;
    private Animator addTimeAnim;
    

    void Start()
    {
        addTimeAnim = addTimeTxt.gameObject.GetComponent<Animator>();

        isLife = true;
        timeGame = 62;
        score = 0;
        health = 3;

        healthTxt.SetText("Vidas:" + health);
        scoreTxt.SetText("Puntaje: " + score);
        timeGameTxt.SetText("Tiempo: " + timeGame);
    }

    void Update()
    {
        if (isLife)
        {
            UpdateTime();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("press space");
                StartCoroutine(Restart());
            }
        }
    }

    void UpdateTime()
    {
        timeGame -= Time.deltaTime;
        timeGameTxt.SetText("Tiempo: " + Mathf.RoundToInt(timeGame));

        if (timeGame < 0)
        {
            GameOver();
        }
    }

    public void addTime()
    {
        int timeToAdd = Random.Range(6, 13);
        timeGame += timeToAdd;

        addTimeTxt.SetText("+" + timeToAdd);
        addTimeAnim.SetTrigger("add");
    }

    public void UpdateScore(float addScore)
    {
        score += addScore;
        scoreTxt.SetText("Puntaje: " + score);
    }

    public void UpdateHealth()
    {
        shakeCamera.SetTrigger("shake");

        health -= 1;        
        healthTxt.SetText("Vidas: " + health);

        if (health < 1)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isLife = false;
        GameOverUI.SetActive(true);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }


    public IEnumerator Restart()
    {
        panelAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
