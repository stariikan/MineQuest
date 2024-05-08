using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    public int platform; //PC = 1, AN = 2, Editor = 0
    public static Startup Instance { get; set; }
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer ||
    Application.platform == RuntimePlatform.LinuxPlayer) // PC platform
        {
            Debug.Log("PC platform");
            platform = 1;
        }
        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) // Mobile platform
        {
            Debug.Log("Mobile Platform");
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.orientation = ScreenOrientation.Portrait;
            platform = 2;

        }
        else //Unity editor
        {
            Debug.Log("Unity platform");
            platform = 0;
            //this.gameObject.SetActive(false);
        }
    }
}
