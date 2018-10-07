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

    // Use this for initialization
    void Start () {
        //sfxBenar = GetComponent<AudioSource>();
        timer = 20;
        popController = FindObjectOfType<PopUpController>();
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
            popUp.SetActive(true);
            interacting = false;
            startTimer = true;
        }
    }


    public void Answer(bool answer)
    {
        if(answer == true)
        {
            AudioManager audioManager;
            audioManager = FindObjectOfType<AudioManager>();
            audioManager.sfxBenar.Play();
            GameManager.instance.soal++;
            popUp.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Player.curHealth--;
            popUp.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
