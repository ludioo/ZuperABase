using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum CharacterDirection { LEFT, RIGHT, JUMP };

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pressed;
    private Player player;
    public CharacterDirection direction;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.GetComponent<Animator>().SetBool("running", false);
        pressed = false;
    }

    private void Update()
    {
        if (pressed)
        {
            switch (direction)
            {
                case CharacterDirection.LEFT:
                    player.GetComponent<Animator>().SetBool("running", true);
                    player.MoveLeft();
                    break;
                case CharacterDirection.RIGHT:
                    player.GetComponent<Animator>().SetBool("running", true);
                    player.MoveRight();
                    break;
            }
        }
    }
}
