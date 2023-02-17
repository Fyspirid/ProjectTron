using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GellerField : MonoBehaviour
{
    private float currentGeller;
    private float currentGellerforBar;
    public float maxGeller;
    [SerializeField] private Image GellerBarZero;
    [SerializeField] private Image GellerBarAmount;
    Player player;
    Enemy enemy;
    Vector3 offset;
    private void Start()
    {
        currentGeller = maxGeller;
    }
    public void TargetArmor()
    {
        player = FindObjectOfType<Player>();
        Time.timeScale = 1.0f;
    }
    void LateUpdate()
    {
        enemy = FindObjectOfType<Enemy>();
        offset = player.transform.position;
        transform.position = offset;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            currentGeller -= enemy.damageEnemy;
            currentGellerforBar = currentGeller / maxGeller;
            GellerBarAmount.fillAmount = currentGellerforBar;
            if (currentGeller < 0)
            {
                gameObject.SetActive(false);
                GellerBarAmount.gameObject.SetActive(false);
                GellerBarZero.gameObject.SetActive(false);
            }
        }
    }
    public void UpgradeGellerField()
    {
        currentGeller += 10f;
    }
}
