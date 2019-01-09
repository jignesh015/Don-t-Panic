using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogText {
	private static List<string> _professorLog = new List<string>(new string[] 
		{
			"15/06/2139 EY \n Woke up from hypersleep today...",
			"18/06/2139 EY \n Been away from Earth for almost 70 years now. Feels weird. \n Everyone we knew is dead.",
			"24/06/2139 EY \n Contact with Earth base lost. Seems like we are on our own for a while.",
			""
		}
	);

	private static List<string> _captainLog = new List<string>(new string[] 
		{
			"24/06/2139 EY \n We lost the contact with Earth today. Need to check what the issue is.",
			"14/07/2139 EY \n It's been more than two Earth weeks since we last contacted the Earth base. And now contact with mothership is lost too."
		}
	);

	private static List<string> _lieutenantLog = new List<string>(new string[] 
		{
			"20/07/2139 EY \n Captain woke me up today from hypersleep, way before the schedule. Told me he has something important to discuss tomorrow",
			"24/07/2139 EY \n We are facing a grave danger. I wonder if we should wake up Ruhaan."
		}
	);


	public static List<string> ProfessorLog {
		get { 
			return _professorLog;
		}
	}

	public static List<string> CaptainLog {
		get { 
			return _captainLog;
		}
	}

	public static List<string> LieutenantLog {
		get { 
			return _lieutenantLog;
		}
	}
}
