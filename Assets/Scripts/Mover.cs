using UnityEngine;

public class Mover : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private PlayerStats _stats;
    private Vector3 _moveVector;
    private Animator _animator;
    private CameraMovement asd;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveVector = new Vector3();
        _stats = GetComponent<PlayerStats>();
        _animator = GetComponent<Animator>();
        asd = GetComponentInChildren<CameraMovement>();
    }

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetAxisRaw("Vertical")>0)
        {
            _rigidbody.MovePosition( _rigidbody.transform.position + asd.transform.forward * _stats.MoveSpeed * Time.deltaTime);
        }

        //_moveVector.Set(Input.GetAxis("Horizontal"), 0,  Input.GetAxis("Vertical"));
        //_rigidbody.MovePosition(rigidbody.transform.forward  * Time.deltaTime * _stats.MoveSpeed);

        _animator.SetFloat("Blend", Input.GetAxis("Vertical") * _stats.MoveSpeed);
    }
}
