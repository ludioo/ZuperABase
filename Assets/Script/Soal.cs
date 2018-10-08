using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soal : MonoBehaviour {

    private PopUpController popController;
    private bool interacting;
    private bool startTimer;
    private float timer;

    public Text txtTimer;
    public GameObject popUp;
    private AudioManager audioManager;


    // Use this for initialization
    void Start () {
        timer = 20;
        popController = FindObjectOfType<PopUpController>();
        audioManager = FindObjectOfType<AudioManager>();
        interacting = false;
        startTimer = false;
    }
	
	// Update is called once per frame
	void Update () {
        txtTimer.text = "Time = " + (int)timer;
        ShowPopUp();
        if (startTimer)
        {
            timer -= 1 * Time.deltaTime;
        }
        if (timer <= 0)
        {
            audioManager.sfxSalah.Play();
            timer = 20;
            startTimer = false;
            Player.curHealth--;
            popUp.SetActive(false);
            
        }
    }

    public void ShowPopUp()
    {
        if(popController.interactable && interacting)
        {
            audioManager.sfxBuku.Play();
            audioManager.sfxTimer.Play();
            popUp.SetActive(true);
            interacting = false;
            startTimer = true;
        }
    }


    public void Answer(bool answer)
    {
        if(answer == true)
        {
            audioManager.sfxBenar.Play();
            GameManager.instance.soal++;
            popUp.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            audioManager.sfxSalah.Play();
            Player.curHealth--;
            popUp.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioManager.sfxSoal.Play();
            interacting = true;
            popController.triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            popController.triggered = false;
            popController.interactable = false;
            interacting = false;
            startTimer = false;
            timer = 20;
        }
    }
}
