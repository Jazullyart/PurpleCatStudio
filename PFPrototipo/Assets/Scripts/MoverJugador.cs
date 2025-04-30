using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJugador : MonoBehaviour
{
    //Variables
    public CharacterController controlador;
    public float velocidad = 10;
    public float gravedad = -30;
    public Vector3 direccionJugador;
    public bool tocandoPiso;
    public float salto = 20;

    // Start is called before the first frame update
    void Start()
    {
        //Crea y busca el componente CharacterController en el GameObject para asignarlo al controlador
        controlador = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mover = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controlador.Move(mover * velocidad * Time.deltaTime);

        if (mover != Vector3.zero)
        {
            gameObject.transform.forward = mover;
        }

        if (tocandoPiso == true && direccionJugador.y < 0)
        {
            direccionJugador.y = 0;
        }


        if (Input.GetButton("Jump") && tocandoPiso == true)
        {
            tocandoPiso = false;
            direccionJugador.y += salto;
        }

        direccionJugador.y += gravedad * Time.deltaTime;
        controlador.Move(direccionJugador * Time.deltaTime);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "piso")
        {
            tocandoPiso = true;
        }
    }

}
