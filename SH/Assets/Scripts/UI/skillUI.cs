using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillUI : MonoBehaviour
{
    public SkillSystem skillSystem;

    public bool waterEnabled;
    public bool fireEnabled;
    public bool lightEnabled;
    public bool electricEnabled;

    public Image fire;
    public Image water;
    public Image electric;
    public Image lightr;
    public Image ashtrayB;
    public Image electroBubble;
    public Image lightburn;
    public Image stormlight;
    public Image wetLight;
    public Image electroblast;

    public int selectedslot;

    void Start()
    {
        waterEnabled = true;
        electricEnabled = true;
        fireEnabled = true;
        lightEnabled = true;
    }

    void Update()
    {
        if (waterEnabled) water.color = new Color(1f, 1f, 1f, 1f); else water.color = new Color(1f, 1f, 1f, 0.6f);

        if (fireEnabled) fire.color = new Color(1f, 1f, 1f, 1f); else fire.color = new Color(1f, 1f, 1f, 0.6f);

        if (electricEnabled) electric.color = new Color(1f, 1f, 1f, 1f); else electric.color = new Color(1f, 1f, 1f, 0.6f);

        if (lightEnabled) lightr.color = new Color(1f, 1f, 1f, 1f);else lightr.color = new Color(1f, 1f, 1f, 0.6f);

        if (lightEnabled && electricEnabled) stormlight.color = new Color(1f, 1f, 1f, 1f); else stormlight.color = new Color(1f, 1f, 1f, 0.6f);

        if (lightEnabled && waterEnabled) wetLight.color = new Color(1f, 1f, 1f, 1f); else wetLight.color = new Color(1f, 1f, 1f, 0.6f);
        
        if (lightEnabled && fireEnabled) lightburn.color = new Color(1f, 1f, 1f, 1f); else lightburn.color = new Color(1f, 1f, 1f, 0.6f);

        if (fireEnabled && waterEnabled) ashtrayB.color = new Color(1f, 1f, 1f, 1f); else ashtrayB.color = new Color(1f, 1f, 1f, 0.6f);
        
        if (fireEnabled && electricEnabled) electroblast.color = new Color(1f, 1f, 1f, 1f); else electroblast.color = new Color(1f, 1f, 1f, 0.6f);

        if (waterEnabled && electricEnabled) electroBubble.color = new Color(1f, 1f, 1f, 1f); else electroBubble.color = new Color(1f, 1f, 1f, 0.6f);
    }
    public void selectSlot1() {
        selectedslot = 1; 
    }
    public void selectSlot2()
    {
        selectedslot = 2;
    }
    public void selectSlot3()
    {
        selectedslot = 3;
    }
    public void selectSlot4()
    {
        selectedslot = 4;
    }

    public void setToFire()
    {
        if (selectedslot == 1 && fireEnabled) { skillSystem.slot1 = "Fire"; }
        if (selectedslot == 2 && fireEnabled) { skillSystem.slot2 = "Fire"; }
        if (selectedslot == 3 && fireEnabled) { skillSystem.slot3 = "Fire"; }
        if (selectedslot == 4 && fireEnabled) { skillSystem.slot4 = "Fire"; }
    
    }
    public void setToElectric()
    {
        if (selectedslot == 1 && electricEnabled) { skillSystem.slot1 = "Electric"; }
        if (selectedslot == 2 && electricEnabled) { skillSystem.slot2 = "Electric"; }
        if (selectedslot == 3 && electricEnabled) { skillSystem.slot3 = "Electric"; }
        if (selectedslot == 4 && electricEnabled) { skillSystem.slot4 = "Electric"; }

    }
    public void setToWater()
    {
        if (selectedslot == 1 && waterEnabled) { skillSystem.slot1 = "Water"; }
        if (selectedslot == 2 && waterEnabled) { skillSystem.slot2 = "Water"; }
        if (selectedslot == 3 && waterEnabled) { skillSystem.slot3 = "Water"; }
        if (selectedslot == 4 && waterEnabled) { skillSystem.slot4 = "Water"; }

    }
    public void setToLight()
    {
        if (selectedslot == 1 && lightEnabled) { skillSystem.slot1 = "Light"; }
        if (selectedslot == 2 && lightEnabled) { skillSystem.slot2 = "Light"; }
        if (selectedslot == 3 && lightEnabled) { skillSystem.slot3 = "Light"; }
        if (selectedslot == 4 && lightEnabled) { skillSystem.slot4 = "Light"; }

    }
    public void setToElectroblast()
    {
        if (selectedslot == 1 && fireEnabled && electricEnabled) { skillSystem.slot1 = "Electroblast"; }
        if (selectedslot == 2 && fireEnabled && electricEnabled) { skillSystem.slot2 = "Electroblast"; }
        if (selectedslot == 3 && fireEnabled && electricEnabled) { skillSystem.slot3 = "Electroblast"; }
        if (selectedslot == 4 && fireEnabled && electricEnabled) { skillSystem.slot4 = "Electroblast"; }

    }
    public void setToElectrobubble()
    {
        if (selectedslot == 1 && electricEnabled && waterEnabled) { skillSystem.slot1 = "Electrobubble"; }
        if (selectedslot == 2 && electricEnabled && waterEnabled) { skillSystem.slot2 = "Electrobubble"; }
        if (selectedslot == 3 && electricEnabled && waterEnabled) { skillSystem.slot3 = "Electrobubble"; }
        if (selectedslot == 4 && electricEnabled && waterEnabled) { skillSystem.slot4 = "Electrobubble"; }

    }
    public void setToAshtraysmoke()
    {
        if (selectedslot == 1 && fireEnabled && waterEnabled) { skillSystem.slot1 = "Ashtraysmoke"; }
        if (selectedslot == 2 && fireEnabled && waterEnabled) { skillSystem.slot2 = "Ashtraysmoke"; }
        if (selectedslot == 3 && fireEnabled && waterEnabled) { skillSystem.slot3 = "Ashtraysmoke"; }
        if (selectedslot == 4 && fireEnabled && waterEnabled) { skillSystem.slot4 = "Ashtraysmoke"; }

    }
    public void setToLightburn()
    {
        if (selectedslot == 1 && fireEnabled && lightEnabled) { skillSystem.slot1 = "Lightburn"; }
        if (selectedslot == 2 && fireEnabled && lightEnabled) { skillSystem.slot2 = "Lightburn"; }
        if (selectedslot == 3 && fireEnabled && lightEnabled) { skillSystem.slot3 = "Lightburn"; }
        if (selectedslot == 4 && fireEnabled && lightEnabled) { skillSystem.slot4 = "Lightburn"; }

    }
    public void setToStormlight()
    {
        if (selectedslot == 1 && electricEnabled && lightEnabled) { skillSystem.slot1 = "Stormlight"; }
        if (selectedslot == 2 && electricEnabled && lightEnabled) { skillSystem.slot2 = "Stormlight"; }
        if (selectedslot == 3 && electricEnabled && lightEnabled) { skillSystem.slot3 = "Stormlight"; }
        if (selectedslot == 4 && electricEnabled && lightEnabled) { skillSystem.slot4 = "Stormlight"; }

    }
    public void setToWetlight()
    {
        if (selectedslot == 1 && waterEnabled && lightEnabled) { skillSystem.slot1 = "Wetlight"; }
        if (selectedslot == 2 && waterEnabled && lightEnabled) { skillSystem.slot2 = "Wetlight"; }
        if (selectedslot == 3 && waterEnabled && lightEnabled) { skillSystem.slot3 = "Wetlight"; }
        if (selectedslot == 4 && waterEnabled && lightEnabled) { skillSystem.slot4 = "Wetlight"; }

    }

}
