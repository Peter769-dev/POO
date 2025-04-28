using UnityEngine;

public class Wizard_move : MonoBehaviour
{
    [SerializeField]private float speed = 3f; // Identifico CharacterController
    private Rigidbody2D playerRB;
    private Vector2 moveInput;


    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");                       // Lee eje Horizontal
        float movey  = Input.GetAxis("Vertical");
        moveInput = new Vector2(movex, movey).normalized;
    }
    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position+moveInput*speed*Time.fixedDeltaTime);
    }
}
