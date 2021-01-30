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
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            float sidewalk = Input.GetAxisRaw("Horizontal") < 0 ? -1 : 1;
            float forward = Input.GetAxisRaw("Vertical") < 0 ? -1 / 2 : 1;
            transform.Translate(new Vector3(sidewalk, 0, forward) * Time.deltaTime * _stats.MoveSpeed, Space.Self);
            return;
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            Vector3 forward = Input.GetAxisRaw("Vertical") < 0 ? -transform.forward / 2 : transform.forward;
            _rigidbody.MovePosition(_rigidbody.transform.position + forward * _stats.MoveSpeed * Time.deltaTime);
            return;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector3 sidewalk = Input.GetAxisRaw("Horizontal") < 0 ? -transform.right : transform.right;
            _rigidbody.MovePosition(_rigidbody.transform.position + sidewalk * _stats.MoveSpeed * Time.deltaTime);
        }



    }
}
