using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float lifetime;

	
	private void Start()
	{
		StartCoroutine(WaitToDestroySelf());
	}
	
	private IEnumerator WaitToDestroySelf()
	{
		yield return new WaitForSeconds(lifetime);
		Destroy(this.gameObject);
	}
	
	private void Update()
	{
		transform.position += new Vector3(transform.position.x, transform.position.y, transform.position.z) * speed * Time.deltaTime;
	}
}