using Assets.Scripts;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private PlayerStats _stats;
    private Animator _animator;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _stats = Container.Instance.PlayerStats;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            Vector3 forward = Input.GetAxisRaw("Vertical") < 0 ? -transform.forward / 2 : transform.forward;
            _rigidbody.MovePosition(_rigidbody.transform.position + forward * _stats.MoveSpeed * Time.deltaTime);
            VerticalAnimationPlay();
        }

         if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector3 sidewalk = Input.GetAxisRaw("Horizontal") < 0 ? -transform.right : transform.right;
            _rigidbody.MovePosition(_rigidbody.transform.position + sidewalk * _stats.MoveSpeed * Time.deltaTime);
            HorizontalAnimationPlay();
        }
    }

    void VerticalAnimationPlay()
    {
        _animator.SetFloat("SideWalkSpeed", 0);
        _animator.SetFloat("Blend", Input.GetAxisRaw("Vertical") * _stats.MoveSpeed);
    }

    void HorizontalAnimationPlay()
    {
        _animator.SetFloat("SideWalkSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));
        _animator.SetFloat("Blend", Input.GetAxis("Horizontal") * _stats.MoveSpeed);
    }
}