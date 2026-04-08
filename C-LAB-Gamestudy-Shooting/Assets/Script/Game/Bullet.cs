using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // public - 모든 클래스 접근
    // private - 자기 자신

    Rigidbody2D rigidbody2D;
    [SerializeField] float speed;
    Vector2 moveDir;
    float attack;


    private void Start()
    {
        //rigidbody2D = GetComponent<Rigidbody2D>();
        moveDir = Vector2.up;
    }

    void Update()
    {
        Clipping();
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = moveDir * speed;
    }

    void Clipping()
    {
        if (transform.position.y > 30)
            gameObject.SetActive(false);
    }


    public void Create(Vector2 position)
    {
        if (rigidbody2D == null)
            rigidbody2D = GetComponent<Rigidbody2D>();

        transform.position = position;
        gameObject.SetActive(true);
    }
}
