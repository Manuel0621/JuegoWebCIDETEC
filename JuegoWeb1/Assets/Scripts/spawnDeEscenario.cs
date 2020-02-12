using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDeEscenario : MonoBehaviour
{
    public GameObject Escenario1;
    public GameObject Escenario2;
    public GameObject Escenario3;
    public GameObject Escenario4;
    public GameObject Escenario5;
    public GameObject Escenario6;
    private int EscenarioAPoner;
    public GameObject PuntoSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            PonerSecciones();
        }
    }
    private void PonerSecciones()
    {
        int x = 0;
        for (int i = 0; i < 6; i++)
        {
            GameObject nuevaPlataforma;
            EscenarioAPoner = Random.Range(0,7);

            switch (EscenarioAPoner)
            {
                case 0:
                    nuevaPlataforma = Instantiate(Escenario1);
                    nuevaPlataforma.transform.position = PuntoSpawn.transform.position - new Vector3(x: x, y: 1.5f, z: 0);
                    //x = x+6;
                    break;
                case 1:
                    nuevaPlataforma = Instantiate(Escenario2);
                    nuevaPlataforma.transform.position = PuntoSpawn.transform.position - new Vector3(x: x, y: 1.5f, z: 0);
                    //x= x+6;
                    break;
                case 2:
                    nuevaPlataforma = Instantiate(Escenario3);
                    nuevaPlataforma.transform.position = transform.position + new Vector3(x: x, y: -1.5f, z: 0);
                   //x -= 6;
                    break;
                case 3:
                    nuevaPlataforma = Instantiate(Escenario4);
                    nuevaPlataforma.transform.position = transform.position + new Vector3(x: x, y: -1.5f, z: 0);
                   // x -= 6;
                    break;
                case 4:
                    nuevaPlataforma = Instantiate(Escenario5);
                    nuevaPlataforma.transform.position = transform.position + new Vector3(x: x, y: -1.5f, z: 0);
                   // x -= 6;
                    break;
                case 5:
                    nuevaPlataforma = Instantiate(Escenario6);
                    nuevaPlataforma.transform.position = transform.position + new Vector3(x: x, y: -1.5f, z: 0);
                    //x -= 6;
                    break;
                default:
                    nuevaPlataforma = Instantiate(Escenario1);
                    nuevaPlataforma.transform.position = PuntoSpawn.transform.position - new Vector3(x: x, y: 1.5f, z: 0);
                    //x =x+6;
                    break;
            }
        }
    }
}
