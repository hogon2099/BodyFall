using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedWeapon : MonoBehaviour
{
	Rigidbody2D RgBody2D;
	float inputX;
	float inputY;
	float speed = 10f;
	// Start is called before the first frame update
	void Start()
    {
		RgBody2D = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
	{
		 inputX = Input.GetAxis("Horizontal");
		RgBody2D.velocity = new Vector2(inputX*speed , RgBody2D.velocity.y);
		 inputY = Input.GetAxis("Vertical");
		RgBody2D.velocity = new Vector2(RgBody2D.velocity.x, inputY* speed);
	}
}
