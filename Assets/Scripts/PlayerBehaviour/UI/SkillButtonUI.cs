using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SkillButtonUI : MonoBehaviour
{
    [SerializeField] private Sprite _skillIcon;
    [SerializeField] private TextMeshProUGUI _timeRemainingText;

    //Temporary stuff
    [SerializeField] private float _skillCoolDown;
    [SerializeField] private string _skillName;

    private Button _button;
    private ShootSkill _shootSkill;

    private void Awake()
    {
        _shootSkill = FindObjectOfType<ShootSkill>();
        _button = GetComponent<Button>();
        GetComponent<Image>().sprite = _skillIcon;
        _timeRemainingText.gameObject.SetActive(false);
        _button.onClick.AddListener(SkillListener);
    }

    private void SkillListener()
    {
        _shootSkill.Shoot();
        _button.interactable = false;
        _timeRemainingText.gameObject.SetActive(true);
        StartCoroutine(WaitForCoolDown());
    }

    private IEnumerator WaitForCoolDown()
    {
        float timeRemaining = _skillCoolDown - 1;
        _timeRemainingText.text = timeRemaining.ToString();

        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeRemaining--;
            _timeRemainingText.text = timeRemaining.ToString();
        }
        _button.interactable = true;
        _timeRemainingText.gameObject.SetActive(false);
    }
}
