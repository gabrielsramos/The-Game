using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SkillButtonUI : MonoBehaviour
{
    [SerializeField] private Sprite skillIcon;
    [SerializeField] private TextMeshProUGUI timeRemainingText;

    //Temporary stuff
    [SerializeField] private float skillCoolDown;
    [SerializeField] private string skillName;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        GetComponent<Image>().sprite = skillIcon;
        timeRemainingText.gameObject.SetActive(false);
        button.onClick.AddListener(SkillListener);
    }

    private void SkillListener()
    {
        button.interactable = false;
        timeRemainingText.gameObject.SetActive(true);
        StartCoroutine(WaitForCoolDown());
    }

    private IEnumerator WaitForCoolDown()
    {
        float timeRemaining = skillCoolDown - 1;
        timeRemainingText.text = timeRemaining.ToString();

        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeRemaining--;
            timeRemainingText.text = timeRemaining.ToString();
        }
        button.interactable = true;
        timeRemainingText.gameObject.SetActive(false);
    }
}
