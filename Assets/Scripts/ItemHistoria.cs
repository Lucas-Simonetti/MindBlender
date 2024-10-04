using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ItemHistoria : MonoBehaviour
{

    [Header("Componentes")]
    [SerializeField] public GameObject painelCarta;

    // Start is called before the first frame update
    void Start()
    {
        painelCarta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarCarta()
    {
        painelCarta.SetActive(true);
    }

    public void FecharCarta()
    {
        Player.instancia.podeMover = true;
        painelCarta.SetActive(false);
    }
}
