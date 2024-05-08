using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] songs;
    private bool music_settings;
    private float volume;
    public Text displayText;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (!_audioSource.isPlaying) ChangeSong(Random.Range(0, songs.Length));
        volume = _audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        music_settings = SaveStat.Instance.sound;
        if (!music_settings) _audioSource.volume = 0;
        if (music_settings) _audioSource.volume = volume;

        if (!_audioSource.isPlaying) ChangeSong(Random.Range(0, songs.Length));
        ChangeText();
    }
    public void ChangeSong(int songPicked)
    {
        _audioSource.clip = songs[songPicked];
        _audioSource.Play();
    }
    public void ChangeText()
    {
        bool soundsettings = SaveStat.Instance.sound;
        if (soundsettings) displayText.text = "Sound: ON";
        else displayText.text = "Sound: OFF";

    }
}
