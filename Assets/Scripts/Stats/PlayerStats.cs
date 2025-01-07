using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public Image healthBar; // Sa�l�k bar�n� UI �zerinden ba�lay�n
    public GameObject gameOverPanel; // Game Over panelini referans ekle

    public override void Start()
    {
        base.Start();

        // Game Over panelinin ba�lang��ta gizli olmas�n� sa�la
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Game Over Panel referans� atanmad�!"); // Hata ay�klama mesaj�
        }
    }

    private void Update()
    {
        // Can bar�n� g�ncelle
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth.GetValue();
        }
        else
        {
            Debug.LogError("Health Bar referans� atanmad�!");
        }

        // Ge�ici test kodu: Oyuncunun can�n� s�f�ra d���rmek i�in klavyeden "K" tu�una basabilirsiniz
        if (Input.GetKeyDown(KeyCode.K))
        {
            currentHealth = 0;
            Die();
        }
    }

    public override void Die()
    {
        // Oyuncuyu yok etmek yerine devre d��� b�rak
        gameObject.SetActive(false);

        // Game Over ekran�n� a�
        GameOver();
    }

    private void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("Game Over ekran� a��ld�!");
        }

        // Oyunu durdur
        Time.timeScale = 0f;

        // Restart d��mesini dinamik olarak ba�la
        Button restartButton = gameOverPanel.GetComponentInChildren<Button>();
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners(); // Eski olaylar� temizle
            restartButton.onClick.AddListener(RestartGame); // RestartGame olay�n� ba�la
        }
    }


    public void RestartGame()
    {
        Debug.Log("RestartGame �a�r�ld�!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Sahne ad�n� yaz�n
    }
}
