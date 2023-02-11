using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerBehaviour
{
    public abstract class ClickBehaviour : MonoBehaviour
    {
        [SerializeField] private InputAction mouseClickAction;

        private Camera mainCamera;
        private Coroutine coroutine;
        private Vector3 targetPosition;

        [HideInInspector]
        public int HitLayer;

        protected virtual void Awake()
        {
            mainCamera = Camera.main;
            HitLayer = LayerMask.NameToLayer("Default");
        }

        protected virtual void OnEnable()
        {
            mouseClickAction.Enable();
            mouseClickAction.performed += ClickAction;
        }

        protected virtual void OnDisable()
        {
            mouseClickAction.performed -= ClickAction;
            mouseClickAction.Disable();
        }

        private void ClickAction(InputAction.CallbackContext context)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit) &&
                hit.collider &&
                hit.collider.gameObject.layer.CompareTo(HitLayer) == 0 &&
                !IsPointerOverUIElement())
            {
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                coroutine = StartCoroutine(ClickActionCallback(hit.collider.gameObject, hit.point));
                targetPosition = hit.point;
            }
        }

        public abstract IEnumerator ClickActionCallback(GameObject targetObject, Vector3 targetPosition);

        private static bool IsPointerOverUIElement()
        {
            return IsPointerOverUIElement(GetEventSystemRaycastResults());
        }

        private static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
        {
            for (int index = 0; index < eventSystemRaysastResults.Count; index++)
            {
                RaycastResult curRaysastResult = eventSystemRaysastResults[index];
                if (curRaysastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
                    return true;
            }
            return false;
        }

        private static List<RaycastResult> GetEventSystemRaycastResults()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> raysastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raysastResults);
            return raysastResults;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(targetPosition, 1);
        }
    }
}