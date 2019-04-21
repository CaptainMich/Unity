﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    public int enemyHealth = 10;
    public GameObject spider;
    public int spiderStatus;
    public float baseExp = 10;
    public float calculatedExp;

    void DeductPoints(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            if(spiderStatus == 0)
            StartCoroutine(DeathSpider());
        }
    }

    IEnumerator DeathSpider()
    {
        spiderStatus = 6;
        calculatedExp = baseExp / GlobalLevel.currentLevel;
        GlobalExp.currentExp +=  calculatedExp;
        yield return new WaitForSeconds(0.5f);
        spider.GetComponent<Animation>().Play("die");
    }
}
