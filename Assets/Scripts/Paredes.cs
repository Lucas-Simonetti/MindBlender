using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paredes : MonoBehaviour
{
    public GameObject paredes;
    public PolygonCollider2D colisor;
    SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRendererPorta;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AtivarColisor()
    {
        colisor.enabled = true;
    }
    public void DesativarColisor()
    {
        colisor.enabled = false;
    }
    public void RemoverParedes()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.2f);
        spriteRendererPorta.color = new Color(1, 1, 1, 0.2f);
    }
    public void VoltarParedes()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
        spriteRendererPorta.color = new Color(1, 1, 1, 1);
    }
}
