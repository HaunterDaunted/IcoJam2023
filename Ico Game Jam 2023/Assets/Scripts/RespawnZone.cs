using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
	[SerializeField] private GameObject currentCheckpoint;
	[SerializeField] private GameObject playerGO;
	[SerializeField] private Image fader;
	
	private PlayerMovement playerScript;
	
	
	private void Awake()
	{
		playerScript = FindObjectOfType<PlayerMovement>();
	}
	
	private void Start()
	{
		fader.GetComponent<Animator>().SetBool("fadingIn", true);
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerGO = other.gameObject;
			playerGO.SetActive(false);
			
			StartCoroutine(GoToLastCheckpoint());
		}
	}
	
	private IEnumerator GoToLastCheckpoint()
	{
		fader.GetComponent<Animator>().SetBool("fadingIn", false);
		yield return new WaitForSeconds(1f);
		playerGO.SetActive(true);
		playerGO.transform.position = currentCheckpoint.transform.position;
		fader.GetComponent<Animator>().SetBool("fadingIn", true);
	}
}