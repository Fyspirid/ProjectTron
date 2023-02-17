using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLU : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float radiusAttack;
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject bullets;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private Transform player;
    [SerializeField] private float distanceFromPlayer = 1.5f;
    GameManager damageAddon;
    private void Update()
    {
        DetectedEnemy();
    }
    //логика следования за Player, при использовании Update происходит подергивание, поэтому выбрал LateUpdate
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(player.position.x + distanceFromPlayer, player.transform.position.y, player.transform.position.z);
        transform.position = newPosition;
    }
    void DetectedEnemy()
    {
        Collider2D[] enemiesInSight = Physics2D.OverlapCircleAll(transform.position, radiusAttack, enemyLayer);
        if (enemiesInSight.Length > 0)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown < 0)
            {
                Shoot(enemiesInSight[0].transform);
                attackCooldown = 1f;
            }
        }
    }
    void Shoot(Transform enemy)
    {
        GameObject bullet = Instantiate(bullets, firePoint.position, firePoint.rotation);
        Vector2 direction = (enemy.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
    public void TargetPlayer()
    {
        Vector3 newPosition = new Vector3(player.position.x + distanceFromPlayer, player.position.x, player.transform.position.z);
        transform.position = newPosition;
        Time.timeScale = 1f;
    }
    public void UprgadeCLU()
    {
        damageAddon = FindObjectOfType<GameManager>();
        damageAddon.bulletDamage += 10;
    }
}
