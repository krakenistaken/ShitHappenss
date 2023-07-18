using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI textMP;
    public string[] lines;
    public float textspeed;

    private int index;

    void Start()
    {
        textMP.text = string.Empty;
        startDialouge();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textMP.text += c;
            yield return new WaitForSeconds(textspeed); 
        }
    }

    void nextline()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textMP.text = string.Empty;
            StartCoroutine(TypeLine());
        }else gameObject.SetActive(false);
    }

    void OnNextDialouge()
    {
        if (textMP.text == lines[index])
        {
            nextline();
        }
        else { 
            StopAllCoroutines();
            textMP.text = lines[index];
        }
    }
}
