using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Vector3 direction;
	private Rigidbody2D rgbody2d;
	private float stuckCounter;

	void Start()
	{
		Destroy(gameObject, 20);
		rgbody2d = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		// запоминаем скорость, если она не слишком маленькая (после удара скорость снижается)
		if (Mathf.Abs(rgbody2d.velocity.x) > 1 || Mathf.Abs(rgbody2d.velocity.y) > 1)
			direction = rgbody2d.velocity;

		//если пуля застряла в коллайдере и не движется, удаляем
		if (Mathf.Abs(rgbody2d.velocity.x) < 1 && Mathf.Abs(rgbody2d.velocity.y) < 1) stuckCounter += Time.deltaTime;
		if (stuckCounter > 0.5f) Destroy(gameObject);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("collision boop");
		if (collision.transform.tag != "Dude")
		{
			ContactPoint2D contact = collision.GetContact(0);
			rgbody2d.velocity = Vector2.Reflect(direction, contact.normal);
		}
		else
		{
			if (collision.transform.GetComponent<Rigidbody2D>())
				collision.transform.GetComponent<Rigidbody2D>().velocity = direction/3;
			foreach (HingeJoint2D joint in collision.transform.GetComponentsInChildren<HingeJoint2D>())
				joint.useMotor = false;
			Destroy(gameObject);
		}
	} 
}
