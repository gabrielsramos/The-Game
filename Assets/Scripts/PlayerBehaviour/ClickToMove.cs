using Assets.Scripts.PlayerBehaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ClickToMove : ClickBehaviour
{
    [SerializeField] private float playerSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 3f;

    private Rigidbody rb;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        HitLayer = LayerMask.NameToLayer("Ground");
    }

    public override IEnumerator ClickActionCallback(GameObject _, Vector3 targetPosition)
    {
        float playerDistanceToFloor = transform.position.y - targetPosition.y;
        targetPosition.y += playerDistanceToFloor;
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            Vector3 direction = targetPosition - transform.position;
            rb.velocity = direction.normalized * playerSpeed;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
