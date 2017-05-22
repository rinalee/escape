using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	private bool showGUI = false;
	private bool isPaused = false;
	public GameObject Menu;


	void Start () {
		Menu.SetActive (false);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			showGUI = !showGUI;
			isPaused = !isPaused;
		}

        if (isPaused)
            Debug.Log("Menu Opened");
        //Time.timeScale = 1.0f;

        else
            //Time.timeScale = 1.0f;
            Menu.SetActive(false);

		if (showGUI == true) {
			Menu.SetActive (true);
		}
	
	}


	void OnGUI () {
		if (isPaused) {
			showGUI = !showGUI;
			/*if (GUI.Button(new Rect(Screen.width / 2-40, Screen.height / 2 - 20, 80,40), "Continuer")){
				isPaused = false;
			}
			if (GUI.Button(new Rect(Screen.width / 2-40, Screen.height / 2 + 20, 80,40), "Quitter")){
				//Application.Quit();
				SceneManager.LoadScene("Main_Menu");*/

		}
	}
}
