using UnityEngine;

public class ScriptPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private StateManager stateManager;
    [SerializeField] private float Speed;
    Rigidbody2D rigibody;
    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Tecla R Presionada");
            stateManager.ActivarModoMonocromatic();
        }

        if (Input.GetKey(KeyCode.A)) MoveHorizontal(-Speed);
        if (Input.GetKey(KeyCode.D)) MoveHorizontal(+Speed);
        if (Input.GetKey(KeyCode.W)) MoveVertical(+Speed);
        if (Input.GetKey(KeyCode.S)) MoveVertical(-Speed);
    }
    private void MoveHorizontal(float MoveX)
    {
        rigibody.MovePosition(new Vector2(rigibody.position.x + MoveX, rigibody.position.y));
    }
    private void MoveVertical(float MoveY)
    {
        rigibody.MovePosition(new Vector2(rigibody.position.x, rigibody.position.y + MoveY));
    }
}
