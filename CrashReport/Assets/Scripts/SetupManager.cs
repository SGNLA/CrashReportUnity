using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour {
	public UIManager uiManager;

	static public Dictionary<string, Dictionary<string, List<Crash> > > allCrashData;

	public GameObject scrollContent;
	public GameObject textPrefab;
	public GameObject buttonPrefab;

	// Use this for initialization
	void Start () {
		// generate data storage structure
		allCrashData = new Dictionary<string, Dictionary<string, List<Crash> > >();
		allCrashData.Add ("Unity", new Dictionary<string, List<Crash> >());
		allCrashData.Add ("Java", new Dictionary<string, List<Crash> >());
		allCrashData.Add ("ObjectiveC", new Dictionary<string, List<Crash> >());

		// collect Unity crashes
		UnityCrashFactory.generateAllCrashCasesInto(allCrashData["Unity"]);

		// collect JAR crashes
		#if UNITY_ANDROID
		string[] JARCrashPath;
		using(AndroidJavaClass crashClass = new AndroidJavaClass("com.jamcity.libcrash.Crash")) {
			JARCrashPath = crashClass.GetStatic<string[]> ("ALL_CRASH_PATH_ARRAY");
		}

		foreach (string crashPath in JARCrashPath) {
			AndroidJavaObject crashObject = new AndroidJavaObject(crashPath);
			JavaCrash javaCrashObject = new JavaCrash(crashObject);
			if(!allCrashData["Java"].ContainsKey(javaCrashObject.category)) {
				allCrashData["Java"][javaCrashObject.category] = new List<Crash>();
			}

			allCrashData["Java"][javaCrashObject.category].Add(javaCrashObject);
		}
		#endif 

		// collect Objectivce C crashes
		#if UNITY_IOS
		ObjectiveCCrashFactory.generateAllCrashCasesInto(allCrashData["ObjectiveC"]);
		#endif

		// setup dropdown
		fulfillCrashTypeScrollView ();
	}

	private void fulfillCrashTypeScrollView() {
		if (scrollContent) {
			uiManager.addDebugText("Adding Unity crash...");
			GameObject unityTypeText = Instantiate(textPrefab) as GameObject;
			unityTypeText.GetComponent<Text>().fontStyle = FontStyle.Bold;
			unityTypeText.GetComponent<Text> ().text = "Unity";
			unityTypeText.transform.SetParent(scrollContent.transform);

			foreach(string category in allCrashData["Unity"].Keys) {
				uiManager.addDebugText("==Category: " + category);
				GameObject categoryText = Instantiate(textPrefab) as GameObject;
				categoryText.GetComponent<Text> ().text = category;
				categoryText.transform.SetParent(scrollContent.transform);

				foreach(Crash crash in allCrashData["Unity"][category]) {
					uiManager.addDebugText("-Case: " + crash.title);
					GameObject crashSelectionButton = Instantiate(buttonPrefab) as GameObject;
					crashSelectionButton.transform.GetComponentInChildren<Text>().text = crash.title;
					crashSelectionButton.transform.SetParent(scrollContent.transform);

					crashSelectionButton.GetComponent<Button>().onClick.AddListener(() => onCrashCaseClicked(crash));
				}
			}

			#if UNITY_ANDROID
			uiManager.addDebugText("Adding Java crash...");
			GameObject codeTypeText = Instantiate(textPrefab) as GameObject;
			codeTypeText.GetComponent<Text>().fontStyle = FontStyle.Bold;
			codeTypeText.GetComponent<Text> ().text = "Java";
			codeTypeText.transform.SetParent(scrollContent.transform);

			foreach(string category in allCrashData["Java"].Keys) {
				uiManager.addDebugText("==Category: " + category);
				GameObject categoryText = Instantiate(textPrefab) as GameObject;
				categoryText.GetComponent<Text> ().text = category;
				categoryText.transform.SetParent(scrollContent.transform);

				foreach(Crash crash in allCrashData["Java"][category]) {
					uiManager.addDebugText("-Case: " + crash.title);
					GameObject crashSelectionButton = Instantiate(buttonPrefab) as GameObject;
					crashSelectionButton.transform.GetComponentInChildren<Text>().text = crash.title;
					crashSelectionButton.transform.SetParent(scrollContent.transform);

					crashSelectionButton.GetComponent<Button>().onClick.AddListener(() => onCrashCaseClicked(crash));
				}
			}
			#endif

			#if UNITY_IOS
			uiManager.addDebugText("Adding Objective C crash...");
			GameObject codeTypeText = Instantiate(textPrefab) as GameObject;
			codeTypeText.GetComponent<Text>().fontStyle = FontStyle.Bold;
			codeTypeText.GetComponent<Text> ().text = "Objective C";
			codeTypeText.transform.SetParent(scrollContent.transform);

			foreach(string category in allCrashData["ObjectiveC"].Keys) {
				uiManager.addDebugText("==Category: " + category);
				GameObject categoryText = Instantiate(textPrefab) as GameObject;
				categoryText.GetComponent<Text> ().text = category;
				categoryText.transform.SetParent(scrollContent.transform);

				foreach(Crash crash in allCrashData["ObjectiveC"][category]) {
					uiManager.addDebugText("-Case: " + crash.title);
					GameObject crashSelectionButton = Instantiate(buttonPrefab) as GameObject;
					crashSelectionButton.transform.GetComponentInChildren<Text>().text = crash.title;
					crashSelectionButton.transform.SetParent(scrollContent.transform);

					crashSelectionButton.GetComponent<Button>().onClick.AddListener(() => onCrashCaseClicked(crash));
				}
			}
			#endif
		}
	}

	private void onCrashCaseClicked(Crash crash) {
		uiManager.setMainUIComponentActive (false);
		uiManager.showCrashDetail (crash);
	}
}
