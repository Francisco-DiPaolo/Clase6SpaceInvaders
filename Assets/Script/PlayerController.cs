using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float inputx = Input.GetAxis("Horizontal");

        if (speed != 0)
        {
            transform.Translate(transform.right * inputx * speed * Time.deltaTime, 0);
        }
    }
}
