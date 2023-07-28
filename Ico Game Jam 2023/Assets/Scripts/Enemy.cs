using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	
	private GameObject target;
	
	
	private void Update()
	{
		target = GameObject.FindGameObjectWithTag("Player");
		if (target != null)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}