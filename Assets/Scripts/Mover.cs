using UnityEngine;

public class Mover : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private PlayerStats _stats;
    private Vector3 _moveVector;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveVector = new Vector3();
        _stats = GetComponent<PlayerStats>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {
        _moveVector.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _rigidbody.MovePosition(transform.position + _moveVector * Time.deltaTime * _stats.MoveSpeed);
        _animator.SetFloat("Blend", Input.GetAxis("Vertical") * _stats.MoveSpeed);
    }
}
