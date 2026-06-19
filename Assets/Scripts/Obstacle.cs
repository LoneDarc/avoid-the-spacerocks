using UnityEngine;
using UnityEngine.UIElements;




public class Obstacle : MonoBehaviour
{

    //min and max size of obstacle
    public float min_size = 0.5f;
    public float max_size = 2.0f;

    //min and max speed of obstacle
    public float min_speed = 50f;
    public float max_speed = 200f;

    //max speed of spin
    public float max_spin = 5f;


    public GameObject Bounce_effect;

    Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
        //scale object to random size, x and y get same size
        float rand_Size = Random.Range(min_size, max_size);
        transform.localScale = new Vector3(rand_Size, rand_Size, 2);

        //change mass to scale with created scale of obstacles
        rb.mass = (rand_Size * rand_Size) * rb.mass;

        //sets random speed and multiplies by mass to scale
        float rand_Speed = Random.Range(min_speed, max_speed) * rb.mass;
        Vector2 rand_dir = Random.insideUnitCircle;
        rb.AddForce(rand_dir * rand_Speed);

        //random spin at start
        float rand_spin = Random.Range(-max_spin, max_spin) * rb.mass;
        rb.AddTorque(rand_spin);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(Bounce_effect, transform.position, transform.rotation);
    }
}
