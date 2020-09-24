using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public Transform button;
	public RectTransform Menu;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Dude")
		{
			Menu.GetComponent<LevelLoader>().ShowLevelEnd();
			this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			this.GetComponent<Rigidbody2D>().gravityScale = 10f;
		}
	}
}
