using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int health = 100;
    public int speed = 10;
    public int timer = 60;
    bool paused = false;
    [SerializeField] private Text timerText;
    public GameObject empty;
    public GameObject alive;
    //[SerializeField] private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        //load info
        health = PlayerPrefs.GetInt("PlayerHealth", 100);
        speed = PlayerPrefs.GetInt("PlayerSpeed", 10);
        StartCoroutine("CountDown");
    }

    
    IEnumerator CountDown()
    {
        while (timer > 0)
        {
            timerText.text = "Timer: " + timer;
            //wait for a second
            yield return new WaitForSeconds(1);
            timer--;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
        GameToDeath();
    }
    

    private void ChangeLevel()
    {
        //reset player health and timer
        PlayerPrefs.SetInt("PlayerHealth", 100);
        PlayerPrefs.SetInt("PlayerSpeed", 10);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            GameToDeath();
        }

    }

    public void GameToDeath()
    {
        alive.SetActive(false);
        empty.SetActive(true);
    }

    public void PauseUnpause()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
        }
    }
}
