using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSceneButtons : MonoBehaviour
{
    public int buttonWidth;
    public int buttonHeight;
    private int origin_x;
    private int origin_y;

    // Use this for initialization
    void Start()
    {
        buttonWidth = 300;
        buttonHeight = 75;
        origin_x = Screen.width / 2 - buttonWidth / 2;
        origin_y = Screen.height / 2 - buttonHeight * 2;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(origin_x -450, origin_y + buttonHeight + 340, buttonWidth, buttonHeight), "Play Again"))
        {
            SceneManager.LoadScene(1);
        }

        if (GUI.Button(new Rect(origin_x + 450, origin_y + buttonHeight + 340, buttonWidth, buttonHeight), "Exit"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
        }
    }
}
