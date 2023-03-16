using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 10;

    private Rigidbody _rigidBody;
    private GameObject _target;

    public void Init(GameObject target)
    {
        _target = target;
        StartCoroutine(MoveProjectile());
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private IEnumerator MoveProjectile()
    {
        while (true)
        {
            var direction = _target.transform.position - transform.position;
            //var pointingAt = transform.forward * -1;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), _rotationSpeed * Time.deltaTime);


            _rigidBody.velocity = _speed * Time.deltaTime * direction;
            yield return null;
        }
    }

}
