using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PieceVisualController : MonoBehaviour
{
    [SerializeField] private Image _pieceItemImage;
    [SerializeField] private TMP_Text _pieceItemText;

    public void SetVisual(Image image, string text)
    {
        _pieceItemImage = image;
        _pieceItemText.text = text;
    }
}
