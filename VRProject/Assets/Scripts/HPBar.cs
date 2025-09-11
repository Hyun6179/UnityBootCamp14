using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public int curHealth {  get; private set; }
    public int maxHealth = 100;
    public Slider HpBarSlider;
    public void SetHP()
    {
        this.maxHealth = 100;
        this.curHealth = maxHealth;
    }


    public void CheckHP()
    {
        if (HpBarSlider != null)
        {
            HpBarSlider.value = curHealth;
        }
    }

    public void getDamage(int damage)
    {
        curHealth -= damage;
        CheckHP();
        if (curHealth <= 0) { /* 체력이 0 이므로 게임종료, 즉 사망*/};
    }

}
