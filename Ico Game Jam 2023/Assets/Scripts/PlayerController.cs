using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	
	private Vector2 moveVector;
	
	private Rigidbody2D thisRigidbody2D;
	
	
	private void Awake()
	{
		thisRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	private void Update()
	{
		Movement();
		LookAtMouseCursor();
	}
	
	private void Movement()
	{
		float xInput = Input.GetAxisRaw("Horizontal");
		float yInput = Input.GetAxisRaw("Vertical");
		moveVector = new Vector2(xInput, yInput);
		transform.Translate(moveVector.normalized * moveSpeed * Time.deltaTime);
	}
	
	private void LookAtMouseCursor()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);
	}
}