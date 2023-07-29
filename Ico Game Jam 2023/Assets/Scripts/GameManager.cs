using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int playerJumpCountdownTime;
	
	private CountdownText countdownText;
	
	private PlayerMovement player;
	
	
	private void Awake()
	{
		countdownText = FindObjectOfType<CountdownText>();
		
		player = FindObjectOfType<PlayerMovement>();
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
		if (playerJumpCountdownTime > 0)
		{
			if (player.isGrounded)
			{
				player.canJump = false;
				playerJumpCountdownTime -= 1;
				countdownText.PlayCooldownAnimation();
			}
			
		}
			else
			{
				player.canJump = true;
				player.Jump();
				
				//reset playerJumpCountdownTime
				playerJumpCountdownTime = 3;
				StartCoroutine(Countdown3());
			}
	}
	
	private void Update()
	{
		Debug.Log(playerJumpCountdownTime);
	}
}