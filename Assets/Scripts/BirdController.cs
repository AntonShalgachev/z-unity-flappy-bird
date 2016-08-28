using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour
{
	[SerializeField]
	private float flapImpulse;
	[SerializeField]
	private float forwardForce;

	private Rigidbody2D birdBody;
	private bool alive = true;
	private int score = 0;

	private Animator animator;

	void Start()
	{
		birdBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (!alive)
			return;

		//if (Input.GetMouseButtonDown(0))
		//	Flap();

		//if (birdBody.velocity.x < velocity)
		//	birdBody.AddForce(new Vector2(forwardForce, 0.0f));
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
			animator.SetTrigger("BirdDeath");
		}
	}

	public void Flap()
	{
		Vector2 impulse = new Vector2(0.0f, flapImpulse);

		var vel = birdBody.velocity;
		var targetVel = new Vector2(vel.x, 0.0f);
		if (vel.y < 0.0f)
			impulse += birdBody.mass * (targetVel - vel);

		birdBody.AddForce(impulse, ForceMode2D.Impulse);
	}

	public void KeepForwardVelocity(float velocity)
	{
		if (birdBody.velocity.x < velocity)
			birdBody.AddForce(new Vector2(forwardForce, 0.0f));
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
