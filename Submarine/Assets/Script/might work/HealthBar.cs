using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image currentHealthbar;
    public Text ratioText;

    public float hitpoint = 100.0f;
    public float maxHitpoint = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthbar();
    }

    // Update is called once per frame
    void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1.0f, 1.0f);
        //ratioText.text = (ratio * 100).ToString('0') + '%';
    }

    void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if(hitpoint <0)
        {
            hitpoint = 0;
            Debug.Log("Dead!");
        }
        UpdateHealthbar();
    }

    void HealDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }
        UpdateHealthbar();
    }
}
