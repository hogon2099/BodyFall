using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{

	GameObject dude;
    void Start()
    {
		dude = GameObject.FindGameObjectWithTag("Dude");
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!(collision.transform.tag == "Bullet")) return;

		int coeff = 1;
		if (collision.transform.GetComponent<Rigidbody2D>())
			transform.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.transform.GetComponent<Rigidbody2D>().velocity.x * coeff, collision.transform.GetComponent<Rigidbody2D>().velocity.y * coeff);
		Destroy(collision.transform.gameObject);


		foreach (HingeJoint2D joint in dude.GetComponentsInChildren<HingeJoint2D>())
		{
			joint.useMotor = false;
			//	joint.useLimits = false;
		}
	}
}
