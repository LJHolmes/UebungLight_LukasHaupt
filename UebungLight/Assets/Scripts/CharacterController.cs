using UnityEngine;

// Ihre Aufgabe
// Refaktorisieren Sie den obigen Code, um die folgenden Ziele zu erreichen:
// Verbessern Sie die Namensgebung von Variablen und Methoden, um sie aussagekräftiger und konsistent mit den Naming Conventions zu machen.
// Strukturieren Sie den Code neu, um eine klarere und besser lesbare Formatierung zu erreichen.
// Fügen Sie Kommentare hinzu, um die Funktionalität und den Zweck bestimmter Codeabschnitte zu erklären.


public class CharacterController : MonoBehaviour
{
    private Rigidbody Rigidbody;

    [SerializeField] private int health = 100;
    [SerializeField] private float speedValue = 5f;

    private bool isJumping;

    void Start()
    {
        // Get Rigidbody component
        Rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Check health stats
        HealthHandler();
        // Moves the Player
        MovementHandler();
        // Let player jump
        JumpHandler();
    }

    private void HealthHandler()
    {
        // If 0 HP - Game Over
        if (health <= 0)
        {
            Debug.Log("End Game");
        }
    }
    private void MovementHandler()
    {
        // Set Floats for movement
        float x = Input.GetAxis("Horizontal") * speedValue;
        float z = Input.GetAxis("Vertical") * speedValue;

        // Use X and Z to move to player
        transform.Translate(x * Time.deltaTime, 0, z * Time.deltaTime);
    }
    private void JumpHandler()
    {
        // If press space and isJumping == false - then isJumping == true
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
        }

        // Use force to jump and set IsJumping == false
        if (isJumping)
        {
            Rigidbody.AddForce(Vector3.up * 5f, ForceMode.VelocityChange);
            isJumping = false;
        }
    }
}
