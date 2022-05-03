using UnityEngine;

public class MovementController : MonoBehaviour {
    [SerializeField] private float _movementSpeed = 3.0f;
    private Vector2 _movement = new Vector2();
    private Animator _anim;
    private Rigidbody2D _rb;

    private void Start() {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        UpdateState();
    }

    void FixedUpdate() {
        MoveCharacter();
    }

    private void MoveCharacter() {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement.Normalize();
        _rb.velocity = _movement * _movementSpeed;
    }

    void UpdateState()
    {
        if (Mathf.Approximately(_movement.x, 0) &&
        Mathf.Approximately(_movement.y, 0))
        {
            _anim.SetBool("isWalking", false);
        }
        else
        {
            _anim.SetBool("isWalking", true);
        }
        _anim.SetFloat("xDir", _movement.x);
        _anim.SetFloat("yDir", _movement.y);
    }
}