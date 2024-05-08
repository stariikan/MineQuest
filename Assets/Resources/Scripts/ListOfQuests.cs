using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class ListOfQuests : MonoBehaviour
{
    public Text displayText;
    public string[] item;
    //public string ItemsfilePath = "Assets/TextFiles/items.txt"; // Path to your text file
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl)) ShowRandomText();
    }
    public void ShowRandomText() 
    {
        // Select a random item from the list
        string randomItem = item[Random.Range(0, item.Length)];
        // Display the random item
        displayText.text = "Get: " + Random.Range(1, 30) + " " + randomItem;
    }
}