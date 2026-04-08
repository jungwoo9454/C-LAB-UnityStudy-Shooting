using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] BulletMng bulletmng;
    [SerializeField] float speed;   //직렬화
    Vector2 moveDir;
    Rigidbody2D rigidbody2D;    // 멤버변수

    [SerializeField] float attackTime;
    float curAttackTime;

    void Start()    // 멤버함수
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Attack();
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

    void Attack()
    {
        curAttackTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && curAttackTime >= attackTime)
        {
            curAttackTime = 0;
            bulletmng.CreateBullet(transform.position);
        }
    }
}
