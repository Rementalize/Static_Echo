using UnityEngine;

public class Enemy : MonoBehaviour, IDualObject
{
    private SpriteRenderer spriteRenderer;
    private Enemy_AI ia;
    private bool yaRegistrado = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ia = GetComponent<Enemy_AI>();
    }

    private void Start()
    {
        RegistrarEnManager();
    }

    private void OnEnable()
    {
        if (!yaRegistrado)
            RegistrarEnManager();
    }

    private void OnDisable()
    {
        if (StateManager.Instance != null)
        {
            StateManager.Instance.DesRegistrar(this);
            yaRegistrado = false;
        }
    }

    private void RegistrarEnManager()
    {
        if (StateManager.Instance != null)
        {
            StateManager.Instance.Registrar(this);
            yaRegistrado = true;
        }
    }

    public void ActivarModoMonocromatic()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        ia.enabled = false;
    }

    public void ActivarModoNormal()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
        ia.enabled = true;
    }
}