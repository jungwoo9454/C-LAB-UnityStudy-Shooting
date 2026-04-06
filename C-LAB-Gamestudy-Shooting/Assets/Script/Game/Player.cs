using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;   //직렬화
    Vector2 moveDir;
    Rigidbody2D rigidbody2D;    // 멤버변수

    void Start()    // 멤버함수
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = moveDir * speed;
    }

    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        moveDir.x = hor;
        moveDir.y = ver;
    }
}
