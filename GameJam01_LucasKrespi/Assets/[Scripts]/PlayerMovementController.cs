using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
    public Animator playerAnimator;

    private Vector2 inputVector2;

    private Vector3 moveDirection;
    private Rigidbody rigidbody;
    
    public float jumpForce;

    public float Speed;


    public int Score;

    public Canvas pauseCanvas;

    private readonly int MovementXHash = Animator.StringToHash("MovementX");
    private readonly int MovementYHash = Animator.StringToHash("MovementY");
    private readonly int OnJumpHash = Animator.StringToHash("Jump");

    private Vector3 initialPos;
    public int life = 3;

    public PhaseStarter currentPhase;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        pauseCanvas.gameObject.SetActive(false);

        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool(OnJumpHash)) return;

        if (!(inputVector2.magnitude > 0)) moveDirection = Vector3.zero;

        moveDirection = transform.forward * inputVector2.y /*+ transform.right * inputVector2.x*/;

        Vector3 movementDirection = moveDirection * (Speed * Time.deltaTime);

        transform.position += movementDirection;

        transform.Rotate(new Vector3(0.0f, inputVector2.x * 100 * Time.deltaTime, 0.0f));

        if(life <= 0)
        {
            PlayerPrefs.SetInt("Score", Score);
            PlayerPrefs.SetString("Message", "You lost all 3 lives rip");

            SceneManager.LoadScene("GameOver");
        }

    }
    public void OnMovement(InputValue valeu)
    {
        inputVector2 = valeu.Get<Vector2>();

        playerAnimator.SetFloat(MovementXHash, inputVector2.x);
        playerAnimator.SetFloat(MovementYHash, inputVector2.y);

    }

    public void OnJump(InputValue valeu)
    {
        if (playerAnimator.GetBool(OnJumpHash)) return;

        rigidbody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);

        playerAnimator.SetBool(OnJumpHash, true);
    }

    public void OnPause(InputValue valeu)
    {
        Time.timeScale = 0.0f;

        pauseCanvas.gameObject.SetActive(true);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.position = initialPos;
            life--;

            currentPhase.ResetWalls();
        }

        if (collision.gameObject.CompareTag("PhaseStarter"))
        {
            currentPhase = collision.gameObject.GetComponent<PhaseStarter>();

            initialPos = collision.transform.position;
        }

        playerAnimator.SetBool(OnJumpHash, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trophy"))
        {
            PlayerPrefs.SetInt("Score", Score);
            PlayerPrefs.SetString("Message", "YOU WIN");

            SceneManager.LoadScene("GameOver");

        }

        if (other.gameObject.CompareTag("Death"))
        {
            transform.position = initialPos;
            life--;

            currentPhase.ResetWalls();
        }
    }
}
