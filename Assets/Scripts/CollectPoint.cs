using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectPoint : MonoBehaviour
{
    public float point;
    public int level = 1;
    public Canvas levelUpperPlayer;
    public Image imgPoint;
    public TMP_Text textCurrentLevel;
    public GameObject talent;
    private TalentLogic _talentCall;
    private float currentPoint;
    private float maxPoint = 100f;
    void Update()
    {
        ScoringLogic();
    }
    public void ScoringLogic()
    {
        currentPoint = point / maxPoint;
        imgPoint.fillAmount = currentPoint;
        if (point > maxPoint) //проверка уровня Игрока
        {
            //логика запуска выбора талантов
            _talentCall = talent.GetComponent<TalentLogic>();
            level += 1;
            textCurrentLevel.text = level.ToString();
            point = 0;
            Time.timeScale = 0;
            _talentCall.ChoiceTalent();
            levelUpperPlayer.gameObject.SetActive(true);
            maxPoint *= 2;
        }
    }
}
