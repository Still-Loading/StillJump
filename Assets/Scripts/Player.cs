using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private LayerMask platformLayerMask;

    /// <summary>
    /// Zeiger auf Animation
    /// </summary>
    private Rigidbody2D m_Rigidbody2D;
    private BoxCollider2D boxCollider2D;

    private Vector2 moveVelocity;

    /// <summary>
    /// Laufgeschwindigkeit
    /// </summary>
    public float speed;

 
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetAxis("Jump") > 0)
        {
            float jumpVelocity = 2f;
            m_Rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }

          //  Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
          //  moveVelocity = moveInput.normalized * speed;
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
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightText, platformLayerMask);

        return raycastHit.collider != null;
    }

}
