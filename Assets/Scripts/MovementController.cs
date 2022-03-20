using UnityEngine;

public class MovementController : MonoBehaviour {
    [SerializeField] private float _movementSpeed = 3.0f;
    private Vector2 _movement = new Vector2();
    private Animator _anim;
    private string _animationState = "AnimationState";
    private Rigidbody2D _rb;

    enum CharStates {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,

        idleSouth = 5
    }

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

    private void UpdateState() {
        if (_movement.x > 0) {
            _anim.SetInteger(_animationState, (int)CharStates.walkEast);
        }
        else if (_movement.x < 0) {
            _anim.SetInteger(_animationState, (int)CharStates.walkWest);
        }
        else if (_movement.y > 0) {
            _anim.SetInteger(_animationState, (int)CharStates.walkNorth);
        }
        else if (_movement.y < 0) {
            _anim.SetInteger(_animationState, (int)CharStates.walkSouth);
        }
        else {
            _anim.SetInteger(_animationState, (int)CharStates.idleSouth);
        }
    }
}