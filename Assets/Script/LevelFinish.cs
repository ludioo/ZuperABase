using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour {

    public Text txtCoin;
    public Text txtHealth;
    public Text txtTotal;
    public Text txtAsam = null;
    public Text txtBasa = null;

	// Update is called once per frame
	void Update () {
        txtCoin.text = "Koin            " + GameManager.instance.coins.ToString();
        txtHealth.text = "Hati             " + Player.curHealth.ToString();
        //txtTotal.text = "Total Points = " + (GameManager.instance.coins + Player.curHealth).ToString();

        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
        {
            txtAsam.text = "Asam         " + GameManager.instance.asam.ToString();
            txtBasa.text = "Basa          " + GameManager.instance.basa.ToString();
        }
	}
}
