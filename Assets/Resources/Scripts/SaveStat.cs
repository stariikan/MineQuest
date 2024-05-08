using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement; // for scene management
using Random = UnityEngine.Random;

public class SaveStat : MonoBehaviour
{
    public float playerExp;
    public float playerCoins;
    public int passedQuest;

    public float playerLvl;

    //Settings
    public bool localization; //Eng/Ru
    public bool sound = true; //The sound is switched on
    public bool music = true; //The music is on
    public static SaveStat Instance { get; set; } // To collect and send data from this script

    private void Awake()
    {
        Instance = this;
        LoadlSetting(); //loading data from previously set game settings
        LoadGame();
    }
    //Create a new serializable SaveData class to contain the data to be saved
    [Serializable]
    class SaveData
    {
        public float playerExp;
        public float playerLvl;
        public float playerCoins;
        public int passedQuest;
    }
    //notice that the three variables in the SaveData class correspond to variables from the SaveSerial class.
    //We will pass values from SaveSerial to SaveData and then serialise the latter.
    [Serializable]
    class SaveSettings
    {
        //Settings
        public bool localization; //Eng/Ru
        public bool sound; //The sound is switched on
        public bool music; //The music is on
    }
    //Add the SaveGame method to the SaveSerial class:
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); //The BinaryFormatter object is designed for serialization and deserialization.
                                                    //In serialisation it is responsible for converting the information into a stream of binary data (zeros and ones).

        FileStream file = File.Create(Application.persistentDataPath //FileStream and File are needed to create a file with a .dat extension.
                                                                     //The Application.persistentDataPath constant contains the path to the project files: C:\Users\[user]\AppData\LocalLow\[company name].
          + "/SessionData.dat");
        SaveData data = new SaveData(); //The SaveGame method creates a new instance of the SaveData class. The current data from SaveSerial to be saved is written into it.
                                        //BinaryFormatter serializes this data and writes it to the file created by FileStream. The file is then closed and a successful save message is displayed in the console.


        data.playerExp = playerExp;
        data.playerLvl = playerLvl;
        data.playerCoins = playerCoins;
        data.passedQuest = passedQuest;

        //data.savedBool = boolToSave;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
    public void SaveLastGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); //The BinaryFormatter object is intended for serialisation and deserialisation.
                                                    //In serialisation it is responsible for converting the information into a stream of binary data (zeros and ones).

        FileStream file = File.Create(Application.persistentDataPath //FileStream and File are needed to create a file with a .dat extension.
                                                                     //The Application.persistentDataPath constant contains the path to the project files: C:\Users\[user]\AppData\LocalLow\[company name].
          + "/LastSessionData.dat");
        SaveData data = new SaveData(); //The SaveGame method creates a new instance of the SaveData class. The current data from SaveSerial to be saved is written into it.
                                        //BinaryFormatter serializes this data and writes it to the file created by FileStream. The file is then closed and a successful save message is displayed in the console.

        data.playerExp = playerExp;
        data.playerLvl = playerLvl;
        data.playerCoins = playerCoins;
        data.passedQuest = passedQuest;

        //data.savedBool = boolToSave;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
    public void SaveSetting()
    {
        BinaryFormatter bf = new BinaryFormatter(); //The BinaryFormatter object is intended for serialisation and deserialisation.
                                                    //In serialisation it is responsible for converting the information into a stream of binary data (zeros and ones).

        FileStream file = File.Create(Application.persistentDataPath //FileStream and File are needed to create a file with a .dat extension.
                                                                     //The Application.persistentDataPath constant contains the path to the project files: C:\Users\[user]\AppData\LocalLow\[company name].
          + "/SettingsData.dat");
        SaveSettings data = new SaveSettings(); //The SaveGame method creates a new instance of the SaveData class. The current data from SaveSerial to be saved is written into it.
                                                //BinaryFormatter serializes this data and writes it to the file created by FileStream. The file is then closed and a successful save message is displayed in the console.

        data.localization = localization;
        data.sound = sound;
        data.music = music;

        //data.savedBool = boolToSave;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Settings data saved!");
    }
    //The LoadGame method is, as before, SaveGame in reverse:
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/SessionData.dat")) //First, look for the file with the saved data that we created in the SaveGame method.
        {
            BinaryFormatter bf = new BinaryFormatter(); //If it exists, open it and deserialise it with BinaryFormatter.
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/SessionData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file); // Передаем записанные в нем значения в переменные класса SaveSerial.
            file.Close();
            
            playerExp = data.playerExp;
            playerLvl = data.playerLvl;
            playerCoins = data.playerCoins;;
            passedQuest = data.passedQuest;

            Debug.Log("Game data loaded!"); //Put a message on the debug console stating that the download was successful.
        }
        else
            Debug.LogWarning("There is no save data!"); //If the data file is not in the project folder, the console will display an error message.
    }
    public void LoadlLastGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/LastSessionData.dat")) //First, look for the file with the saved data that we created in the SaveGame method.
        {
            BinaryFormatter bf = new BinaryFormatter(); //If it exists, open it and deserialise it with BinaryFormatter.
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/LastSessionData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file); // Pass the values written in it to the SaveSerial class variables.
            file.Close();

            playerExp = data.playerExp;
            playerLvl = data.playerLvl;
            playerCoins = data.playerCoins;
            passedQuest = data.passedQuest;

            Debug.Log("Game data loaded!"); //Put a message on the debug console stating that the download was successful.
        }
        else
            Debug.LogWarning("There is no save data!"); //If the data file is not in the project folder, the console will display an error message.
    }
    public void LoadlSetting()
    {
        if (File.Exists(Application.persistentDataPath
          + "/SettingsData.dat")) //First, look for the file with the saved data that we created in the SaveGame method.
        {
            BinaryFormatter bf = new BinaryFormatter(); //If it exists, open it and deserialise it with BinaryFormatter.
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/SettingsData.dat", FileMode.Open);
            SaveSettings data = (SaveSettings)bf.Deserialize(file); // Pass the values written in it to the SaveSerial class variables.
            file.Close();

            localization = data.localization;
            sound = data.sound;
            music = data.music;

            Debug.Log("Settings loaded!"); //Put a message on the debug console stating that the download was successful.
        }
        else
            Debug.LogWarning("There is no save data!"); //If the data file is not in the project folder, the console will display an error message.
    }
    //Reset
    //Finally, let's implement a method to reset the save.This is similar to the ResetData we wrote to clear PlayerPrefs, but includes a couple of extra steps.
    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/SessionData.dat")) //First, make sure that the file we want to delete exists. 
        {
            File.Delete(Application.persistentDataPath
              + "/SessionData.dat");
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogWarning("No save data to delete.");//If the file does not exist, output an error message.
        playerCoins = 0;
        playerExp = 0;
        playerLvl= 1;
    }
    public void IncreasePlayerExp()
    {
        playerExp += Random.Range(17, 31);
        if (playerExp > 100)
        {
            playerExp -= 100;
            IncreasePlayerLvl();
        }
    }
    public void IncreasePlayerCoins()
    {
        playerCoins += Random.Range(1, 5);
    }
    public void IncreasePassedQuest()
    {
        passedQuest += 1;
    }
    public void IncreasePlayerLvl() 
    {
        playerLvl += 1;
    }
    public void ChangeLocalizationSetting()
    {
        if (localization == false)
        {
            localization = true;
        }
        else
        {
            localization = false;
        }
    }
    public void ChangeMuiscSetting()
    {
        if (music == false)
        {
            music = true;
        }
        else
        {
            music = false;
        }
    }
    public void ChangeSoundSetting()
    {
        if (sound == false)
        {
            sound = true;
        }
        else
        {
            sound = false;
        }
    }
    private void Update()
    {
        if (playerLvl == 0) playerLvl = 1 ;
    }
}
