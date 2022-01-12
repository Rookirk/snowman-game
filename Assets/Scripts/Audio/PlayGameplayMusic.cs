using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameplayMusic : MonoBehaviour
{
	private void Start()
	{
		AudioManager.Instance?.PlayGameplayMusic();
	}
}