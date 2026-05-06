using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidbody;

    [SerializeField] float speed;
    Vector2 moveDir;

    float hp;
    [SerializeField] float maxHp;

    // Update is called once per frame
    void Update()
    {
        Clipping();
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocity = moveDir * speed;
    }

    void Clipping()
    {
        if (transform.position.y < -25)
        {
            gameObject.SetActive(false);
        }
    }

    public void Create(Vector2 position)
    {
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody2D>();

        hp = maxHp;

        moveDir = Vector2.down;

        transform.position = position;
        gameObject.SetActive(true);
    }
}
