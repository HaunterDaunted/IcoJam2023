using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTextTrigger : MonoBehaviour
{
	[SerializeField] private TMP_Text dialogueTextToShow;
	
	
	private AudioSource thisAudioSource;
	
	
	private void Awake()
	{
		thisAudioSource = GetComponent<AudioSource>();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (thisAudioSource.enabled == true) thisAudioSource.Play();
			dialogueTextToShow.GetComponent<Animator>().SetBool("fadingIn", true);
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			thisAudioSource.enabled = false;
			dialogueTextToShow.GetComponent<Animator>().SetBool("fadingIn", false);
		}
	}
}