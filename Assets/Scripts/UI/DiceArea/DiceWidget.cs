using TMPro;
using UnityEngine;

public class DiceWidget : MonoBehaviour
{
    [SerializeField] private TMP_InputField _firstInputField;
    [SerializeField] private TMP_InputField _secondInputField;

    private void Start()
    {
        _firstInputField.onEndEdit.AddListener(OnFirstFieldEndEdit);
    }

    private void OnDestroy()
    {
        _firstInputField.onEndEdit.RemoveListener(OnFirstFieldEndEdit);

    }

    private void OnFirstFieldEndEdit(string arg0)
    {
        if(arg0 != null)
        {

            Debug.Log("! " + arg0);

        }
    }
}
