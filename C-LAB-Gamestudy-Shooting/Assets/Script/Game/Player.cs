using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;   //직렬화
    Vector2 moveDir;
    Rigidbody2D rigidbody2D;    // 멤버변수
    Animator animator;

    void Start()    // 멤버함수
    {
        animator = GetComponent<Animator>();
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

        animator.SetFloat("move", Mathf.Abs(hor) + Mathf.Abs(ver));
    }

    void Attack()
    {
        animator.SetBool("isAttack", Input.GetKey(KeyCode.Space));
    }

    public void FireBullet()
    {
        BulletMng.ins.CreateBullet(transform.position);
    }
}
