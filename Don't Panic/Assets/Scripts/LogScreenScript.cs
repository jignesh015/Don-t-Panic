using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogScreenScript : MonoBehaviour {

	public GameObject accessPanel;
	public GameObject logPanel;
	public Button prevBtn;
	public Button nextBtn;
	public Text logFileText;
	public int logIndicator;

	public Canvas sliderCanvas;
	public Slider slider;

	private int logFileIndex;
	private List<string> logText;
	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private string activeBtn;
	private bool checkedLog = false;

	// Use this for initialization
	void Start () {
		logFileIndex = 0;

		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);

		//Selecting the respective log file
		switch (logIndicator) {
		case 1:
			logText = LogText.ProfessorLog;
			break;
		case 2:
			logText = LogText.CaptainLog;
			break;
		case 3:
			logText = LogText.LieutenantLog;
			break;
		default:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (pointerFlag) {
			//Sets the progress slider value
			float sliderValue = Time.time - enterTime;
			slider.value = sliderValue;

			if ((Time.time - enterTime) > hoverTime) {
				switch (activeBtn) {
				case "access":
					AccessLogs ();
					break;
				case "prev":
					PrevLog ();
					break;
				case "next":
					NextLog ();
					break;
				default:
					break;
				}
				sliderCanvas.gameObject.SetActive (false);
				pointerFlag = false;
			}
		}

		//Toggle prev btn
		if (logFileIndex == 0) {
			prevBtn.gameObject.SetActive (false);
		} else {
			prevBtn.gameObject.SetActive (true);
		}

		//Toggle next btn
		if (logFileIndex == logText.Count - 1) {
			nextBtn.gameObject.SetActive (false);

			//Mark logs as read
			if (!checkedLog) {
				checkedLog = true;
				switch (logIndicator) {
				case 1:
					StaticValues.CheckedProfLogs = true;
					break;
				case 2:
					StaticValues.CheckedCaptainLog = true;
					break;
				case 3:
					StaticValues.CheckedLieutenantLog = true;
					break;
				default:
					break;
				}
			}
		} else {
			nextBtn.gameObject.SetActive (true);
		}
	}

	public void AccessLogs() {
		accessPanel.SetActive (false);
		logPanel.SetActive (true);

		logFileText.text = logText[0];
		PointerExit ();
	}

	public void EnterAccessBtn() {
		activeBtn = "access";
		PointerEnter ();
	}

	public void ExitAccessBtn() {
		PointerExit();
	}

	public void PrevLog() {
		logFileIndex -= 1;
		logFileText.text = logText [logFileIndex];
		PointerExit ();
	}

	public void EnterPrevBtn() {
		activeBtn = "prev";
		PointerEnter ();
	}

	public void ExitPrevBtn() {
		PointerExit();
	}

	public void NextLog() {
		logFileIndex += 1;
		logFileText.text = logText [logFileIndex];
		PointerExit ();
	}

	public void EnterNextBtn() {
		activeBtn = "next";
		PointerEnter ();
	}

	public void ExitNextBtn() {
		PointerExit();
	}

	private void PointerEnter() {
		sliderCanvas.gameObject.SetActive (true);
		pointerFlag = true;
		enterTime = Time.time;
	}

	private void PointerExit() {
		pointerFlag = false;
		sliderCanvas.gameObject.SetActive (false);
		//Reset progress slider value
		slider.value = 0.0f;
	}
}
