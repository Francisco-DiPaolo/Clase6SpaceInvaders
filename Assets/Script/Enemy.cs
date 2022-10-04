using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public GameObject[] invader;
    public int rows = 5;
    public int columns = 11;

    public float speed;

    public static Action dieEnemyEvent;

    private Vector3 direction = Vector2.right;

    void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float width = 2 * (columns - 1);
            float height = 2 * (rows - 1);
            Vector2 center = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(center.x, center.y + (row * 2), 0);

            for (int col = 0; col < columns; col++)
            {
                GameObject invaders = Instantiate(invader[row], transform);
                Vector3 position = rowPosition;
                position.x += col * 2;
                invaders.transform.localPosition = position;
            }
        } 
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invaders in transform)
        {
            if (!invaders.gameObject.activeInHierarchy) continue;

            if (direction == Vector3.right && invaders.position.x >= (rightEdge.x - 1))
            {
                AdvanceRow();
            } else if (direction == Vector3.left && invaders.position.x <= (leftEdge.x + 1))
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        direction.x *= -1;

        Vector3 position = transform.position;
        position.y -= 1;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            Debug.Log("Pepe");
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
}
