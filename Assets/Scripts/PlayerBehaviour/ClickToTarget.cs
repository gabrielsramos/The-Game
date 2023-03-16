using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerBehaviour
{
    public class ClickToTarget : ClickBehaviour
    {
        [SerializeField] private InputAction escInputAction;

        [HideInInspector]
        public GameObject Target;

        protected override void Awake()
        {
            base.Awake();
            HitLayer = LayerMask.NameToLayer("Enemy");
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            escInputAction.Enable();
            escInputAction.performed += RemoveTarget;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            escInputAction.Disable();
            escInputAction.performed -= RemoveTarget;
        }

        public override IEnumerator ClickActionCallback(GameObject targetObject, Vector3 _)
        {
            Target = targetObject;
            yield return null;
        }

        private void RemoveTarget(InputAction.CallbackContext context)
        {
            Target = null;
        }
    }
}