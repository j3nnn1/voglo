using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHealth : MonoBehaviour
{
    public float healthInit = 10.0f;
    public float coolDownDamage = 1.0f;
    //public Slider bar;
    public float bar;
    public float health;
    private bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        //if (bar != null) {
            //bar.maxValue = healthInit;
            //bar = healthInit;

            //}
        health = healthInit;
        UpdateBar();
    }
    public void getDamage(float damage)
    {
        if (invulnerable)
            return;
        StartCoroutine("CoolDownDamage");
        if (health == 0f)
            return;
        health -= damage;

        health = Mathf.Max(health, 0.0f);
        UpdateBar();
        if (health == 0f)
            SendMessage("OnDeath");
    }
    IEnumerable CoolDownDamage()
    {
        invulnerable = true;
        yield return new WaitForSeconds(coolDownDamage);
        invulnerable = false;
    }
    private void UpdateBar()
    {
        //if (bar != null) {
            //bar.value = health;
        bar = health;
        Debug.Log("la Salud esta en: "+ bar);
        //}
    }
}
