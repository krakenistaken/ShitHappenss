using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health hpScript;
    public Image whitebar;

    private void Start()
    {
        hpScript = gameObject.GetComponentInParent < Health > ();
        whitebar = GetComponent<Image> ();
    }

    private void Update()
    {
        whitebar.fillAmount = hpScript.health / hpScript.maxHealth;
    }
}
