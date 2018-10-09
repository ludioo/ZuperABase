using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public bool interactable;
    public bool triggered;

	void Start () {
        interactable = false;
        triggered = false;
	}
	
    public void Click()
    {
        if (triggered)
        {
            interactable = true;
        }
    }
}
