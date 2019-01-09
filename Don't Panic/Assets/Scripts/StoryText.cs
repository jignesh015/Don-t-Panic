﻿using System.Collections;
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
			"Check out Captain's pod",
			"Search for password to Captain's door",
			"Unlock captain's door"
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
			"42! This number looks significant"
		}
	);

	private static List<string> _professorPodLines = new List<string>(new string[] 
		{
			"Huh, empty!",
			"Where is Prof?",
			"Maybe I should check her log files!",
			"Let me check Captain's pod"
		}
	);

	private static List<string> _captainPodLines = new List<string>(new string[] 
		{
			"Let me check captain's log files",
		}
	);

	private static List<string> _lieutenantPodLines = new List<string>(new string[] 
		{
			"Lieutenant is not here too!",
			"Oh, a gun. This might come in handy"
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
}
