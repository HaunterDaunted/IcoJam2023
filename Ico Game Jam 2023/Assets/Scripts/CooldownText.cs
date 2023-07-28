using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CooldownText : MonoBehaviour
{
	public TMP_Text text;
	
	private Animator thisAnimator;
	
	
	private void Awake()
	{
		thisAnimator = GetComponent<Animator>();
	}
	
	public void PlayCooldownAnimation()
	{
		thisAnimator.SetBool("countingDown", true);
		Invoke("ResetCooldownAnimation", 0.6f);
	}
	
	private void ResetCooldownAnimation()
	{
		thisAnimator.SetBool("countingDown", false);
	}
}