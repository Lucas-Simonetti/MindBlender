using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortas : MonoBehaviour
{

    public PolygonCollider2D colisorPorta;
    public GameObject pontoTeleporte;
    public GameObject cenarioNovo;
    public GameObject cenarioAntigo;

    // Start is called before the first frame update
    void Start()
    {
        cenarioNovo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
