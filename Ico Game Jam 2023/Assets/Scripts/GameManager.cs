using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int playerBulletCountdownTime;
	
	private PlayerController player;
	private CooldownText cooldownText;
	
	
	private void Awake()
	{
		player = FindObjectOfType<PlayerController>();
		cooldownText = FindObjectOfType<CooldownText>();
	}
	
	private void Start()
	{
		playerBulletCountdownTime = 3;
		cooldownText.text.text = playerBulletCountdownTime.ToString();
		StartCoroutine(Countdown3());
	}
	
	private IEnumerator Countdown3()
	{
		cooldownText.text.text = playerBulletCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
		
		StartCoroutine(Countdown2());
	}
	
	private IEnumerator Countdown2()
	{
		cooldownText.text.text = playerBulletCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
		
		StartCoroutine(Countdown1());
	}
	
	private IEnumerator Countdown1()
	{
		cooldownText.text.text = playerBulletCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
		
		StartCoroutine(Countdown0());
	}
	
	private IEnumerator Countdown0()
	{
		cooldownText.text.text = playerBulletCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
	}
	
	private void DecreaseCountdownTime()
	{
		if (playerBulletCountdownTime > 0)
		{
			playerBulletCountdownTime -= 1;
			cooldownText.PlayCooldownAnimation();
		}
		else
		{
			player.Attack();
			playerBulletCountdownTime = 3;
			StartCoroutine(Countdown3());
		}
	}
}