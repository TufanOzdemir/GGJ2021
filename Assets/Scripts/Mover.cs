using UnityEngine;

public class Mover : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private PlayerStats _stats;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _stats = GetComponent<PlayerStats>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical")!=0)
        {
            Vector3 forward = Input.GetAxisRaw("Vertical") < 0 ? -transform.forward/2 : transform.forward;
           
            _rigidbody.MovePosition( _rigidbody.transform.position + forward * _stats.MoveSpeed * Time.deltaTime);
        }

        _animator.SetFloat("Blend", Input.GetAxis("Vertical") * _stats.MoveSpeed);
    }
}
