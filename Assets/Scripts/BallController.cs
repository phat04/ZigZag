using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    bool started;
    bool gameOver;

    [SerializeField] float speed;
    public GameObject particle;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !started)
        {
            rb.velocity = new Vector3(speed, 0, 0);
            started = true;

            GameManager.instance.StartGame();
        }

        //Debug.DrawRay(transform.position, Vector3.down, Color.red);

        bool isCollision = Physics.Raycast(transform.position, Vector3.down, 1f);
        if (!isCollision)
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -20f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Diamond")
        {
            Destroy(other.gameObject);
            GameObject instance = Instantiate(particle, other.transform.position, Quaternion.identity);
            Destroy(instance, 2f);
        }
    }
}
