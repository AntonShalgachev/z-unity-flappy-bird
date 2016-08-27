using UnityEngine;
using System.Collections;

public class PipeConfigurer : MonoBehaviour
{
	[SerializeField]
	private float posYMin;
	[SerializeField]
	private float posYMax;

	[SerializeField]
	private float gap;

	GameObject pipeBottom;
	GameObject pipeTop;
	GameObject scoreTrigger;

	void Start ()
	{
		pipeBottom = transform.Find("PipeBottom").gameObject;
		pipeTop = transform.Find("PipeTop").gameObject;
		scoreTrigger = transform.Find("ScoreTrigger").gameObject;

		if (!pipeBottom)
			Debug.LogError("Couldn't find PipeBottom");
		if (!pipeTop)
			Debug.LogError("Couldn't find PipeTop");
		if (!scoreTrigger)
			Debug.LogError("Couldn't find ScoreTrigger");

		var pipePosY = Random.Range(posYMin, posYMax);
		transform.position = new Vector2(transform.position.x, pipePosY);

		pipeBottom.transform.localPosition = new Vector2(0.0f, -0.5f * gap);
		pipeTop.transform.localPosition = new Vector2(0.0f, 0.5f * gap);
		scoreTrigger.transform.localScale = new Vector2(scoreTrigger.transform.localScale.x, gap);
	}
}
