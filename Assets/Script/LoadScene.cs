﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class LoadScene : MonoBehaviour {
	
	public void SceneLoader(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}

    public void SceneLoader(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void onClick()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}