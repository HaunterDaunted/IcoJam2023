using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
	[SerializeField] private GameObject currentCheckpoint;
	[SerializeField] private GameObject playerGO;
	
	private PlayerMovement playerScript;
	
	
	private void Awake()
	{
		playerScript = FindObjectOfType<PlayerMovement>();
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
		yield return new WaitForSeconds(1f);
		playerGO.SetActive(true);
		playerGO.transform.position = currentCheckpoint.transform.position;
	}
}