using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour {

    public Text txtCoin;
    public Text txtHealth;
    public Text txtTotal;

	// Update is called once per frame
	void Update () {
        txtCoin.text = "Coins = " + GameManager.instance.coins.ToString();
        txtHealth.text = "Health Remaining = " + Player.curHealth.ToString();
        txtTotal.text = "Total Points = " + (GameManager.instance.coins + Player.curHealth).ToString();
	}
}
