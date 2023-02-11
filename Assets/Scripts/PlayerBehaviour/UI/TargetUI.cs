using Assets.Scripts.PlayerBehaviour;
using TMPro;
using UnityEngine;
using System.Collections;

public class TargetUI : MonoBehaviour
{
    [SerializeField] private GameObject infoPopup;
    [SerializeField] private TextMeshProUGUI targetText;

    private ClickToTarget clickToTarget;
    private Coroutine updateCoroutine;

    private const float UPDATE_TIME = 0.1f;


    private void Awake()
    {
        clickToTarget = FindObjectOfType<ClickToTarget>();
    }

    private void OnEnable()
    {
        updateCoroutine = StartCoroutine(UpdateTargetUI());
    }

    private void OnDisable()
    {
        StopCoroutine(updateCoroutine);
    }

    private IEnumerator UpdateTargetUI()
    {
        while (true)
        {
            if (clickToTarget.Target != null && !infoPopup.activeSelf)
            {
                infoPopup.SetActive(true);
                targetText.text = clickToTarget.Target.ToString();
            }
            else if (clickToTarget.Target == null && infoPopup.activeSelf)
            {
                infoPopup.SetActive(false);
            }
            yield return new WaitForSeconds(UPDATE_TIME);
        }
    }
}
