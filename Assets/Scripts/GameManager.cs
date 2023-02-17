using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneManager currentLevel;
    public TMP_Text scoreDamage;
    public int bulletDamage;
    public float radiusDamageBullet = 10.0f;
    [SerializeField] LayerMask layerEnemy;
    public Bullet bullet;
    public Player player;
    public Enemy enemy;
    public Health health;
    public GenerationEnemy generationsEnemy1;
    public GenerationEnemy generationsEnemy2;
    public GenerationEnemy generationsEnemy3;
    private int sumNumberOfDestroy;
    public Canvas win;
    private bool detectedWin;
    private void Start()
    {
        detectedWin = false;
    }
    private void Update()
    {
        scoreDamage.text = bulletDamage.ToString();
        sumNumberOfDestroy = generationsEnemy1.numberOfDestroy + generationsEnemy2.numberOfDestroy + generationsEnemy3.numberOfDestroy;
        if (sumNumberOfDestroy >= 3)
        {
            if (!detectedWin)
            {
                Victory();
                detectedWin = true;
            }
        }
    }
    public void BackToGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 0;
    }
    public void Crazy()
    {
        bulletDamage = 5;
        health = FindObjectOfType<Health>();
        health.currentHealth = 40;
        player = FindObjectOfType<Player>();
        player.moveSpeed = 2;
    }
    public void Hard()
    {
        bulletDamage = 10;
        health = FindObjectOfType<Health>();
        health.currentHealth = 50;
        player = FindObjectOfType<Player>();
        player.moveSpeed = 3;
    }
    public void Normal()
    {
        bulletDamage = 20;
        health = FindObjectOfType<Health>();
        health.currentHealth = 60;
        player = FindObjectOfType<Player>();
        player.moveSpeed = 4;
    }
    public void Easy()
    {
        bulletDamage = 30;
        health = FindObjectOfType<Health>();
        health.currentHealth = 70;
        player = FindObjectOfType<Player>();
        player.moveSpeed = 5;
    }
    public void Victory()
    {
        win.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

}
