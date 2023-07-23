using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    GameController m_gc;

    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.IsGameover()) return;
        transform.position = transform.position + Vector3.left* moveSpeed*Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SceneLimit"))
        {
            m_gc.IncreaseScore();

            Destroy(gameObject);
        }
    }
}
