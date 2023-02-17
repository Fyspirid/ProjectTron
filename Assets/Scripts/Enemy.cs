using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speedEnemy;
    [SerializeField] private float maxHealth;
    [SerializeField] private float pointForKill;
    private float currentSpeedEnemy;
    private float currentHealth;
    Player player;
    GameManager gameManager;
    CollectPoint pointFromEnemy;
    Vector2 offset;
    public float damageEnemy;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        offset = transform.position - player.transform.position;
        currentHealth = maxHealth;
        currentSpeedEnemy = speedEnemy;
    }
    void Update()
    {
        FollowToPlayer();
        gameManager = FindObjectOfType<GameManager>();
        pointFromEnemy = FindObjectOfType<CollectPoint>();
    }
    void FollowToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y), currentSpeedEnemy * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) // получение урона при касании ѕули
        {
            TakeDamage();
        }
        if (collision.CompareTag("Player")) // уничтожение обьекта при касании с Player вне зависимости от остатка HP и добавление очков
        {
            Destroy(gameObject);
            pointFromEnemy.point += pointForKill;
        }
        if (collision.CompareTag("Geller")) // уничтожение обьекта при касании с Geller вне зависимости от остатка HP и добавление очков
        {
            Destroy(gameObject);
            pointFromEnemy.point += pointForKill;
        }
    }
    private void OnTriggerStay2D(Collider2D collision) //при касании таланта «ащита остановка движени€ врага 
    {
        if (collision.CompareTag("Armor"))
        {
            currentSpeedEnemy = 0f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //при выходе из коллизии «ащита запуск движени€
    {
        if (!collision.CompareTag("Armor"))
        {
            currentSpeedEnemy = speedEnemy;
        }
    }
    public void TakeDamage()
    {
        //ѕри касании ѕули, наноcитьс€ урон а затем смерть
        currentHealth -= gameManager.bulletDamage;

        if (currentHealth < 0)
        {
            Destroy(gameObject);
            pointFromEnemy.point += pointForKill;
        }
    }
}
