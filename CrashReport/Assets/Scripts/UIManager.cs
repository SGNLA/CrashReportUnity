using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public GameObject mainScrollView;

	public GameObject crashTitle;
	public GameObject crashDescription;
	public GameObject crashButton;
	public GameObject crashBackButton;

	public GameObject debugScrollView;
	public Text debugText;

	//-------- Main ui

	public void setMainUIComponentActive(bool active) {
		mainScrollView.SetActive (active);
	}

	//-------- Crash detail ui

	public void showCrashDetail(Crash crash) {
		crashTitle.SetActive (true);
		crashDescription.SetActive (true);
		crashButton.SetActive (true);
		crashBackButton.SetActive (true);

		crashTitle.GetComponent<Text> ().text = crash.title;
		crashDescription.GetComponent<Text> ().text = crash.description;
		crashButton.GetComponent<Button> ().onClick.AddListener (crash.crash);
	}

	public void backFromCrashDetail() {
		crashButton.GetComponent<Button> ().onClick.RemoveAllListeners ();

		crashTitle.SetActive (false);
		crashDescription.SetActive (false);
		crashButton.SetActive (false);
		crashBackButton.SetActive (false);
	}

	//-------- Debug functionality

	public void switchDebugPanel() {
		debugScrollView.SetActive(!debugScrollView.activeSelf);
	}

	public void debugTextTest() {
		debugText.text += "This is a debug text test message.\n";
	}

	public void clearDebugText() {
		debugText.text = "";
	}

	public void addDebugText(string msg) {
		debugText.text += msg + "\n";
	}
}
