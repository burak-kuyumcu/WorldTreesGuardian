using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public Image healthBar;
    public GameObject gameOverPanel; // Game Over panelini referans ekle


    public override void Start()
    {
        base.Start();
        gameOverPanel.SetActive(false); // Ba�lang��ta gizli yap
    }
    private void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth.GetValue();
    }

    public override void Die()
    {
        base.Die();
        GameOver();
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true); // Game Over panelini a�
        Time.timeScale = 0f; // Oyunu durdur
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu yeniden ba�lat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden y�kle
    }
}
