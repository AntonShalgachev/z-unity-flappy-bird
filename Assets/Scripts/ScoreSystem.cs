using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour
{
	[SerializeField]
	private GameObject bird;
	[SerializeField]
	private float verticalOffset;
	//[SerializeField]
	//private GameObject placeholder;

	private BirdController birdController;
	private Text scoreText;
	//private int score = 0;
	//private int digits = 1;
	//private ArrayList<GameObject> placeholders;

	void Start ()
	{
		birdController = bird.GetComponent<BirdController>();
		scoreText = transform.FindChild("Score").gameObject.GetComponent<Text>();

		Debug.Assert(birdController != null);
		Debug.Assert(scoreText != null);
	}
	
	void Update ()
	{
		//var newScore = birdController.GetScore();
		//var newDigits = Digits(newScore);

		//if (newDigits > digits)
		//{

		//}

		var score = birdController.GetScore();
		scoreText.text = score.ToString();
	}

	int Digits(int val)
	{
		Debug.Assert(val >= 0);

		if (val == 0)
			return 1;

		int digits = 0;

		while(val > 0)
		{
			val /= 10;
			digits++;
		}

		return digits;
	}
}
