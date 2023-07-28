using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public Vector3 targetDirection;
	
	[SerializeField] private float speed;
	[SerializeField] private float lifetime;
	[SerializeField] private float damageToEnemy;
	
	private Rigidbody2D thisRigidbody2D;
	
	
	private void Awake()
	{
		thisRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	private void Start()
	{
		//move bullet
		thisRigidbody2D.AddForce(targetDirection.normalized * speed);
		
		StartCoroutine(WaitToDestroySelf());
	}
	
	private IEnumerator WaitToDestroySelf()
	{
		yield return new WaitForSeconds(lifetime);
		Destroy(this.gameObject);
	}
	
	
}