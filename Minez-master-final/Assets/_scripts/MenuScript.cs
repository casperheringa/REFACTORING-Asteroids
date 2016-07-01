using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas creditMenu;
    public Button startText;
    public Button exitText;

	// Use this for initialization
	void Start () {

        startText = startText.GetComponent<Button>();
        creditMenu = creditMenu.GetComponent<Canvas>();
        exitText = exitText.GetComponent<Button>();
        creditMenu.enabled = false;

	}
    public void StartLevel()
    {
        SceneManager.LoadScene("scene1");
    }

    public void ExitPress()
    {
        Debug.Log("Cancer");
        creditMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        creditMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }
}
