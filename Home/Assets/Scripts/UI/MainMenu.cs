using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	#region Variables (public)

	#endregion

	#region Variables (protected)

	#endregion

	#region Variables (private)

	#endregion

	#region Getters_Setters

	#endregion

	#region Unity
	// Use this for initialization
	private void Start()
	{
	
	}

	// Update is called once per frame
	private void Update()
	{
	
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