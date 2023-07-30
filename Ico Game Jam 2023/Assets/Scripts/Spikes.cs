using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spikes : MonoBehaviour
{
	[SerializeField] private GameObject checkpoint;
	[SerializeField] private GameObject playerGO;
	[SerializeField] private GameObject playerDeathParticles;
	[SerializeField] private AudioClip playerDeathSFX;
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
			playerGO.GetComponent<AudioSource>().PlayOneShot(playerDeathSFX);
			Instantiate(playerDeathParticles, playerGO.transform.position, playerGO.transform.rotation);
			playerGO.SetActive(false);
			
			StartCoroutine(GoToCheckpoint());
		}
	}
	
	private IEnumerator GoToCheckpoint()
	{
		fader.GetComponent<Animator>().SetBool("fadingIn", false);
		yield return new WaitForSeconds(1f);
		playerGO.SetActive(true);
		playerGO.transform.position = checkpoint.transform.position;
		fader.GetComponent<Animator>().SetBool("fadingIn", true);
	}
}
