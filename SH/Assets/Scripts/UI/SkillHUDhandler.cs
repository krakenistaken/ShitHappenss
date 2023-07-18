using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHUDhandler : MonoBehaviour
{
    public SkillSystem skillScript;

    public float s1CD;
    public float s2CD;
    public float s3CD;
    public float s4CD;

    public Image skill1CD;
    public Image skill2CD;
    public Image skill3CD;
    public Image skill4CD;

    private void Start()
    {
        skillScript = GameObject.Find("rockbud").GetComponent<SkillSystem>();
    }

    private void Update()
    {
        Slot1(); Slot2(); Slot3(); Slot4();
    }

    void Slot1() { }
    void Slot2() { }
    void Slot3() { }
    void Slot4() { }
    
}
