using UnityEngine;

public class NpcVehicle : MonoBehaviour {
	private float _moveSpeed = 15f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
	}

	// Update is called once per frame
	void Update() {
		transform.Translate(Vector3.forward * (_moveSpeed * Time.deltaTime));
	}
}