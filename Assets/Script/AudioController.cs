using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour {

    public Slider volumeSlider;

	// Use this for initialization
	void Start () {

	
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
	}
	// Update is called once per frame
	void Update () {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
	}
}