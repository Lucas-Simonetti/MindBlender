using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private string Menu;
    [SerializeField] public GameObject painelPause;
    public bool pausar;


    // Start is called before the first frame update
    void Start()
    {
        painelPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pausar = Input.GetKeyDown(KeyCode.Escape);
        if (pausar == true)
        {
            AbrirPause();
        }
    }

    public void AbrirPause()
    {
        painelPause.SetActive(true);
        Player.instancia.podeMover = false;
    }
    public void FecharPause()
    {
        painelPause.SetActive(false);
        Player.instancia.podeMover = true;
    }
    public void SairJogo()
    {
        SceneManager.LoadScene(Menu);
    }
}
