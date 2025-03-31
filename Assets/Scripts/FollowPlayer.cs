using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform player; // The player's Transform (plane)

	private Vector3 followViewOffset = new Vector3(0, 3, -7); // Third-person follow offset
	private Vector3 cockpitViewOffset = new Vector3(0, 2, 0.5f); // Cockpit view offset

	// private Quaternion followViewRotation = Quaternion.Euler(10, 0, 0); // Slightly tilted down
	// private Quaternion cockpitViewRotation = Quaternion.Euler(0, 0, 0); // Matches player's rotation

	private Vector3 targetOffset;

	// private Quaternion targetRotation;
	private bool isSwitching = false;

	public float transitionSpeed = 2.0f;

	void Start() {
		// Start in follow view
		targetOffset = followViewOffset;
		// targetRotation = followViewRotation;

		InitializeCameraPosition();
	}

	void LateUpdate() {
		if (Input.GetKeyDown(KeyCode.C) && !isSwitching) {
			if (targetOffset == followViewOffset) {
				targetOffset = cockpitViewOffset;
				// targetRotation = cockpitViewRotation;
			}
			else {
				targetOffset = followViewOffset;
				// targetRotation = followViewRotation;
			}

			StartCoroutine(SwitchCamera());
		}

		transform.position = player.position + targetOffset;
		// transform.rotation = player.rotation * targetRotation;
	}

	void InitializeCameraPosition() {
		// Set camera position relative to the player
		transform.position = player.position + targetOffset;
		// transform.rotation = player.rotation * targetRotation;
	}

	IEnumerator SwitchCamera() {
		isSwitching = true;
		float elapsedTime = 0f;
		Vector3 startPosition = transform.position;
		// Quaternion startRotation = transform.rotation;

		while (elapsedTime < 1f) {
			elapsedTime += Time.deltaTime * transitionSpeed;
			transform.position = Vector3.Lerp(startPosition, player.position + targetOffset, elapsedTime);
			// transform.rotation = Quaternion.Lerp(startRotation, player.rotation * targetRotation, elapsedTime);
			yield return null;
		}

		// Ensure final position and rotation match the target
		transform.position = player.position + targetOffset;
		// transform.rotation = player.rotation * targetRotation;
		isSwitching = false;
	}
}