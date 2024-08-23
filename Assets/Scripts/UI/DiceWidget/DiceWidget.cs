using TMPro;
using UnityEngine;

public class DiceWidget : MonoBehaviour
{
    private int _diceMaxValue = 6;
    [SerializeField] private TMP_InputField _firstInputField;
    [SerializeField] private TMP_InputField _secondInputField;

    private void Start()
    {
        _firstInputField.onEndEdit.AddListener(OnFirstFieldEndEdit);
        _secondInputField.onEndEdit.AddListener(OnSecondFieldEndEdit);
        GameManager.Instance.OnMovementCompleted += OnMovementCompleted;
    }

    private void OnDestroy()
    {
        _firstInputField.onEndEdit.RemoveListener(OnFirstFieldEndEdit);
        _secondInputField.onEndEdit.RemoveListener(OnSecondFieldEndEdit);
    }

    private void OnMovementCompleted()
    {
        ActivateInputFields();
    }

    private void OnFirstFieldEndEdit(string firstStr)
    {
        if(!TryChangeData(firstStr))
        {
            Debug.Log("Empty field, field value 0 or greater than max value");
            return;
        }
        int.TryParse(firstStr, out int parseValue);
        GameManager.Instance.DiceDatas.FirstData = parseValue;
        GameManager.Instance.DiceDatas.FirstDataSet = true;
        GameManager.Instance.DiceDataList.Add(parseValue);

        if(TryDeactivateFields())
        {
            DeactivateInputFields();
        }
        Debug.Log("First Dice Value: " + parseValue);
    }

    private void OnSecondFieldEndEdit(string secondStr)
    {
        if(!TryChangeData(secondStr))
        {
            Debug.Log("Empty field, field value 0 or greater than max value");
            return;
        }
        int.TryParse(secondStr, out int parseValue);
        GameManager.Instance.DiceDatas.SecondData = parseValue;
        GameManager.Instance.DiceDatas.SecondDataSet = true;
        GameManager.Instance.DiceDataList.Add(parseValue);

        if(TryDeactivateFields())
        {
            DeactivateInputFields();
        }
        Debug.Log("Second Dice Value: " + parseValue);
    }

    private bool TryDeactivateFields()
    {
        if(GameManager.Instance.DiceDatas.FirstDataSet && GameManager.Instance.DiceDatas.SecondDataSet)
        {
            return true;
        }
        return false;
    }

    private void DeactivateInputFields()
    {
        _firstInputField.interactable = false;
        _secondInputField.interactable = false;
        GameManager.Instance.DiceDatas.TotalData = GameManager.Instance.DiceDatas.FirstData + GameManager.Instance.DiceDatas.SecondData;
        GameManager.Instance.OnDiceDataSet?.Invoke();
    }

    private void ActivateInputFields()
    {
        _firstInputField.text = string.Empty;
        _secondInputField.text = string.Empty;
        GameManager.Instance.ResetDiceData();
        _firstInputField.interactable = true;
        _secondInputField.interactable = true;

    }

    private bool TryChangeData(string diceString)
    {
        if(string.IsNullOrWhiteSpace(diceString) || (int.TryParse(diceString, out int result) && Mathf.Approximately(result, 0f)) || result > _diceMaxValue)
        {
            Debug.Log("Empty field, field value 0 or greater than max value");
            return false;
        }
        return true;
    }
}
