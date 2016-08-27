using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour
{
	[SerializeField]
	private float horizontalOffset;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Respawn")
		{
			Object.Instantiate(gameObject, gameObject.transform.position + new Vector3(horizontalOffset, 0.0f), Quaternion.identity);
		}
	}
}
