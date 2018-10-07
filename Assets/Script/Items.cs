using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeChemical
{
    ASAM,
    BASA
}

public class Items : MonoBehaviour {

    [SerializeField]private TypeChemical type;
    private PopUpController popController;
    private bool interacting;

    public Image text;

    private void Start()
    {
        popController = FindObjectOfType<PopUpController>();
    }

    private void Update()
    {
        ShowPopUp();
    }

    void ShowPopUp()
    {
        if (popController.interactable && interacting)
        {
            interacting = false;
            switch(type)
            {
                case TypeChemical.ASAM:
                    GameManager.instance.asam++;
                    Destroy(gameObject);
                    break;
                case TypeChemical.BASA:
                    GameManager.instance.basa++;
                    Destroy(gameObject);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.gameObject.SetActive(true);
            interacting = true;
            popController.triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.gameObject.SetActive(false);
            popController.triggered = false;
            popController.interactable = false;
            interacting = false;
        }
    }
}