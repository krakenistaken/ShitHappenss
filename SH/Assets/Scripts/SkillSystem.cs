using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSystem : MonoBehaviour
{
    bool ableToFire = true;
    bool ableToElectric = true;
    bool ableToWater = true;
    bool ableToLight = true;
    bool ableToElectroblast = true;
    bool ableToElectrobubble = true;
    bool ableToAshtraysmoke = true;
    bool ableToLightburn = true;
    bool ableToStormlight = true;
    bool ableToWetlight = true;


    [Header("slots")]
    public string slot1;
    public string slot2;
    public string slot3;
    public string slot4;

    [Header("cooldowns")]
    public float FireCD;
    public float ElectricCD;
    public float WaterCD;
    public float LightCD;
    public float ElectroblastCD;
    public float ElectrobubbleCD;
    public float AshtraysmokeCD;
    public float LightburnCD;
    public float StormlightCD;
    public float WetlightCD;

    [Header("prefabs")]
    public GameObject waterBubble;
    public GameObject ashtraySmoke;
    public GameObject electric;

    [Header("spawnpositions")]
    public Transform WaterBubbleSpawner;

    public SkillHUDhandler SkillHUDhandler;

    private void Start()
    {
        SkillHUDhandler = GameObject.Find("HUD").GetComponent<SkillHUDhandler>();
    }

    //Fire Electric Water Light Electroblast Electrobubble Ashtraysmoke Lightburn Stormlight Wetlight
    public void OnSkill1(){
        if (slot1 == "Fire") { Fire(); SkillHUDhandler.s1CD = FireCD; }
        else if (slot1 == "Electric") { Electric(); SkillHUDhandler.s1CD = ElectricCD; }
        else if (slot1 == "Water") { Water(); SkillHUDhandler.s1CD = WaterCD; }
        else if (slot1 == "Light") { Light(); SkillHUDhandler.s1CD = LightCD; }
        else if (slot1 == "Electroblast") { Electroblast(); SkillHUDhandler.s1CD = ElectroblastCD; }
        else if (slot1 == "Electrobubble") { Electrobubble(); SkillHUDhandler.s1CD = ElectrobubbleCD; }
        else if (slot1 == "Ashtraysmoke") { Ashtraysmoke(); SkillHUDhandler.s1CD = AshtraysmokeCD; }
        else if (slot1 == "Lightburn") { Lightburn(); SkillHUDhandler.s1CD = LightburnCD; }
        else if (slot1 == "Stormlight") { Stormlight(); SkillHUDhandler.s1CD = StormlightCD; }
        else if (slot1 == "Wetlight") { Wetlight(); SkillHUDhandler.s1CD = WetlightCD; }
    }
    public void OnSkill2(){
        if (slot2 == "Fire") { Fire(); SkillHUDhandler.s2CD = FireCD; }
        else if (slot2 == "Electric") { Electric(); SkillHUDhandler.s2CD = ElectricCD; }
        else if (slot2 == "Water") { Water(); SkillHUDhandler.s2CD = WaterCD; }
        else if (slot2 == "Light") { Light(); SkillHUDhandler.s2CD = LightCD; }
        else if (slot2 == "Electroblast") { Electroblast(); SkillHUDhandler.s2CD = ElectroblastCD; }
        else if (slot2 == "Electrobubble") { Electrobubble(); SkillHUDhandler.s2CD = ElectrobubbleCD; }
        else if (slot2 == "Ashtraysmoke") { Ashtraysmoke(); SkillHUDhandler.s2CD = AshtraysmokeCD; }
        else if (slot2 == "Lightburn") { Lightburn(); SkillHUDhandler.s2CD = LightburnCD; }
        else if (slot2 == "Stormlight") { Stormlight(); SkillHUDhandler.s2CD = StormlightCD; }
        else if (slot2 == "Wetlight") { Wetlight(); SkillHUDhandler.s2CD = WetlightCD; }
    }
    public void OnSkill3(){
        if (slot3 == "Fire") { Fire(); SkillHUDhandler.s3CD = FireCD; }
        else if (slot3 == "Electric") { Electric(); SkillHUDhandler.s3CD = ElectricCD; }
        else if (slot3 == "Water") { Water(); SkillHUDhandler.s3CD = WaterCD; }
        else if (slot3 == "Light") { Light(); SkillHUDhandler.s3CD = LightCD; }
        else if (slot3 == "Electroblast") { Electroblast(); SkillHUDhandler.s3CD = ElectroblastCD; }
        else if (slot3 == "Electrobubble") { Electrobubble(); SkillHUDhandler.s3CD = ElectrobubbleCD; }
        else if (slot3 == "Ashtraysmoke") { Ashtraysmoke(); SkillHUDhandler.s3CD = AshtraysmokeCD; }
        else if (slot3 == "Lightburn") { Lightburn(); SkillHUDhandler.s3CD = LightburnCD; }
        else if (slot3 == "Stormlight") { Stormlight(); SkillHUDhandler.s3CD = StormlightCD; }
        else if (slot3 == "Wetlight") { Wetlight(); SkillHUDhandler.s3CD = WetlightCD; }
    }
    public void OnSkill4(){
        if (slot4 == "Fire") { Fire(); SkillHUDhandler.s4CD = FireCD; }
        else if (slot4 == "Electric") { Electric(); SkillHUDhandler.s4CD = ElectricCD; }
        else if (slot4 == "Water") { Water(); SkillHUDhandler.s4CD = WaterCD; }
        else if (slot4 == "Light") { Light(); SkillHUDhandler.s4CD = LightCD; }
        else if (slot4 == "Electroblast") { Electroblast(); SkillHUDhandler.s4CD = ElectroblastCD; }
        else if (slot4 == "Electrobubble") { Electrobubble(); SkillHUDhandler.s4CD = ElectrobubbleCD; }
        else if (slot4 == "Ashtraysmoke") { Ashtraysmoke(); SkillHUDhandler.s4CD = AshtraysmokeCD; }
        else if (slot4 == "Lightburn") { Lightburn(); SkillHUDhandler.s4CD = LightburnCD; }
        else if (slot4 == "Stormlight") { Stormlight(); SkillHUDhandler.s4CD = StormlightCD; }
        else if (slot4 == "Wetlight") { Wetlight(); SkillHUDhandler.s4CD = WetlightCD; }
    }

    
    //skill Fs to call are below
    private void Fire() {
        
    }
    private void Electric()
    {
        if (ableToElectric)
        {
            Invoke("readyToElectric", ElectricCD);
            Instantiate(electric, transform.position, Quaternion.identity);
            ableToElectric = false;

        }
    }
    private void Water(){
        if (ableToWater){
            Invoke("readyToWater", WaterCD);
            Instantiate(waterBubble, WaterBubbleSpawner.position, Quaternion.identity);
            ableToWater = false;
        }}
    private void Light(){

    }
    private void Electroblast(){

    }
    private void Electrobubble(){

    }
    private void Ashtraysmoke(){
        if (ableToAshtraysmoke){
            Invoke("readyToAshtraysmoke", AshtraysmokeCD);
            Instantiate(ashtraySmoke, transform.position, Quaternion.identity);
            ableToAshtraysmoke = false;
        }}
    private void Lightburn(){

    }
    private void Stormlight(){

    }
    private void Wetlight(){

    }
    
    
    void readyToWater(){
        ableToWater = true;
    }
    void readyToFire()
    {
        ableToFire = true;
    }
    void readyToAshtraysmoke()
    {
        ableToAshtraysmoke = true;
    }
    void readyToLight()
    {
        ableToLight = true;
    }
    void readyToElectric()
    {
        ableToElectric = true;
    }
    void readyToElectroblast()
    {
        ableToElectroblast = true;
    }
    void readyToElectrobubble()
    {
        ableToElectrobubble = true;
    }
    void readyToLightburn()
    {
        ableToLightburn = true;
    }
    void readyToStormlight()
    {
        ableToStormlight = true;
    }
    void readyToWetlight()
    {
        ableToWetlight = true;
    }
}