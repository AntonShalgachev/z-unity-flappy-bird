using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour
{
	[SerializeField]
	private float flapImpulse;
	[SerializeField]
	private float forwardForce;
	[SerializeField]
	private float velocity;

	private Rigidbody2D birdBody;

	void Start()
	{
		birdBody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 impulse = new Vector2(0.0f, flapImpulse);

			var vel = birdBody.velocity;
			var targetVel = new Vector2(vel.x, 0.0f);
			if (vel.y < 0.0f)
				impulse += birdBody.mass * (targetVel - vel);

			birdBody.AddForce(impulse, ForceMode2D.Impulse);
		}

		if (birdBody.velocity.x < velocity)
			birdBody.AddForce(new Vector2(forwardForce, 0.0f));
	}
}
