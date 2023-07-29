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
		playerJumpCountdownTime = 3;
		countdownText.text.text = playerJumpCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
		
		StartCoroutine(Countdown2());
	}
	
	private IEnumerator Countdown2()
	{
		playerJumpCountdownTime = 2;
		countdownText.text.text = playerJumpCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
		
		StartCoroutine(Countdown1());
	}
	
	private IEnumerator Countdown1()
	{
		playerJumpCountdownTime = 1;
		countdownText.text.text = playerJumpCountdownTime.ToString();
		yield return new WaitForSeconds(1f);
		DecreaseCountdownTime();
		
		StartCoroutine(Countdown0());
	}
	
	private IEnumerator Countdown0()
	{
		playerJumpCountdownTime = 0;
		countdownText.text.text = "JUMP!";
		
		if (player.isGrounded)
		{
			player.canJump = true;
			player.Jump();
		}
		
		yield return new WaitForSeconds(1f);
		
		//reset playerJumpCountdownTime
		StartCoroutine(Countdown3());
	}
	
	private void DecreaseCountdownTime()
	{
		if (playerJumpCountdownTime > 0)
		{
			if (player.isGrounded)
			{
				player.canJump = false;
				countdownText.PlayCooldownAnimation();
			}
			
		}
	}
}