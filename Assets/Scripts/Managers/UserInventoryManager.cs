using System.IO;
using UnityEngine;

public class UserInventoryManager : Singleton<UserInventoryManager>
{
    private string _filePath;

    [SerializeField] private UserInventoryTrackableData _userInventoryTrackableData;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _filePath = Path.Combine(Application.persistentDataPath, "UserInventoryData.json");

        if(!_userInventoryTrackableData.TryLoad(_filePath))
        {
            var itemTypes = GameConfigManager.Instance.GetItemTypes();
            for(int i = 0; i < itemTypes.Count; i++)
            {
                _userInventoryTrackableData.UpsertItemCountByType(itemTypes[i], 0, _filePath);
            }
        }
        else
        {

        }
    }

    public void UpdateInventoryData(EItemType itemType, int count)
    {
        _userInventoryTrackableData.UpdateInventoryData(itemType, count, _filePath);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            _userInventoryTrackableData.UpdateInventoryData(EItemType.Apple, 8, _filePath);
        }
    }
}
