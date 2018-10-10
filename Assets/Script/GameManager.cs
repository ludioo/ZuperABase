using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private Vector3 spawnPoint;
    public int soal;
    public int coins;
    public int coinsCounter;
    public int soalCounter;
    public int asam;
    public int basa;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Debug.Log("Basa = " + basa);
        Debug.Log("Asam = " + asam);
    }

    public Vector3 GetSpawnPoint()
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform.position;

        return spawnPoint;
    }
}
