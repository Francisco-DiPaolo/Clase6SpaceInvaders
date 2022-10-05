using UnityEngine;
using System.Collections;

public class PlayerController : Shooting
{
    public bool isDeath;

    public float speed;

    public Transform transformShot;

    public override void Start()
    {
        base.Start();
        isDeath = false;
    }

    void Update()
    {
        if (!isDeath)
        {
            Movement();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AudioManager.instanceSound("shoot");
                Shoot(transformShot);
            }
        }
    }

    void Movement()
    {
        float inputx = Input.GetAxisRaw("Horizontal");

        if (speed != 0)
        {
            transform.Translate(transform.right * inputx * speed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser") && collision.transform.rotation.z != 0)
        {
            if (!isDeath) GameManager.loseLifeEvent?.Invoke();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.GetComponent<Enemy>() != null) GameManager.gameOverEvent?.Invoke();
    }
}
