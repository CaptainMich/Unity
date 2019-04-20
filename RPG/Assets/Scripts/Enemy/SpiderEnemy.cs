using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    public int enemyHealth = 10;

    void DeductPoints(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            StartCoroutine(DeathSpider());
            Destroy(gameObject);
        }
    }

    IEnumerator DeathSpider()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
