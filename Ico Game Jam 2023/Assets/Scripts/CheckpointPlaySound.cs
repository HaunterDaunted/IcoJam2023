using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointPlaySound : MonoBehaviour
{
	[SerializeField] private AudioClip checkPointSFX;
	
	private bool checkPointReached;
	
	private AudioSource thisAudioSource;
	
	
	private void Awake()
	{
		thisAudioSource = GetComponent<AudioSource>();
	}
	
	private void Start()
	{
		checkPointReached = false;
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && !checkPointReached)
		{
			thisAudioSource.PlayOneShot(checkPointSFX);
			checkPointReached = true;
		}
	}
}