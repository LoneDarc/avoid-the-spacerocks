using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class GameData : MonoBehaviour
{
    public static int difficulty = 0;
    public static int Highscore = 0;
}


public class OpeningScreen : MonoBehaviour
{


    public UIDocument ui;

    private Button Play_Button;
    private Button Exit_Button;
    private Button Easy_Button;
    private Button Medium_Button;
    private Button Hard_Button;
    private Label difficulty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Play_Button = ui.rootVisualElement.Q<Button>("Play_Button"); 
        Exit_Button = ui.rootVisualElement.Q<Button>("Exit_Button");
        Easy_Button = ui.rootVisualElement.Q<Button>("Easy_button");
        Medium_Button = ui.rootVisualElement.Q<Button>("Medium_button");
        Hard_Button = ui.rootVisualElement.Q<Button>("Hard_button");
        difficulty = ui.rootVisualElement.Q<Label>("Difficulty");

        Easy_Button.clicked += Set_easy;
        Medium_Button.clicked += Set_Medium;
        Hard_Button.clicked += Set_Hard;
        Play_Button.clicked += Load_Scene;
        Exit_Button.clicked += Exit_Game;
    }

    // Update is called once per frame
    void Update()
    {

        switch (GameData.difficulty)
        {
            case 0: difficulty.text = "Difficulty set: Easy"; break;
            case 1: difficulty.text = "Difficulty set: Medium"; break;
            case 2: difficulty.text = "Difficulty set: Hard"; break;
        }
        
    }

    void Load_Scene()
    {
        SceneManager.LoadScene("game");
    }

    void Exit_Game()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void Set_easy()
    {
        GameData.difficulty = 0;
    }
    void Set_Medium()
    {
        GameData.difficulty = 1;
    }
    void Set_Hard()
    {
        GameData.difficulty = 2;
    }
}

