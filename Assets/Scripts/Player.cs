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

    int cuentaMonedas = 0;
    float tiempo = 0;
    int cuentaMuertes = 0;
    int cuentaVidas = 5;

    bool estaJugando = true;

    void Start()
    { 
        popUp.SetActive(false);
    }
    void Update()
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
        if (estaJugando==true)
        { 
           tiempo = tiempo + Time.deltaTime;
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
            textMonedas.text =cuentaMonedas.ToString();
            textMuertes.text =cuentaMuertes.ToString();
            textVidas.text =cuentaVidas.ToString();
            textTiempo.text =tiempo.ToString();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Pared")
        {
            cuentaVidas -= 1;
        }
        if (collision.gameObject.tag=="Enemigos")
        {
            cuentaMuertes += 1;
        }
    }
}
