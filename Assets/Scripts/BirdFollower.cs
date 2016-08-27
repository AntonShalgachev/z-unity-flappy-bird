using UnityEngine;
using System.Collections;

public class BirdFollower : MonoBehaviour
{
	[SerializeField]
	private Transform player;
	[SerializeField]
	private float offset;
	
	void Update ()
	{
		var playerPos = player.position;
		var cameraPos = transform.position;

		cameraPos.x = playerPos.x + offset;
		transform.position = cameraPos;
	}
}
