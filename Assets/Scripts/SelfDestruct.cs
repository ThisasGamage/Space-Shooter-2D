using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float timer = 1f;

	void Update () {
		//Laser self destruct timer
		timer -= Time.deltaTime;

		if(timer <= 0) {
			Destroy(gameObject);
		}
	}
}
