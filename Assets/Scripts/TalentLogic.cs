using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TalentLogic : MonoBehaviour
{
    public GameObject[] talent;
    public int numberOfTalentToActivate;
    public GameObject armorUpgrade;
    public GameObject cycleSlowButtonUpgrade;
    public GameObject gellerFieldButtonUprgade;
    public GameObject addHPUpgrade;
    public GameObject cLUButtonUpgrade;
    public void ChoiceTalent()
    {
        // выбор из данного кол-ва талантов numberOfTalentToActivate случайно из массива talent
        GameObject[] randomObjects = talent.OrderBy(obj => Guid.NewGuid()).Take(numberOfTalentToActivate).ToArray();
        // активируем выбранные случайные объекты
        foreach (GameObject obj in randomObjects)
        {
            obj.SetActive(true);
        }
        Time.timeScale = 0.0f;
    }
    public void UpgradeArmor()
    {
        Destroy(talent[0]);
        if (talent.Length > 0)
        {
            talent[0] = armorUpgrade;
        }
    }
    public void UpgradeCycleSlow()
    {
        Destroy(talent[1]);
        if (talent.Length > 0)
        {
            talent[1] = cycleSlowButtonUpgrade;
        }
    }
    public void UpgradeGellerField()
    {
        Destroy(talent[2]);
        if (talent.Length > 0)
        {
            talent[2] = gellerFieldButtonUprgade;
        }
    }
    public void UpgradeAddHP()
    {
        Destroy(talent[3]);
        if (talent.Length > 0)
        {
            talent[3] = addHPUpgrade;
        }
    }
    public void UpgradeCLU()
    {
        Destroy(talent[4]);
        if (talent.Length > 0)
        {
            talent[4] = cLUButtonUpgrade;
        }
    }
}
