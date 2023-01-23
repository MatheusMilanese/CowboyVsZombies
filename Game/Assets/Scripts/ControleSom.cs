using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class ControleSom : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat ("volume", slider.value);
    }

    public void AjustaVolume(float volume){
    mixer.SetFloat ("volume", volume);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
