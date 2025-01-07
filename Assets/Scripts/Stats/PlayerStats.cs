using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public Image healthBar; // Saðlýk barýný UI üzerinden baðlayýn
    public GameObject gameOverPanel; // Game Over panelini referans ekle

    public override void Start()
    {
        base.Start();

        // Game Over panelinin baþlangýçta gizli olmasýný saðla
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Game Over Panel referansý atanmadý!"); // Hata ayýklama mesajý
        }
    }

    private void Update()
    {
        // Can barýný güncelle
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth.GetValue();
        }
        else
        {
            Debug.LogError("Health Bar referansý atanmadý!");
        }

        // Geçici test kodu: Oyuncunun canýný sýfýra düþürmek için klavyeden "K" tuþuna basabilirsiniz
        if (Input.GetKeyDown(KeyCode.K))
        {
            currentHealth = 0;
            Die();
        }
    }

    public override void Die()
    {
        // Oyuncuyu yok etmek yerine devre dýþý býrak
        gameObject.SetActive(false);

        // Game Over ekranýný aç
        GameOver();
    }

    private void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("Game Over ekraný açýldý!");
        }

        // Oyunu durdur
        Time.timeScale = 0f;

        // Restart düðmesini dinamik olarak baðla
        Button restartButton = gameOverPanel.GetComponentInChildren<Button>();
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners(); // Eski olaylarý temizle
            restartButton.onClick.AddListener(RestartGame); // RestartGame olayýný baðla
        }
    }


    public void RestartGame()
    {
        Debug.Log("RestartGame çaðrýldý!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Sahne adýný yazýn
    }
}
