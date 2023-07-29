using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelExit : MonoBehaviour
{
	[SerializeField] private string nextLevel;
	[SerializeField] private Image fader;
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
			
			StartCoroutine(FadeIntoNextLevel());
		}
	}
	
	private IEnumerator FadeIntoNextLevel()
	{
		fader.GetComponent<Animator>().SetBool("fadingIn", true);
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(nextLevel);
	}
}