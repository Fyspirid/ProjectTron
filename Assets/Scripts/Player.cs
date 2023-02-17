using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] GameObject enemys;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float changeAttackCD = 1f;
    private float timerChange = 5.0f;
    [SerializeField] private GameObject bullets;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float radiusAttack;
    [SerializeField] private TMP_Text speedScore;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        LogicMovement();
    }
    private void Update()
    {
        DetectedEnemy();
        speedScore.text = moveSpeed.ToString();
    }
    void Shoot(Transform enemy)
    {
        GameObject bullet = Instantiate (bullets, firePoint.position, firePoint.rotation);
        Vector2 direction = (enemy.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
    // Логика движения игрока
    void LogicMovement()
    {
        rb.velocity = new Vector2((Input.GetAxis("Horizontal")) * moveSpeed, (Input.GetAxis("Vertical")) * moveSpeed);
    }
    /*public void AddSpeed()
    {
        moveSpeed += 2;
        Time.timeScale = 1.0f;
    }*/
    void DetectedEnemy()
    {
        Collider2D[] enemiesInSight = Physics2D.OverlapCircleAll(transform.position, radiusAttack, enemyLayer);
        if (enemiesInSight.Length > 0)
        {
            timerChange -= Time.deltaTime;
            if (timerChange > 0)
            {
                attackCooldown += Time.deltaTime;
                if (attackCooldown > changeAttackCD)
                {
                    Shoot(enemiesInSight[0].transform);
                    attackCooldown = 0.0f;
                }
            }
            else 
            {
                attackCooldown += Time.deltaTime;
                if (attackCooldown > changeAttackCD)
                {
                    Shoot(enemiesInSight[0].transform);
                    attackCooldown = 0.0f;
                }
                changeAttackCD = 1.0f;
            }

        }
    }
    public void ChangeTimeAttack()
    {
        changeAttackCD = 0.5f;
        Time.timeScale = 1f;
    }
    public void UpgradeCycleSlow()
    {
        timerChange = 10f;
    }
}
