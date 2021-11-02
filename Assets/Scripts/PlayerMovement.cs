using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // otetaan yhteys characterControlleriin. Nimi voisi olla myös cController
    public CharacterController controller;
    
    // kuinka nopeasti haluamme liikkua
    public float moveSpeed = 8f;
    
    // emme käytä rigidbodya (niin kuin 2D pelissä), joudutaan itse tekemään oma gravitaatio, eli millä voimalla liikutaan ylös ja alas.
    // arvoa voi itse muuttaa ja muokata.
    // unityn editori ylikirjoittaa koodin, joten ei kannata muokkailla täällä koodi puolella.
    public float gravity = -9.81f;
    
    //hyppy korkeus
    public float jumpHeight = 3f;

    // ollaanko maassa vai ei?
    // peli objekti joka laitetaan pelaajan jalkojen kohdalle. Tekee pisteen.
    // Transformilla koska editorin puolella pystyy säätää helpommin.
    public Transform groundCheck;

    // halkaisija. Kuinka isolla alueella ollaan maassa. Tekee viivan pisteestä.
    // blenderistä tuotuja grafiikoita voi olla aika "jänniä" kun tuodaan unityyn.
    public float groundDistance = 0.4f;
    
    // määritetään mitkä kaikki tasot lasketaan maaksi
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;  //on tosi kun on maassa.

    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tarkistetaan onko objekti maassa
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
                                        // = paikka       = Distancen kokoinen ympyrä  = gMaski
                                        // -> Jos osuu mihinkään ground layeriin niin ollaan maassa.
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        move = transform.right * xAxis + transform.forward * zAxis;
        
        // yhteys controlleriin, jolloin saadaan liikutettua objektia unityn puolella.
        controller.Move(move * moveSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    
    }

    //debugataan työkalu/objekti GroundCheck -objekti
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
                            // =tarkistaa paikan     = piirtää siihen Distance kokoisen ympyrän
    }
}
