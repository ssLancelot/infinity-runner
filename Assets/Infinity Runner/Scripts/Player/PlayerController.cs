using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameData gameData;
    Rigidbody _rb;
    Animator _anim;
    [SerializeField] LayerMask _groundMask;

    bool _isJump;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        gameData._alive = true;
    }

    private void Update()
    {
        if (gameData._isRunning)
        {
            if (!gameData._alive) return;
            transform.Translate(Vector3.forward * Time.deltaTime * gameData._playerSpeed, Space.World);
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if (this.gameObject.transform.position.x > gameData._internaLeft)
                    transform.Translate(Vector3.left * Time.deltaTime * gameData._playerHorizontalSpeed);
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (this.gameObject.transform.position.x < gameData._internalRight)
                    transform.Translate(Vector3.right * Time.deltaTime * gameData._playerHorizontalSpeed);
            }

            if (Input.GetKeyDown(KeyCode.Space))
                _isJump = true;
        }

    }
    private void FixedUpdate()
    {
        if (_isJump && gameData._alive)
        {
            Jump();
            _isJump = false;
        }
    }
    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, _groundMask);

        if (isGrounded)
        {
            _rb.AddForce(Vector3.up * gameData._playerJumpForce);
            _anim.Play("Jump");
        }
    }

    public void Die()
    {
        gameData._alive = false;
        _anim.Play("Stumble Backwards");
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
