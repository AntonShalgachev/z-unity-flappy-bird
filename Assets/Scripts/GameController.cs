using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private GameObject bird;
	[SerializeField]
	private GameObject gameOverCanvas;
	[SerializeField]
	private GameObject scoreCanvas;

	private BirdController birdController;
	private Text scoreText;
	private Text gameOverScoreText;
	private Text gameOverBestText;

	void Start ()
	{
		birdController = bird.GetComponent<BirdController>();

		scoreText = scoreCanvas.transform.FindChild("Score").gameObject.GetComponent<Text>();
		gameOverScoreText = gameOverCanvas.transform.FindChild("Score").gameObject.GetComponent<Text>();
		gameOverBestText = gameOverCanvas.transform.FindChild("Best").gameObject.GetComponent<Text>();

		scoreCanvas.SetActive(true);
		gameOverCanvas.SetActive(false);
	}
	
	void Update ()
	{
		var score = birdController.GetScore();
		scoreText.text = score.ToString();
		gameOverScoreText.text = score.ToString();

		if (!birdController.IsAlive())
		{
			scoreCanvas.SetActive(false);
			gameOverCanvas.SetActive(true);
		}
	}
}
