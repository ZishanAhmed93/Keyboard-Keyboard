using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpriteMovement : MonoBehaviour {

	public float movement = -1;
	public float verticalMovement = 0;
	public float speed = 4.4F;
	public Rigidbody2D rigid;

	// Use this for initialization
	void Start ()
	{
		if (rigid == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}

		if (movement != -1)
			movement = -1;

		if (verticalMovement != 0)
			verticalMovement = 0;

		if (speed != 4.4F)
			speed = 4.4F;
	}



	//called at a fixed rate. Best for physics (e.g. movement)
	void FixedUpdate ()
	{
		rigid.velocity = new Vector2 (movement * speed, verticalMovement * speed);
	}

}
