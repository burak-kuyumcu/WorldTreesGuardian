using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryPanel; // Victory Panelini buraya ba�lay�n
    public string enemyTag = "Enemy"; // D��manlar�n tag'i

    void Start()
    {
        // Victory panelini ba�lang��ta gizle
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Victory Paneli atanmad�!");
        }
    }

    void Update()
    {
        // Sahnedeki d��manlar� kontrol et
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        if (enemies.Length == 0)
        {
            ShowVictoryScreen();
        }
    }

    void ShowVictoryScreen()
    {
        // Victory ekran�n� g�ster
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            Debug.Log("T�m d��manlar �ld�! Victory ekran� a��ld�.");
        }

        Time.timeScale = 0f; // Oyunu durdur
    }

    public void RestartGame()
    {
        // Oyunu yeniden ba�lat
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        // Oyunu kapat
        Debug.Log("Oyun kapat�l�yor...");
        Application.Quit();
    }
}
