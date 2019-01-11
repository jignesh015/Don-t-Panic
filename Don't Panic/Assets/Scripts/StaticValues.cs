using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StaticValues {
	private static bool _isFirstLoad = true;
	private static bool _dontPanicFlag = true;
	private static bool _checkedProfLogs = false;
	private static bool _checkedPassword = false;
	private static bool _checkedCaptainDoor = false;
	private static bool _checkedCaptainLog = false;
	private static bool _checkedLieutenantLog = false;
	private static bool _checkedAlienPod = false;
	private static bool _isGunCollected = false;
	private static bool _killedAlien = false;
	private static bool _choseToWait = false;
	private static int _spawnToWaypoint;
	private static int _collectibleScore = 0;
	private static string _currentObjective = "...";
	private static string _currentHUDMessage;
	private static string _currentSubScene = "PlayerPod";
	private static List<string> _collectibleList = new List<string>();
	private static List<string> _keywords = new List<string>(new string[] { "42", "forty two", "order to", "forget to", "for to", "for two", "for the" ,"photo", "ford to", "for you to", "for you two", "what do you", "what you do", "what do you do"});

	public static bool IsFirstLoad {
		get { 
			return _isFirstLoad;
		}
		set { 
			_isFirstLoad = value;
		}
	}

	public static bool DontPanicFlag {
		get { 
			return _dontPanicFlag;
		}
		set { 
			_dontPanicFlag = value;
		}
	}

	public static bool CheckedProfLogs {
		get { 
			return _checkedProfLogs;
		}
		set { 
			_checkedProfLogs = value;
		}
	}

	public static bool CheckedPassword {
		get { 
			return _checkedPassword;
		}
		set { 
			_checkedPassword = value;
		}
	}

	public static bool CheckedCaptainDoor {
		get { 
			return _checkedCaptainDoor;
		}
		set { 
			_checkedCaptainDoor = value;
		}
	}

	public static bool CheckedCaptainLog {
		get { 
			return _checkedCaptainLog;
		}
		set { 
			_checkedCaptainLog = value;
		}
	}

	public static bool CheckedLieutenantLog {
		get { 
			return _checkedLieutenantLog;
		}
		set { 
			_checkedLieutenantLog = value;
		}
	}

	public static bool CheckedAlienPod {
		get { 
			return _checkedAlienPod;
		}
		set { 
			_checkedAlienPod = value;
		}
	}

	public static bool IsGunCollected {
		get { 
			return _isGunCollected;
		}
		set { 
			_isGunCollected = value;
		}
	}

	public static bool KilledAlien {
		get { 
			return _killedAlien;
		}
		set { 
			_killedAlien = value;
		}
	}

	public static bool ChoseToWait {
		get { 
			return _choseToWait;
		}
		set { 
			_choseToWait = value;
		}
	}

	public static int SpawnToWaypoint {
		get { 
			return _spawnToWaypoint;
		}
		set { 
			_spawnToWaypoint = value;
		}
	}

	public static int CollectibleScore {
		get { 
			return _collectibleScore;
		}
		set { 
			_collectibleScore = _collectibleScore + value;
		}
	}

	public static string CurrentObjective {
		get { 
			return _currentObjective;
		}
		set { 
			_currentObjective = value;
		}
	}

	public static string CurrentHUDMessage {
		get { 
			return _currentHUDMessage;
		}
		set { 
			_currentHUDMessage = value;
		}
	}

	public static string CurrentSubScene {
		get { 
			return _currentSubScene;
		}
		set { 
			_currentSubScene = value;
		}
	}

	public static List<string> CollectibleList {
		get { 
			return _collectibleList;
		}
		set { 
			_collectibleList = value;
		}
	}

	public static List<string> Keywords {
		get { 
			return _keywords;
		}
	}
}