using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int playerBulletCooldown;
	
	private PlayerController player;
	
	
	private void Awake()
	{
		player = FindObjectOfType<PlayerController>();
	}
	
	private void Start()
	{
		playerBulletCooldown = 3;
		StartCoroutine(CooldownTimer());
	}
	
	private IEnumerator CooldownTimer()
	{
		yield return new WaitForSeconds(playerBulletCooldown);
		player.Attack();
		
		//do this coroutine again
		StartCoroutine(CooldownTimer());
	}
}