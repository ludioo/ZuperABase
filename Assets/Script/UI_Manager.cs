using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public Text textCoin;
    public Sprite[] HeartSprites;
    public Image HeartUI;
    
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        textCoin.text = "Coins = " + GameManager.instance.coins.ToString();
        HeartUI.sprite = HeartSprites[Player.curHealth];
    }
}
