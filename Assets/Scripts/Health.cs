using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public Canvas lose;
    public float currentHealth;
    private float currentHealthforBar;
    [SerializeField] private Image hPBarAmount;
    [SerializeField] private TMP_Text HPScore;
    Enemy enemy;
    private void Awake()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        enemy = FindObjectOfType<Enemy>();
        HPScore.text = currentHealth.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            currentHealth -= enemy.damageEnemy;
            currentHealthforBar = currentHealth / maxHealth;
            hPBarAmount.fillAmount = currentHealthforBar;
            CheckIsAlive();
        }
    }
    private void CheckIsAlive()
    {
        if (currentHealth <= 0)
        {
            lose.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    public void AddHealth()
    {
        currentHealth += 10f;
        Time.timeScale = 1.0f;
    }
}
