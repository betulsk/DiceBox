using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceData", menuName = "Create/Dice Data")]
public class DiceDataSO : ScriptableObject
{
    public List<DiceFaceRotation> FaceRotations;

    [System.Serializable]
    public struct DiceFaceRotation
    {
        public DiceFaces value;
        public List<Vector3> RelativeRotations;
    }
}

public enum DiceFaces
{
    One,
    Two, 
    Three,
    Four,
    Five,
    Six,
    None
}
