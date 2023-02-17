using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorPlayer : MonoBehaviour
{
    private float currentArmor;
    private float currentArmorforBar; 
    public float maxArmor;
    [SerializeField] private Image ArmorBarAmount;
    [SerializeField] private Image ArmorBarZero;
    Player player;
    Enemy enemy;
    Vector3 offset;
    private void Start()
    {
        currentArmor = maxArmor;
    }
    // ������ ������ ������� ������
    public void TargetArmor()
    {
        //��� ��������� ������ ���������� ����� ������� � �������� ����� ���������� 
        player = FindObjectOfType<Player>();
        Time.timeScale = 1.0f;
    }
    void LateUpdate()
    {
        //���������� �� Player
        enemy = FindObjectOfType<Enemy>();
        offset = player.transform.position;
        transform.position = offset;
    }
    //��� ������� ������ ���������� ������ � �����������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            currentArmor -= enemy.damageEnemy;
            currentArmorforBar = currentArmor / maxArmor;
            ArmorBarAmount.fillAmount = currentArmorforBar;
            if (currentArmor < 0)
            {
                gameObject.SetActive(false);
                ArmorBarAmount.gameObject.SetActive(false);
                ArmorBarZero.gameObject.SetActive(false);
            }
        }
    }
    public void UpgradeArmor()
    {
        currentArmor += 10f;
    }
}
