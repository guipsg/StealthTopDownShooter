using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	[SerializeField] private enum Type
    {
		Green,
		Yellow,
		Red
    }
	[SerializeField] private Type type;
	[SerializeField] private float speed;
	[SerializeField] private float time;
	[SerializeField] private GameObject colisionParticle;

	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector2.right * speed * Time.fixedDeltaTime);
		Destroy (gameObject, time);
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Wall") {
			Destroy (gameObject);
			Instantiate (colisionParticle, transform.position, transform.rotation);
		} else {
			Destroy (gameObject, time);
		}


	}



}
