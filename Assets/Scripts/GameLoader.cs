using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

	public void LoadGame()
	{
		SceneManager.LoadScene("Game");
	}
}
