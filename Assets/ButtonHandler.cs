using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public CharacterMove c;
    public void setText(){
        // Text txt = transform.Find("Text").GetComponent<Text>();
        // txt.text = text;
        c.Attack();

    }
}
