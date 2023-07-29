using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Horizontal Movement")]
	[SerializeField] private float moveSpeed;
	
	[Header("Jumping")]
	[SerializeField] private float jumpForce;
	public bool isGrounded;
	public bool canJump;
	
	private Vector2 moveVector;
	
	private Rigidbody2D thisRigidbody2D;
	
	private GameManager gameManager;
	
	
	private void Awake()
	{
		thisRigidbody2D = GetComponent<Rigidbody2D>();
		
		gameManager = FindObjectOfType<GameManager>();
	}
	
	private void Update()
	{
		HorizontalMovement();
	}
	
	private void HorizontalMovement()
	{
		float xInput = Input.GetAxisRaw("Horizontal");
		moveVector = new Vector2(xInput, 0f);
		transform.Translate(moveVector * moveSpeed * Time.deltaTime);
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
	}
	
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground")
		{
			isGrounded = false;
		}
	}
	
	public void Jump()
	{
		if (canJump)
		{
			thisRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			canJump = false;
		}
	}
}