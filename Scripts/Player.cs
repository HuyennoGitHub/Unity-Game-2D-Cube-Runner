using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D m_rb;

    GameController m_gc;

    public float jumpForce;

    bool m_isGrounded;

    public AudioSource aus;

    public AudioClip jumpSound;
    public AudioClip loseSound;

    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);

        if (isJumpKeyPressed && m_isGrounded)
        {
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGrounded = false;

            if (aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }
        }
    }

    public void Jump()
    {
        if (!m_isGrounded) return;

        m_rb.AddForce(Vector2.up * jumpForce);
        m_isGrounded = false;

        if (aus && jumpSound)
        {
            aus.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            m_isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            m_gc.SetGameoverState(true);
            if (aus && loseSound)
            {
                aus.PlayOneShot(loseSound);
            }
            Debug.Log("Gameover");
        }
    }
}
