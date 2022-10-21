using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public int health = 1;

	public float invulnPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;

	SpriteRenderer spriteRend;

	void Start() {
		correctLayer = gameObject.layer;

		spriteRend = GetComponent<SpriteRenderer>();

		if(spriteRend == null) {
			spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

			if(spriteRend==null) {
				Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer.");
			}
		}
	}

	//Decreases health when triggered
	void OnTriggerEnter2D() {
		health--;

        if (invulnPeriod > 0) {
			invulnTimer = invulnPeriod;
			gameObject.layer = 10;
		}
	}

	void Update() {
		//Invulnerability Timer
		if(invulnTimer > 0) {
			invulnTimer -= Time.deltaTime;

			if(invulnTimer <= 0) {
				gameObject.layer = correctLayer;
				if(spriteRend != null) {
					spriteRend.enabled = true;
				}
			}
			else {
				if(spriteRend != null) {
					spriteRend.enabled = !spriteRend.enabled;
				}
			}
		}

		//Destroys when health reaches 0
		if(health <= 0) {
            Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
}
