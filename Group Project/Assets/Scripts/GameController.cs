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

    public int timerMin = 0;
    public int timerHour = 8;
    [SerializeField] private int endTime;
    [SerializeField] private string meridian;
    [SerializeField] private string endMeridian;

    [SerializeField] private int energy;
    [SerializeField] private Slider energySlider;

    bool paused = false;
    [SerializeField] private Text timerText;
    [SerializeField] private Text energyText;
    public GameObject dead;
    public GameObject alive;
    public GameObject panel;

    public int cost;
    public int scareVal;

    //[SerializeField] private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        //load info
        health = PlayerPrefs.GetInt("PlayerHealth", 100);
        speed = PlayerPrefs.GetInt("PlayerSpeed", 10);

        dead.SetActive(false);
        panel.SetActive(false);
        StartCoroutine("CountDown");
        StartCoroutine("EnergyManagement");
    }

    IEnumerator EnergyManagement()
    {


        while (energy >= 0)
        {

            if (energy < 100)
            {
                StopCoroutine("LowHealth");
                Debug.Log("Ended low health");
            }
           // yield return new WaitForSeconds(1);
            if(cost != 0)
            {
                energy -= cost;
                cost = 0;
            }
            if(scareVal != 0)
            {
                energy += scareVal;
                scareVal = 0;
            }
            if(energy <= 25)
            {
                speed = 5;
                StartCoroutine("LowHealth");
                yield break;
                
            }
            yield return new WaitForSeconds(1);
            energySlider.value = energy;
            energy--;
        }

        
    }

    IEnumerator LowHealth()
    {
        StopCoroutine("EnergyManagement");
        Debug.Log("STOPPED");
        while (energy > 0)
        {
            if (energy >= 26)
            {
                StartCoroutine("EnergyManagement");
                yield break;
            }
            energyText.color = Color.white;
            
            yield return new WaitForSeconds(1);
            energySlider.value = energy;
            energy--;
            energyText.color = Color.red;
            yield return new WaitForSeconds(1);

        }
        GameToDeath();
    }

    public void costValue(int energyCost)
    {
        cost = energyCost;
    } 
    
    public void scareValue(int energyCost)
    {
        scareVal = energyCost;
    }

    IEnumerator CountDown()
    {
        while (meridian == endMeridian)
        {
            while (timerMin < 60)
            {
                if (timerMin <= 9)
                {
                    timerText.text = timerHour.ToString() + ":0" + timerMin.ToString() + " " + meridian;
                }
                else
                {
                    timerText.text = timerHour.ToString() + ":" + timerMin.ToString() + " " + meridian;
                }
                //wait for a second
                yield return new WaitForSeconds(1);
                timerMin++;
            }
            timerMin = 0;
            if (timerHour + 1 > 12)
            {
                timerHour = 1;
                if (meridian == "P.M.")
                {
                    meridian = "A.M.";
                }
                else
                {
                    meridian = "P.M.";
                }
            }
            else
                timerHour++;
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
        energyText.text = "Energy: " + energy.ToString();

        if (health <= 0)
        {
            GameToDeath();
        }

    }


    public void MenuToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameToDeath()
    {
        Debug.Log("You died");
        alive.SetActive(false);
        dead.SetActive(true);
    }


    public void DeathToGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DeathToMenu()
    {
        SceneManager.LoadScene(0);
    }



    public void GameOver()
    {
        Debug.Log("GAME OVER!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void PauseUnpause()
    {
        if (paused)
        {
            panel.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
        else
        {
            panel.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
    }
}
