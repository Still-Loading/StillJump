using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf Animation
    /// </summary>
    private Rigidbody2D m_Rigidbody2D;

    /// <summary>
    /// Laufgeschwindigkeit
    /// </summary>
    public float speed;
    public float jumpVelocity;

    private int collectableCounter;
    public Text score;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        collectableCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && (Input.GetAxis("Jump") > 0 || Input.GetAxis("Vertical") > 0))
        {
            m_Rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            collectableCounter++;
            score.text = "Score: " + collectableCounter;
        }
        if (collision.CompareTag("CheckPoint"))
        {
            Debug.Log("Ich bin am CheckPoint");
            SpriteRenderer sprite = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
            sprite.enabled = true;
        }
    }

    private void FixedUpdate()
    {
       
        m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetAxis("Horizontal") < 0)
        {
            m_Rigidbody2D.velocity = new Vector2(-speed, m_Rigidbody2D.velocity.y);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            m_Rigidbody2D.velocity = new Vector2(+speed, m_Rigidbody2D.velocity.y);
        }
        else
        {
            m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
       
    }


    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }

}
