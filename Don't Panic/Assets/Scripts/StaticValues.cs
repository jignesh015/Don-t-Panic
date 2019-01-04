using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StaticValues {
	private static int _spawnToWaypoint;
	private static int _collectibleScore = 0;
	private static List<string> _collectibleList = new List<string>();

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

	public static List<string> CollectibleList {
		get { 
			return _collectibleList;
		}
		set { 
			_collectibleList = value;
		}
	}
}