using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hudDisplay : MonoBehaviour
{
    public TextMeshProUGUI[] hpText;
    public TextMeshProUGUI[] bombText;

    // Array initialization has to be done before Start() in CharacterStats,
    // That's why awake used
    void Awake() {
        int hpInd = 0, bombInd = 0;
        hpText = new TextMeshProUGUI[4];
        bombText = new TextMeshProUGUI[4];
        foreach(Transform child in transform) {
            if(child.gameObject.name.StartsWith('B')) {
                bombText[bombInd] = child.GetComponentInChildren<TextMeshProUGUI>();
                bombInd++;
            }
            else if(child.gameObject.name.StartsWith('H')) {
                hpText[hpInd] = child.GetComponentInChildren<TextMeshProUGUI>();
                hpInd++;
            }
        }
    }

    public void setHP(int playerNum, int val) {
        hpText[playerNum-1].text = val.ToString();
    }

    public void setBombs(int playerNum, int val) {
        bombText[playerNum-1].text = val.ToString();
    }
}
