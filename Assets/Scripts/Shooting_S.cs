using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class Shooting_S : MonoBehaviour
{
    private Vector2 start;
    private Vector2 end;
    private Vector2 direction;
    public float power = 0.0f;
    private float speed =  0.5f;
    private bool increasing = false;
    private bool charging = false;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    public bool spawnCheck = true;
    public bool swap = true;
    [SerializeField]
    private float spawnCoolDown = 0.0f;
    public int ballsUsed = 0;
    // Update is called once per frame
    private void Start()
    {
    }

    void Update()
    {
        if(!spawnCheck)
        spawnCoolDown -= 1.0f * Time.deltaTime;

        if (spawnCoolDown <= 0)
        {
            swap = true;
            spawnCheck = true;
            spawnCoolDown = 3.0f;
        }

        if(ballsUsed > 4)
        {
            ballsUsed = 0;
        }
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        if (gameObject)
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            start = gameObject.transform.position;
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (end - start).normalized;
            if (Input.GetMouseButtonDown(0)) 
            { 
                charging = true;
            }
            if (charging)
            {
                if (increasing)
                {
                    power += speed * Time.deltaTime;
                    if (power >= 1f)
                    {
                        power = 1f;
                        increasing = false;
                    }
                }
                else
                {
                    power -= speed * Time.deltaTime;
                    if (power <= 0.0f)
                    {
                        power = 0.0f;
                        increasing = true;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                charging = false;
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                gameObject.GetComponent<Rigidbody2D>().linearVelocity = direction * (power * gameObject.GetComponent<Stats_S>().Speed);
                gameObject.tag = "Untagged";
                spawnCheck = false;
                swap = false;
                power = 0f;
                ballsUsed++;
                return;  
            }
        }   
    }
}
