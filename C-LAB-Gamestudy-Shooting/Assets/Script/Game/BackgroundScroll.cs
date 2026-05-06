using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform other;
    [SerializeField] float speed;

    float YInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        YInterval = Mathf.Abs(other.position.y - target.position.y);
    }

    void Update()
    {
        target.Translate(0, speed * Time.deltaTime, 0);
        other.Translate(0, speed * Time.deltaTime, 0);

        if (target.position.y <= -YInterval)
            target.position = other.position + Vector3.up * YInterval;


        if (other.position.y <= -YInterval)
            other.position = target.position + Vector3.up * YInterval;

    }
}
