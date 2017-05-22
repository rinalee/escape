using UnityEngine;
using System.Collections;

public class Reusume : MonoBehaviour {

	public GameObject Menu;

	private void ResumeGame() {
		Menu.SetActive (false);
		Time.timeScale = 1.0f;
	}

}