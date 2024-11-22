using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox1 : MonoBehaviour
{
    public GameObject objetoParaSumir;
    public GameObject objetoParaAparecer;
    public GameObject hitboxParaSumir;
    public GameObject ativarVolta;
    public bool camada;
    // Start is called before the first frame update
    public void MudarObjetos()
    {
        objetoParaSumir.SetActive(false);
        objetoParaAparecer.SetActive(true);
        ativarVolta.SetActive(true);
        if (camada)
        {
            Debug.Log("UIVHDSI89UGHSDAOHSDI");
            hitboxParaSumir.GetComponent<Paredes>().AtivarColisor();
            Player.instancia.VoltarCamada();
        }
        if (!camada)
        {

            hitboxParaSumir.GetComponent<Paredes>().DesativarColisor();
            Player.instancia.MudarCamada();
        }
        gameObject.SetActive(false);

    }
}
