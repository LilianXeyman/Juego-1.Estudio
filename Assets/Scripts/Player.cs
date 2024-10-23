using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float movimientoX;

    [SerializeField]
    public float movimientoY;

    [SerializeField]
    public float movimientoZ;

    [SerializeField]
    public float velJugador;

    public AudioClip coinSFX;

    [SerializeField]
    GameObject puerta;

    [SerializeField]
    GameObject popUp;

    [SerializeField]
    GameObject popUpMuerte;

    [SerializeField]
    TextMeshProUGUI textTiempo;

    [SerializeField]
    TextMeshProUGUI textMuertes;

    [SerializeField]
    TextMeshProUGUI textVidas;

    [SerializeField]
    TextMeshProUGUI textMonedas;

    [SerializeField]
    TextMeshProUGUI textMuertes2;

    [SerializeField]
    TextMeshProUGUI textVidas2;

    [SerializeField]
    TextMeshProUGUI textMonedas2;

    [SerializeField]
    TextMeshProUGUI textTiempo2;

    [SerializeField]
    Material material1;

    [SerializeField]
    Material material2;

    [SerializeField]
    LeanTweenType animeCurve;

    int cuentaMonedas = 0;
    float tiempo = 0;
    int cuentaMuertes = 0;
    int cuentaVidas = 5;
    float minutos = 0;
    float segundos = 0;
    float posicionFinal = 0f;

    [SerializeField]
    float tiempoAnimacion = 2f;

    bool estaJugando = true;
    public Transform destinoFinal;

    void Start()
    { 
        popUp.SetActive(false);
        popUpMuerte.SetActive(false);
    }
    void Update()
    {
        if (estaJugando==true)
        { 
           movimientoX = Input.GetAxis("Horizontal") * Time.deltaTime * velJugador;
           movimientoZ = Input.GetAxis("Vertical") * Time.deltaTime * velJugador;
           transform.Translate(movimientoX, movimientoY, movimientoZ); //Tienes que poner esto para que se realice la transformacion en el espacio
              if (Input.GetMouseButtonDown(0))
              {
              transform.Rotate(0, -90, 0);
              }
              if (Input.GetMouseButtonDown(1))
              {
              transform.Rotate(0, 90, 0);
              }
       
           tiempo = tiempo + Time.deltaTime;
           minutos = Mathf.Floor((tiempo%3600)/60);
           segundos = Mathf.Floor(tiempo%60);
           textTiempo2.text=minutos.ToString("00")+":"+segundos.ToString("00");
        }
        textMuertes2.text = cuentaMuertes.ToString();
        textVidas2.text = cuentaVidas.ToString();
        textMonedas2.text = cuentaMonedas.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            cuentaMonedas += 1;
            AudioSource.PlayClipAtPoint(coinSFX, transform.position);
        }
        if (other.CompareTag("Llave"))
        {
            puerta.SetActive(false);
        }
        if (other.CompareTag("Meta"))
        {
            popUp.SetActive(true);
            LeanTween.moveLocalY(popUp, -900f, 0f);
            LeanTween.moveLocalY(popUp, posicionFinal, tiempoAnimacion).setEase(animeCurve);
            estaJugando = false;
            textMonedas.text ="Monedas: " + cuentaMonedas.ToString();
            textMuertes.text ="Muertes: "+cuentaMuertes.ToString();
            textVidas.text ="Vidas: "+ cuentaVidas.ToString();
            textTiempo.text ="Tiempo: " + minutos.ToString("00") + ":" + segundos.ToString("00"); ;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Pared")
        {
            cuentaVidas -= 1;
        }
        if (cuentaVidas==0)
        {
            popUpMuerte.SetActive(true);
            estaJugando=false;
        }
        if (collision.gameObject.tag=="Enemigos")
        {
            cuentaMuertes += 1;
            transform.position=destinoFinal.position;
        }
    }
}
