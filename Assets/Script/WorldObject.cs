using UnityEngine;

public class WorldObject : MonoBehaviour, IDualObject
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spriteMonocromatic;
    [SerializeField] private Sprite spriteNormal;
    private bool yaRegistrado = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        RegistrarEnManager();
    }

    private void OnEnable()
    {
        if (!yaRegistrado)
        {
            RegistrarEnManager();
        }
    }

    private void OnDisable()
    {
        if (StateManager.Instance != null)
        {
            StateManager.Instance.DesRegistrar(this);
            yaRegistrado = false;
            Debug.Log("Objeto Mundo Desregistrado");
        }
    }

    private void RegistrarEnManager()
    {
        if (StateManager.Instance != null)
        {
            StateManager.Instance.Registrar(this);
            yaRegistrado = true;
            Debug.Log("Objeto Mundo Registrado");
        }
    }

    public void ActivarModoMonocromatic()
    {
        Debug.Log("Activar Modo Monocromático Objeto");
        spriteRenderer.sprite = spriteMonocromatic;
    }

    public void ActivarModoNormal()
    {
        Debug.Log("Activar Modo Normal Objeto");
        spriteRenderer.sprite = spriteNormal;
    }
}