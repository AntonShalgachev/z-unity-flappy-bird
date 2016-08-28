using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour
{
	[SerializeField]
	private GameObject bird;
	[SerializeField]
	private float verticalOffset;

	private BirdController birdController;
	private Text scoreText;

	void Start ()
	{
		birdController = bird.GetComponent<BirdController>();
		scoreText = transform.FindChild("Score").gameObject.GetComponent<Text>();

		Debug.Assert(birdController != null);
		Debug.Assert(scoreText != null);
	}
	
	void Update ()
	{
		var score = birdController.GetScore();
		scoreText.text = score.ToString();
	}
}
