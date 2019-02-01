using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	#region Variables (public)

	#endregion

	#region Variables (protected)

	#endregion

	#region Variables (private)

	private Button playButton;
	private Button quitButton;

	#endregion

	#region Getters_Setters

	#endregion

	#region Unity
	// Use this for initialization
	private void Start()
	{
		playButton = transform.Find("PlayButton").GetComponent<Button>();
		quitButton = transform.Find("QuitButton").GetComponent<Button>();

		if(playButton == null)
			Debug.Log("is null");

		playButton.Select();
	}

	// Update is called once per frame
	private void Update()
	{
		if(Input.GetAxis("Vertical") > 0)
		{
			playButton.Select();
		}
		else if(Input.GetAxis("Vertical") < 0)
		{
			quitButton.Select();
		}

	}
	#endregion

	#region Custom

    public void LoadScene(int i_sceneIndex)
    {
        SceneManager.LoadScene(i_sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

	#endregion
}