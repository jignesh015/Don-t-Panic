using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogText {
	private static List<string> _professorLog = new List<string>(new string[] 
		{
			"15/06/2139 EY \n Woke up from hypersleep today...",
			"18/06/2139 EY \n Been away from Earth for almost 70 years now. Feels weird. \n Everyone we knew is dead.",
			"24/06/2139 EY \n Contact with Earth base lost. Seems like we are on our own for a while.",
			"20/07/2139 EY \n Got an SOS from Earth base today. I think Captain and I must go back to the Earth",
		}
	);

	private static List<string> _captainLog = new List<string>(new string[] 
		{
			"24/06/2139 EY \n We lost the contact with Earth today. Need to check what the issue is.",
			"14/07/2139 EY \n It's been more than two Earth weeks since we last contacted the Earth base. And now contact with mothership is lost too.",
			"20/07/2139 EY \n Got this strange message from Earth base today. Seems urgent",
			"20/07/2139 EY \n Woke up Lieutenant from hypersleep today. Need to brief him about the strange SOS.",
			"21/07/2139 EY \n Not able to wake up Ruhaan. Told lieutenant to brief him later..",
			"22/07/2139 EY \n Prof and I have decided to make return journey to Earth. Lieutenant will take the charge of the ship"
		}
	);

	private static List<string> _lieutenantLog = new List<string>(new string[] 
		{
			"20/07/2139 EY \n Captain woke me up today from hypersleep, way before the schedule. Told me he has something important to discuss tomorrow",
			"21/07/2139 EY \n We are facing a grave danger. I wonder if we should wake up Ruhaan.",
			"26/07/2139 EY \n A strange ship is approaching us. Captain and Prof has already left. Should I destroy the intruders?",
			"27/07/2139 EY \n This is unbelievable. An extraterrestrial life form has approached us...",
			"27/07/2139 EY \n They are asking me to visit their planet. Somehow, I don't trust them much",
			"28/07/2139 EY \n I have decided to go with them. As a collateral, their one crew member will remain on this ship",
			"29/07/2139 EY \n Ruhaan, if you are reading this, sorry I couldn't get you out of hypersleep. I'll be back soon anyway..",
			"29/07/2139 EY \n If for some reason I am not back by the time you wake up, be wary of the creature in the storage pod",
			"29/07/2139 EY \n And for your safety, I'm leaving you a gun. Keep it with you all the time"
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
