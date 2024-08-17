using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ControlSound : MonoBehaviour
{

    public Slider slider;

    //sound
    public Slider sliderSound;
    public AudioMixer mixer;
    const string mixer1 = "soundValuem";
    const string mixer2 = "musicValuem";


    public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
       
      
    }


    //music

    void SetMusicValume(float value)
    {
        mixer.SetFloat(mixer2, Mathf.Log10(value) * 20);
    }






    //sound

    private void Awake()
    {
        sliderSound.onValueChanged.AddListener(SetSoundValume);
        slider.onValueChanged.AddListener(SetMusicValume);

    }

    void SetSoundValume(float value)
    {
        mixer.SetFloat(mixer1, Mathf.Log10(value) * 20);
    }
}


