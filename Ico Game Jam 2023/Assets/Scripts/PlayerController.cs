using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] private float moveSpeed;
	
	[Header("Attack")]
	[SerializeField] private Transform bulletSpawnPoint;
	[SerializeField] private GameObject bullet;
	
	
	private void Update()
	{
		Movement();
		LookAtMouseCursor();
	}
	
	private void Movement()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
		}
	}
	
	private void LookAtMouseCursor()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);
	}
	
	public void Attack()
	{
		Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
	}
}