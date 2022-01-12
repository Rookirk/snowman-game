using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEndingMusic : MonoBehaviour
{
	private void Start()
	{
		AudioManager.Instance?.PlayEndingMusic();
	}
}