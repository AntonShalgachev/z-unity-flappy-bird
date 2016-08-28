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
	private bool alive = true;
	private int score = 0;

	void Start()
	{
		birdBody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (!alive)
			return;

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

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "ScoreTrigger")
		{
			Debug.Log("Entered trigger: " + collider);
			score++;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (alive)
		{
			Debug.Log("Bird collided with " + collision.collider);
			alive = false;
			gameObject.layer = LayerMask.NameToLayer("DeadBird");
		}
	}

	public bool IsAlive()
	{
		return alive;
	}

	public int GetScore()
	{
		return score;
	}
}
