using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerHealth : MonoBehaviour
{
    public float healthInit = 5.0f;
    public float coolDownDamage = 1.0f;
    public Slider bar;
    public float barAlternative;
    private float health=10.0f;
    private bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        health = healthInit;
        if (bar != null)
            bar.maxValue = healthInit;
        //if (health < healthInit)
        //    bar.value = health;
        UpdateBar();
    }
    public void GetDamage(float damage)
    {
        if (invulnerable)
            return;
        //StartCoroutine("CoolDownDamage");
        //if (health == 0f)
        //    return;
        health -= damage;

        health = Mathf.Max(health, 0.0f);
        Debug.Log("Antes de actualizar barra");
        UpdateBar();
        if (health == 0f || health < 0f)
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
        Debug.Log("la salud es: " + health);
        if (bar != null)
            bar.value = health;
    }
}
