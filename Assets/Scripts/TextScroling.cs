using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextScroling : MonoBehaviour
{
    public TMP_Text talebobleText;
    public string [] talkLines = {
        "<sprite=0><sprite=1><sprite=1><sprite=1><sprite=1><sprite=2> <sprite=0><sprite=1><sprite=2>",
        "<sprite=0><sprite=1><sprite=1><sprite=2> <sprite=0><sprite=1><sprite=1><sprite=1><sprite=2>"
    };
    public float timeBetweenCharecters;
    public float timer;
    public int charectorIndex;
    public int lineIndex;
    public bool newTB  = false;
    public float boubleDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            if(talkLines[lineIndex].Length <= charectorIndex){
                lineIndex++;
                charectorIndex = 0;
                if(newTB == false){
                    talebobleText.text += "<br>";
                    newTB = true;
                }else{
                    talebobleText.text = "";
                    newTB = false;
                    if(talkLines.Length <= lineIndex){
                        lineIndex = 0;
                    }
                    timer += Random.Range( timeBetweenCharecters*2, boubleDelay);
                }

            }else{
                switch (talkLines[lineIndex][charectorIndex]){
                    case '<':
                        talebobleText.text += "<sprite=";
                        talebobleText.text += talkLines[lineIndex][charectorIndex+8]; 
                        talebobleText.text += ">";
                        charectorIndex += 9;
                        break;
                    case ' ':
                        timer += timeBetweenCharecters*3;
                        talebobleText.text += talkLines[lineIndex][charectorIndex];
                        break;
                    case '$':
                        //wait
                        //clap
                        //wait
                        break;
                    default:
                        talebobleText.text += talkLines[lineIndex][charectorIndex];
                        break;

                }
                timer += timeBetweenCharecters;
                charectorIndex++;
            }
        }
        
    }
}
