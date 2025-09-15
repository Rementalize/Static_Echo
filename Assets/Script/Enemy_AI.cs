using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rigidbody;
    [SerializeField] float Speed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.MovePosition(new Vector2(rigidbody.position.x + Speed, rigidbody.position.y));
    }
}
