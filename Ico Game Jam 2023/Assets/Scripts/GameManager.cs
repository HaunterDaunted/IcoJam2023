using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int playerJumpCountdownTime;
	
	private CountdownText countdownText;
	
	
	private void Awake()
	{
		countdownText = FindObjectOfType<CountdownText>();
	}
	
	private void Start()
	{
		playerJumpCountdownTime = 3;
		countdownText.text.text = playerJumpCountdownTime.ToString();
		StartCoroutine(Countdown3());
	}
	
	private IEnumerator Countdown3()
	{
		countdownText.text.text = playerJumpCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
		
		StartCoroutine(Countdown2());
	}
	
	private IEnumerator Countdown2()
	{
		countdownText.text.text = playerJumpCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
		
		StartCoroutine(Countdown1());
	}
	
	private IEnumerator Countdown1()
	{
		countdownText.text.text = playerJumpCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
		
		StartCoroutine(Countdown0());
	}
	
	private IEnumerator Countdown0()
	{
		countdownText.text.text = playerJumpCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
	}
	
	private void DecreaseCountdownTime()
	{
		playerJumpCountdownTime -= 1;
		countdownText.PlayCooldownAnimation();
	}
}