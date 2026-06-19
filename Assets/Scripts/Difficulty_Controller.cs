using UnityEngine;

public class Difficulty_Controller : MonoBehaviour
{
    public GameObject Medium_dif;
    public GameObject Hard_dif;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(GameData.difficulty == 0)
        {
            Medium_dif.SetActive(false);
            Hard_dif.SetActive(false);
        }
        else if(GameData.difficulty == 1)
        {
            Medium_dif.SetActive(true);
            Hard_dif.SetActive(false);
        }
        else if(GameData.difficulty == 2)
        {
            Medium_dif.SetActive(true);
            Hard_dif.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
