using UnityEngine;

public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit(Collider other) {
		// Destroy everything that leaves the trigger
		Destroy(other.gameObject);
	}
}