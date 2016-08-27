using UnityEngine;
using System.Collections;

public class VelocityRotation : MonoBehaviour
{
	[SerializeField]
	private float angleMin;
	[SerializeField]
	private float angleMax;
	[SerializeField]
	private float sensitivity;

	private Rigidbody2D body;

	void Start ()
	{
		body = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		var verticalVelocity = body.velocity.y;

		var angle = 0.0f;
		if (verticalVelocity > 0.0f)
			angle = Mathf.LerpAngle(0.0f, angleMax, verticalVelocity * sensitivity);
		else
			angle = Mathf.LerpAngle(0.0f, angleMin, -verticalVelocity * sensitivity);

		transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
	}
}
