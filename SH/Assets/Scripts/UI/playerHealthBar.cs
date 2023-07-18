using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerHealthBar : MonoBehaviour
{
    public Health playerHP;
    public Image healthbar;
    
    void Start()
    {
        
    }
    void Update()
    {
        healthbar.fillAmount = Mathf.Lerp(0, 1, playerHP.health/playerHP.maxHealth);
    }
}
