using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private AudioClip buttonClickedSFX;
	
	private AudioSource thisAudioSource;
	
	
	private void Awake()
	{
		thisAudioSource = GetComponent<AudioSource>();
	}
	
	public void PlayGame()
	{
		thisAudioSource.PlayOneShot(buttonClickedSFX);
		SceneManager.LoadScene("Level1");
	}
}