using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materi : MonoBehaviour {

    private PopUpController popController;
    private bool interacting;
    [SerializeField]private int asamToProceed;

    public GameObject popUp;

    // Use this for initialization
    void Start () {
        popController = FindObjectOfType<PopUpController>();
        interacting = false;
    }
	
	// Update is called once per frame
	void Update () {
        ShowPopUp();	
	}

    public void ShowPopUp()
    {
        if (popController.interactable && interacting && GameManager.instance.asam >= asamToProceed)
        {
            popUp.SetActive(true);
            interacting = false;
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
        }
    }
}
