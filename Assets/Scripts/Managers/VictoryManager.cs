using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryPanel; // Victory Panelini buraya baðlayýn
    public string enemyTag = "Enemy"; // Düþmanlarýn tag'i

    void Start()
    {
        // Victory panelini baþlangýçta gizle
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Victory Paneli atanmadý!");
        }
    }

    void Update()
    {
        // Sahnedeki düþmanlarý kontrol et
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        if (enemies.Length == 0)
        {
            ShowVictoryScreen();
        }
    }

    void ShowVictoryScreen()
    {
        // Victory ekranýný göster
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            Debug.Log("Tüm düþmanlar öldü! Victory ekraný açýldý.");
        }

        Time.timeScale = 0f; // Oyunu durdur
    }

    public void RestartGame()
    {
        // Oyunu yeniden baþlat
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        // Oyunu kapat
        Debug.Log("Oyun kapatýlýyor...");
        Application.Quit();
    }
}
