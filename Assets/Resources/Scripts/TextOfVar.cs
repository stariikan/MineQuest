using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOfVar : MonoBehaviour
{
    public GameObject textField;
    public Text displayText;
    public string var;
    private void Start()
    {
       var = textField.gameObject.name;
    }
    void Update()
    {
        ChangeText();
    }
    public void ChangeText()
    {
        if (var == "PlayerLvL") displayText.text = "LVL: " + SaveStat.Instance.playerLvl;
        if (var == "PlayerEXP") displayText.text = "EXP: " + SaveStat.Instance.playerExp;
        if (var == "PlayerCoins") displayText.text = "COINS: " + SaveStat.Instance.playerCoins;

    }
}
