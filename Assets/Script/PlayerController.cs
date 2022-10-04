using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float proyectileSpeed;
    public float cooldownShot;

    public Transform transformShot;

    public bool isDeath;

    float lastShot;
    PoollingObject poolProyectile;

    private void Start()
    {
        isDeath = false;
        poolProyectile = FindObjectOfType<PoollingObject>();
    }

    void Update()
    {
        if (!isDeath)
        {
            Movement();
            if (Input.GetKeyDown(KeyCode.Space)) Shooting();
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
    
    void Shooting()
    {
        if(Time.time - lastShot < cooldownShot)
        {
            return;
        }
        lastShot = Time.time;

        GameObject proyectile = poolProyectile.GetPooledObject();

        if(proyectile != null)
        {
            proyectile.transform.position = transformShot.position;
            proyectile.transform.rotation = transformShot.rotation;
            proyectile.SetActive(true);
            proyectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, proyectileSpeed));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Dario");
            if (!isDeath) GameManager.loseLifeEvent?.Invoke();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.GetComponent<Enemy>() != null) GameManager.gameOverEvent?.Invoke();
    }
}
