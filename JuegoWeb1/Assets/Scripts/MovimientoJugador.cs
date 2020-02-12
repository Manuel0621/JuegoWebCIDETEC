using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class MovimientoJugador : MonoBehaviour
{

    private Rigidbody rb;
    public float velocidad;
    public float multiplicador;
    public bool iniciado;
    private float x;
    private bool moviendose;
    private bool presionado;
    private bool soltado;

    private void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidad = 0;
        iniciado = false;
        presionado = false;
        soltado = false;
    }
    void OnMessage(int fromDeviceID, JToken data)
    {
        Debug.Log("message from" + fromDeviceID + ", data:" + data);
        if (data["action"] != null && data["action"].ToString().Equals("presionado"))
        {
            presionado = true;
            soltado = false;
            //Camera.main.backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        if (data["action"] != null && data["action"].ToString().Equals("soltado"))
        {
            presionado = false;
            soltado = true;
            //Camera.main.backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (presionado==true)
        {
            if (velocidad < 85)
            {
                //print("up arrow key is held down");
                velocidad += 1;
                //rb.drag +=0.01f;
                print(velocidad);
            }
            
        }

    }
    private void FixedUpdate()
    {
        //moviendose = EnMovimiento();
        if (!EnMovimiento())
        {
            if (soltado==true)
            {
                Vector3 movimiento = new Vector3(-velocidad * multiplicador, 0.0f, 0.0f);
                rb.AddForce(movimiento);
                velocidad = 0;
                soltado = false;
                if (iniciado == false)
                {
                    iniciado = true;
                }
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CajaSpawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    bool EnMovimiento()
    {
            if (transform.position.x == x)
            {
                x = transform.position.x;
                return false;

            }
            else
            {
                x = transform.position.x;
                return true;
            }
    }


}
