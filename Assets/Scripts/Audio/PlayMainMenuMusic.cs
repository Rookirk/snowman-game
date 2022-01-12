using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMainMenuMusic : MonoBehaviour
{
	private void Start()
	{
		AudioManager.Instance?.PlayMainMenuMusic();
	}
}