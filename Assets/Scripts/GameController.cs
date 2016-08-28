using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	private enum State
	{
		Tutorial,
		Game,
		Death
	}

	[SerializeField]
	private GameObject bird;
	[SerializeField]
	private GameObject gameOverCanvas;
	[SerializeField]
	private GameObject scoreCanvas;
	[SerializeField]
	private GameObject tutorialCanvas;
	[SerializeField]
	private GameObject pipePrefab;

	[SerializeField]
	private float pipeHorizontalOffset;

	[SerializeField]
	private float birdVelocity;
	[SerializeField]
	private float birdPosY;
	[SerializeField]
	private float birdAmplitude;
	[SerializeField]
	private float birdFrequency;

	private BirdController birdController;
	private Rigidbody2D birdBody;
	private Text scoreText;
	private Text gameOverScoreText;
	private Text gameOverBestText;

	private State state;

	void Start ()
	{
		birdController = bird.GetComponent<BirdController>();
		birdBody = bird.GetComponent<Rigidbody2D>();

		scoreText = scoreCanvas.transform.FindChild("Score").gameObject.GetComponent<Text>();
		gameOverScoreText = gameOverCanvas.transform.FindChild("Score").gameObject.GetComponent<Text>();
		gameOverBestText = gameOverCanvas.transform.FindChild("Best").gameObject.GetComponent<Text>();

		state = State.Tutorial;
	}
	
	void Update ()
	{
		switch(state)
		{
			case State.Tutorial:
				tutorialCanvas.SetActive(true);
				scoreCanvas.SetActive(false);
				gameOverCanvas.SetActive(false);

				birdBody.isKinematic = true;
				birdBody.velocity = new Vector2(birdVelocity, 0.0f);

				float posY = birdPosY + birdAmplitude * Mathf.Sin(birdFrequency * Time.time);
				birdBody.position = new Vector2(birdBody.position.x, posY);

				if (Input.GetMouseButtonDown(0))
				{
					state = State.Game;
					birdBody.isKinematic = false;
					birdController.Flap();

					Object.Instantiate(pipePrefab, new Vector2(bird.transform.position.x + pipeHorizontalOffset, 0.0f), Quaternion.identity);
				}
				break;

			case State.Game:
				tutorialCanvas.SetActive(false);
				scoreCanvas.SetActive(true);
				gameOverCanvas.SetActive(false);

				if (Input.GetMouseButtonDown(0))
					birdController.Flap();
				birdController.KeepForwardVelocity(birdVelocity);

				var score = birdController.GetScore();
				scoreText.text = score.ToString();
				gameOverScoreText.text = score.ToString();

				if (!birdController.IsAlive())
					state = State.Death;
				break;

			case State.Death:
				tutorialCanvas.SetActive(false);
				scoreCanvas.SetActive(false);
				gameOverCanvas.SetActive(true);
				break;
		}
	}
}
