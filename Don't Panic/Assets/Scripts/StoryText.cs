using System.Collections;
using System.Collections.Generic;

public static class StoryText {
	private static List<string> _objectives = new List<string>(new string[] 
		{
			"...",
			"Go out and find others",
			"Stop the warning message alert",
			"Find your crew mates",
			"Check Professor's log files",
			"5",
			"Check out Captain's log files",
			"Search for password to Captain's door",
			"Unlock captain's door",
			"Check out Lieutenant's Pod",
			"10",
			"Checkout Lieutenant's log files",
			"Collect Lieutenant's gun"
		}
	);

	private static List<string> _playerPodLines = new List<string>(new string[] 
		{
			"Where am I? How long have I been sleeping",
			"What year is it?",
			"Hmm, let me go out and find others"
		}
	);

	private static List<string> _controRoomLines = new List<string>(new string[] 
		{
			"What is this noise?",
			"Don't Panic? Why would I panic?",
			"I need to stop this noise first!",
			"Much better",
			"So....where are my crew mates?",
			"5",
			"I should check their pods...",
			"Uh, it's locked",
			"I need to search for the password",
			"Oh, I know this book",
			"10",
			"It is Captain's favourite novel",
			"Captain's favourite novel. \n The password must be somewhere here",
			"Let me open it and check.",
			"Huh, there is some text highlighted here",
			"15",
			"THE ANSWER TO THE ULTIMATE QUESTION OF \n LIFE, UNIVERSE AND EVERYTHING IS \n 42",
			"42! This number looks significant",
			"I should first check Captain's logs before meeting Lieutenant.",
			"I should check the room opposite to this one first.",
			"20",
			"I should first check Lieutenant's logs before going inside"
		}
	);

	private static List<string> _professorPodLines = new List<string>(new string[] 
		{
			"Huh, empty!",
			"Where is Prof?",
			"Maybe I should check her log files!",
			"That was weird.",
			"Let me check Captain's pod"
		}
	);

	private static List<string> _captainPodLines = new List<string>(new string[] 
		{
			"Let me check captain's log files",
			"This is so strange!",
			"Lieutenant may have some explanation for this.."
		}
	);

	private static List<string> _lieutenantPodLines = new List<string>(new string[] 
		{
			"Lieutenant is not here too!",
			"Let's check his logs.",
			"Lieutenant is gone too?",
			"And what was it about the gun?",
			"I hope I don't get to use this!"
		}
	);

	private static List<string> _alienPodLines = new List<string>(new string[] 
		{
			"What the...",
			"So you are the one that came from that mysterious spacecraft",
			"Then why are you locked in here?",
			"That must be Lieutenant.",
			"How do I believe you?"
		}
	);

	private static List<string> _alienLines = new List<string>(new string[] 
		{
			"Don't be shocked to see me, human!",
			"Yes. And I mean no harm, as I tried explaining to your partners",
			"I'm here as a collateral. One of your crewmate had gone with my crew to visit our planet.",
			"Yes, but they are gone far too long. I am worried for them.",
			"Let me go, and I'll search for them",
			"You have my word.",
			"Thanks, you won't regret it.",
			"You will regret this."
		}
	);

	private static List<string> _spaceShuttlePodLines = new List<string>(new string[] 
		{
			"What the...",
			"So you are the one that came from that mysterious spacecraft",
			"Then why are you locked in here?",
			"That must be Lieutenant.",
			"How do I believe you?"
		}
	);

	public static List<string> Objectives {
		get { 
			return _objectives;
		}
	}

	public static List<string> PlayerPodLines {
		get { 
			return _playerPodLines;
		}
	}

	public static List<string> ControlRoomLines {
		get { 
			return _controRoomLines;
		}
	}

	public static List<string> ProfessorPodLines {
		get { 
			return _professorPodLines;
		}
	}

	public static List<string> CaptainPodLines {
		get { 
			return _captainPodLines;
		}
	}

	public static List<string> LieutenantPodLines {
		get { 
			return _lieutenantPodLines;
		}
	}

	public static List<string> AlienPodLines {
		get { 
			return _alienPodLines;
		}
	}

	public static List<string> AlienLines {
		get { 
			return _alienLines;
		}
	}

	public static List<string> SpaceShuttlePodLines {
		get { 
			return _spaceShuttlePodLines;
		}
	}
}
