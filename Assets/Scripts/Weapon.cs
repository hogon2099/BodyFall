using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform bullet;
	public Transform gunPoint;
	public bool isFacingRight = true;
	public float currentAngle;
	public float speed = 50f;

	private float delayTime = 0.5f;
	public float counter;

	public void Shoot()
	{
		if (!Input.GetMouseButton(0) || counter < delayTime) return;

		counter = 0;
		float direction;
		if (isFacingRight) direction = 1; else direction = -1;
		Transform clone = Instantiate(bullet, gunPoint.position, Quaternion.Euler(0,0,currentAngle));
		clone.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Mathf.Cos(currentAngle * Mathf.Deg2Rad),  speed * Mathf.Sin(currentAngle * Mathf.Deg2Rad));
		GameObject.FindGameObjectWithTag("Stars").GetComponent<Stars>().shotedShots++;
	}
	private void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	private void Rotate(Transform item)
	{
		//float maxAngle = 20;
		//float minAngle = -20;

		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 direction = new Vector2(mousePos.x - item.position.x, mousePos.y - item.position.y).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		//if (isFacingRight)
		//	if (angle >= 0 || angle < 0)
		//		item.Rotate(new Vector3(0, 0, angle), Space.Self);

		//if (!isFacingRight)
		//	if (angle <= 180 || angle > -180)
		//		if (angle > 0) item.Rotate(new Vector3(0, 0, angle - 180), Space.Self);
		//		else item.Rotate(new Vector3(0, 0, 180 + angle), Space.Self);


		currentAngle = angle;
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
	private void FollowMouse()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
		float angle = Mathf.Atan2(direction.y, direction.x);
		if (isFacingRight)
			if (Mathf.Cos(angle) < 0)
				Flip();
		if (!isFacingRight)
			if (Mathf.Cos(angle) > 0)
				Flip();
	}
	void Start()
	{
		if (!bullet.GetComponent<Rigidbody2D>())
		{
			this.enabled = false;
			Debug.Log("[Weapon] На префабе пули нет компонента Rigidbody2D");
		}
	}

	// Update is called once per frame
	void Update()
	{
		counter += Time.deltaTime;
		Rotate(this.transform);
		//FollowMouse();
		Shoot();
	}
}
