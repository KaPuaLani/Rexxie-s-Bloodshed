using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public string LevelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if we press the escape key
        // || = or  symbol above enter
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            //pause the game
            //make the pause menu appear
            GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Resume()
    {
        //Resume the game
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
