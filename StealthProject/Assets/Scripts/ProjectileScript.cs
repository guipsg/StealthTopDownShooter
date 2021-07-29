using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	[SerializeField] public enum Type
    {
		Green,
		Yellow,
		Red
    }
	[SerializeField] public Type type;
	[SerializeField] private float speed;
	[SerializeField] private float time;
	[SerializeField] private GameObject colisionParticle;
    private void Start()
    {
		StartCoroutine(DestroyBullet(time));
	}
    // Update is called once per frame
    void FixedUpdate () {
		transform.Translate (Vector2.right * speed * Time.fixedDeltaTime);
		
	}
	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Wall")
			StartCoroutine(DestroyBullet(0));

		if (c.gameObject.tag == "Enemy")
			StartCoroutine(DestroyBullet(0.1f));

	}

    IEnumerator DestroyBullet(float _time){
		yield return new WaitForSeconds(_time);
		Destroy(gameObject);
		Instantiate(colisionParticle, transform.position, transform.rotation);
	}

}
