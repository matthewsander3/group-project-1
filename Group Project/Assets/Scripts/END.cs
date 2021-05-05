using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class END : MonoBehaviour
{
   public GameObject end;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("IntroMenu");
        }

    }
    void Start()
    {
        end.SetActive(false);
        StartCoroutine(EnableGameoverPanel());
    }

    IEnumerator EnableGameoverPanel()
    {
        yield return new WaitForSeconds(15);

        end.SetActive(true);
    }


}
