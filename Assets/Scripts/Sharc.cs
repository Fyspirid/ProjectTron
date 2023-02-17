using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sharc : MonoBehaviour
{
    private float timerForAddHP;
    private float timerWorkSharc;
    private float addHealth = 1f;
    Health health;
    Player player;
    Vector3 offset;
    private void LateUpdate()
    {
        // обнаружение и следованием за Player и таймер действи€ Sharc
        offset = player.transform.position;
        transform.position = offset;
        timerWorkSharc -= Time.deltaTime;
        if (timerWorkSharc > 0)
        {
            timerForAddHP -= Time.deltaTime;
            if (timerForAddHP < 0)
            {
                health.currentHealth += addHealth;
                timerForAddHP = 1f;
            }
        }
        else
            gameObject.SetActive(false);
    }
    public void ActivatedSharc()
    {
        timerWorkSharc = 10f;
        timerForAddHP = 1f;
        health = FindObjectOfType<Health>();
        player = FindObjectOfType<Player>();
        Time.timeScale = 1f;
    }
    public void UpgradeSharc()
    {
        addHealth = 2f;
    }
}
