using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private static StateManager instance;
    public static StateManager Instance => instance;

    private readonly List<IDualObject> objects = new();

    [SerializeField] private float CoolMonocromatic = 3f;
    [SerializeField] private float CooldownReactiveMono = 5f;
    private bool Monocromatic = false;
    private bool CooldownActiveMono = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Registrar(IDualObject obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("Intentando registrar un objeto nulo.");
            return;
        }

        if (!objects.Contains(obj))
        {
            objects.Add(obj);
            obj.ActivarModoNormal();
        }
    }

    public void DesRegistrar(IDualObject obj)
    {
        if (objects.Contains(obj))
        {
            objects.Remove(obj);
        }
    }

    public void ActivarModoMonocromatic()
    {

        if (Monocromatic||CooldownActiveMono) 
        {
            if (Monocromatic)
            {
                Debug.Log("Modo Monocromatico ya activado");
            }
            if (CooldownActiveMono)
            {
                Debug.Log("Modo Monocromatico en cooldown");
            }
            return; 
        }

        Monocromatic = true;
        foreach (var obj in objects)
        {
            Debug.Log("Modo Monocromatico Activado");   
            obj.ActivarModoMonocromatic();
        }

        CancelInvoke(nameof(ActivarModoNormal));
        
        Invoke(nameof(ActivarModoNormal), CoolMonocromatic);
    }

    public void ActivarModoNormal()
    {
        Monocromatic = false;
        foreach (var obj in objects)
        {
            obj.ActivarModoNormal();
        }
        CooldownActiveMono = true;
        CancelInvoke(nameof(EndCooldown));
        Invoke(nameof(EndCooldown), CooldownReactiveMono);
    }

    private void EndCooldown()
    {
        CooldownActiveMono = false;
    }
    public bool EstaEnModoMonocromatic() => Monocromatic;
}