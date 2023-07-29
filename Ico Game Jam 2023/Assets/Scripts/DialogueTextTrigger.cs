using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTextTrigger : MonoBehaviour
{
	[SerializeField] private TMP_Text dialogueTextToShow;
	
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			dialogueTextToShow.GetComponent<Animator>().SetBool("fadingIn", true);
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			dialogueTextToShow.GetComponent<Animator>().SetBool("fadingIn", false);
		}
	}
}