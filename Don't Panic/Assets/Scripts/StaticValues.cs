public static class StaticValues {
	private static int spawnToWaypoint;
	private static int collectibleScore = 0;

	public static int SpawnToWaypoint {
		get { 
			return spawnToWaypoint;
		}
		set { 
			spawnToWaypoint = value;
		}
	}

	public static int CollectibleScore {
		get { 
			return collectibleScore;
		}
		set { 
			collectibleScore = collectibleScore + value;
		}
	}
}