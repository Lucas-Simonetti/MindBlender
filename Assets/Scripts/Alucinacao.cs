using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alucinacao : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Desativar()
    {
        spriteRenderer.color = new Color(1,1,1,0);
    }
    public void Ativar()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
