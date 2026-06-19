using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float player_Thrust = 2f;
    public float player_max_Speed = 5f;


    public float score_mult = 0f;
    private int final_time = 0;
    private float elapsed_time = 0f;

    Rigidbody2D rb;
    public GameObject booster_flame;
    public UIDocument uiDocument;
    public GameObject Explosion_effect;
    private Button restartButton;
    private Button menuButton;
    public GameObject booster_sparks;

    private Label scoreText;
    private Label highScoreText;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        restartButton = uiDocument.rootVisualElement.Q<Button>("Restart_Btn");
        menuButton = uiDocument.rootVisualElement.Q<Button>("Menu_Btn");
        menuButton.style.display = DisplayStyle.None; 
        restartButton.style.display = DisplayStyle.None;

        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        highScoreText = uiDocument.rootVisualElement.Q<Label>("HighScoreLabel");

        restartButton.clicked += ReloadScene;
        menuButton.clicked += Load_Scene;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateScore();
        Move_Player();

    }

    void UpdateScore()
    {
        elapsed_time += Time.deltaTime;
        final_time = Mathf.FloorToInt(elapsed_time * score_mult);

        scoreText.text = "Score: " + final_time;

        if(final_time > GameData.Highscore)
        {
            GameData.Highscore = final_time;
        }
        highScoreText.text = "High Score: " + GameData.Highscore;
    }

    void Move_Player()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            //takes pos of mouse and converts to world point, logging location
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

            //normalizes mouse player dir and moves player to face mouse
            Vector2 player_Dir = (mousepos - transform.position).normalized;
            transform.up = player_Dir;

            //pushes player towards mouse pos
            rb.AddForce(player_Dir * player_Thrust);

            //set max speed of player set
            if (rb.linearVelocity.magnitude > player_max_Speed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * player_max_Speed;
            }

        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            booster_flame.SetActive(true);
            booster_sparks.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            booster_flame.SetActive(false);
            booster_sparks.SetActive(false);
        }
    }

    //automatically called when player collides with anything with rigid2b
    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(Explosion_effect, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex;
        menuButton.style.display = DisplayStyle.Flex;
        Destroy(gameObject);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Load_Scene()
    {
        SceneManager.LoadScene("opening screen");
    }
}
