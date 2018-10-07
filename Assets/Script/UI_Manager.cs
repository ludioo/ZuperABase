using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour {

    public Text textCoin;
    public Text textSoal;
    public Text textAsam;
    public Text textBasa;
    public Sprite[] HeartSprites;
    public Image HeartUI;

    public GameObject buku;

    // Use this for initialization
    void Start () {
        GameManager.instance.soal = 0;
	}
	
	// Update is called once per frame
	void Update () {
        textSoal.text = "S   = " + GameManager.instance.soal.ToString() + "/5";
        textCoin.text = "    = " + GameManager.instance.coins.ToString() + "/" + GameManager.instance.coinsCounter.ToString();
        
        HeartUI.sprite = HeartSprites[Player.curHealth];

        if (GameManager.instance.soal >= 5)
            buku.SetActive(true);

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                GameManager.instance.coinsCounter = 50;
                break;
            case 2:
                GameManager.instance.coinsCounter = 100;
                textAsam.text = "Asam = " + GameManager.instance.asam.ToString() + "/5";
                textBasa.text = "Basa = " + GameManager.instance.basa.ToString() + "/5";
                break;
            case 3:
                GameManager.instance.coinsCounter = 150;
                break;
        }
    }
}
