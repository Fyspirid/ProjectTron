using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemySelected;
    [SerializeField] private Transform placeCreationEnemy1;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float maxHealth;
    public int numberOfDestroy;
    private float currentHealth;
    GameManager gameManager;
    CollectPoint pointFromEnemy;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        SpawnEnemy();
        gameManager = FindObjectOfType<GameManager>();
        pointFromEnemy = FindObjectOfType<CollectPoint>();
    }
    void SpawnEnemy()
    {
        timeSpawn -= Time.deltaTime;
        if (timeSpawn < 0)
        {
            //Позиция создания врагов
            Vector2 spawnPosition = new Vector2(placeCreationEnemy1.position.x, placeCreationEnemy1.position.y);
            //Создание врагов по заданным координатам
            GameObject enemy = Instantiate(enemySelected, spawnPosition, Quaternion.identity);
            timeSpawn = 6f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        //При касании Пули, наноcиться урон а затем смерть
        currentHealth -= gameManager.bulletDamage;

        if (currentHealth < 0)
        {
            numberOfDestroy ++;
            Destroy(gameObject);
            pointFromEnemy.point += 50;
        }
    }
}
