using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovementBehaviour : MonoBehaviour
{
    public abstract void MoveCustomActions(List<BoardPiece> targetTransform);
}
