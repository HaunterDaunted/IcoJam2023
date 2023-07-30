using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Horizontal Movement")]
	[SerializeField] private float moveSpeed;
	
	[Header("Jumping")]
	[SerializeField] private float jumpForce;
	[SerializeField] private float distanceToCheck;
	[SerializeField] private float mainGravity;
	[SerializeField] private float fallingGravity;
	[SerializeField] private GameObject jumpParticles;
	[SerializeField] private Transform jumpParticlesSpawnPoint;
	public bool isGrounded;
	public bool canJump;
	
	private Vector2 moveVector;
	
	private Rigidbody2D thisRigidbody2D;
	
	private GameManager gameManager;
	private PlayerMovement player;
	
	
	private void Awake()
	{
		thisRigidbody2D = GetComponent<Rigidbody2D>();
		
		gameManager = FindObjectOfType<GameManager>();
		player = FindObjectOfType<PlayerMovement>();
	}
	
	private void Update()
	{
		HorizontalMovement();
		GroundCheck();
		PlayerGravity();
	}
	
	private void HorizontalMovement()
	{
		float xInput = Input.GetAxisRaw("Horizontal");
		moveVector = new Vector2(xInput, 0f);
		transform.Translate(moveVector * moveSpeed * Time.deltaTime);
	}
	
	private void GroundCheck()
	{
		if (Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck))
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
	}
	
	private void PlayerGravity()
	{
		if (thisRigidbody2D.velocity.y >= 0f)
		{
			thisRigidbody2D.gravityScale = mainGravity;
		}
		else
		{
			thisRigidbody2D.gravityScale = fallingGravity;
		}
	}
	
	public void Jump()
	{
		if (canJump)
		{
			thisRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			Instantiate(jumpParticles, jumpParticlesSpawnPoint.position, jumpParticlesSpawnPoint.rotation);
			canJump = false;
		}
	}
}