using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public Text textCoin;
    public Text textSoal;
    public Sprite[] HeartSprites;
    public Image HeartUI;

    public GameObject buku;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        textSoal.text = "Soa= " + GameManager.instance.soal.ToString() + "/5";
        textCoin.text = "     = " + GameManager.instance.coins.ToString() + "/50";
        HeartUI.sprite = HeartSprites[Player.curHealth];

        if (GameManager.instance.soal >= 5)
            buku.SetActive(true);
    }
}
