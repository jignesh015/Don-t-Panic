using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StaticValues {
	private static bool _isFirstLoad = true;
	private static bool _dontPanicFlag = true;
	private static int _spawnToWaypoint;
	private static int _collectibleScore = 0;
	private static string _currentObjective = "Do something";
	private static string _currentHUDMessage;
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