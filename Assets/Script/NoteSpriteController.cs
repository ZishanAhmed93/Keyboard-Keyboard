using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpriteController : MonoBehaviour {

	public static float sharedSpeed;
	public float speed;
	public Rigidbody2D rigid;

	// Use this for initialization
	void Start ()
	{
		if (rigid == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}

		if(speed != 4.0F)
			speed = 4.0F;
		

	}
	public float getSpeed(){
		return sharedSpeed;
	}
	public void setSpeed(float s){
		sharedSpeed = s;
		speed = sharedSpeed;
	}

	//called at a fixed rate. Best for physics (e.g. movement)
	void FixedUpdate ()
	{
		rigid.velocity = new Vector2 ( -1.0F * speed, 0.0F);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if(col.tag == "Player"){
			if(tag == "halfNote")
				speed = speed / 2.0F;

			if(tag == "wholeNote")
				speed = speed / 4.0F;

			if(tag == "eighthNote")
				speed = speed * 2.0F;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.tag == "Player"){
			if(tag == "halfNote")
				speed = speed * 2.0F;

			if(tag == "wholeNote")
				speed = speed * 4.0F;

			if(tag == "eighthNote")
				speed = speed / 2.0F;
		}
	}
}
