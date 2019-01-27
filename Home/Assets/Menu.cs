using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject buttons;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isActive)
            {
                buttons.SetActive(false);
                isActive = false;
            }
                
            else
            {
                buttons.SetActive(true);
                isActive = true;
            }
                
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("TitleScreen1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
