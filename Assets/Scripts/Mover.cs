using Assets.Scripts;
using UnityEngine;

public class Mover : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private PlayerStats _stats;
 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _stats = Container.Instance.PlayerStats;
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
    }
}
