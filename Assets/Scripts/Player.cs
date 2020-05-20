using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf Animation
    /// </summary>
    private Rigidbody2D m_Rigidbody2D;

    private Vector2 moveVelocity;

    /// <summary>
    /// Laufgeschwindigkeit
    /// </summary>
    public float speed;

 
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        m_Rigidbody2D.MovePosition(m_Rigidbody2D.position + moveVelocity * Time.fixedDeltaTime);
    }

}
