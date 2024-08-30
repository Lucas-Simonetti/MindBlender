using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu instancia;

    [SerializeField] private string Jogo;
    [SerializeField] public GameObject painelMenuInicial;
    [SerializeField] public GameObject painelConfigurations;
    [SerializeField] public GameObject painelCreditos;
    [SerializeField] public GameObject painelKnowMore;

    [Header("Objeto de Música")]
    public AudioSource caixaDeMusica;
    public AudioSource caixaDeEfeitos;

    [Header("Arquivos de Música")]
    public AudioClip musicaMenu;

    [Header("Arquivos de Efeitos Sonoros")]
    public AudioClip apertoBotao;

    [Header("Sliders")]
    public Slider sliderMusic;
    public Slider sliderEffects;
    public float valorSliderMusic;
    public float valorSliderEffects;

    private void Awake()
    {
        instancia = this;
    }

    private void Start()
    {
        caixaDeMusica.clip = musicaMenu;
        caixaDeMusica.Play();
        painelMenuInicial.SetActive(true);
        painelConfigurations.SetActive(false);
        painelCreditos.SetActive(false);
        painelKnowMore.SetActive(false);
    }

    private void Update()
    {
        caixaDeMusica.volume = sliderMusic.value;
        caixaDeEfeitos.volume = sliderEffects.value;

        valorSliderMusic = sliderMusic.value;
        valorSliderEffects = sliderEffects.value;
    }

    public void ApertarBotao()
    {
        caixaDeEfeitos.PlayOneShot(apertoBotao);
    }

    public void Jogar()
    {
        SceneManager.LoadScene(Jogo);
    }
    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelConfigurations.SetActive(true);
    }
    public void FecharOpcoes()
    {
        painelConfigurations.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void AbrirCreditos()
    {
        painelMenuInicial.SetActive(false);
        painelCreditos.SetActive(true);
    }
    public void FecharCreditos()
    {
        painelCreditos.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void AbrirPesquisa()
    {
        painelMenuInicial.SetActive(false);
        painelKnowMore.SetActive(true);
    }
    public void FecharPesquisa()
    {
        painelKnowMore.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
}
