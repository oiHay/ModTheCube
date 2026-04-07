using System;
using TMPro;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _debugText;
    [SerializeField] private Cube _cube; // Arraste o objeto no Inspector

    private void Update()
    {
        if (_cube == null || _debugText == null) return;

        _debugText.text =
            $"Position: {_cube.Position}\n\n" +
            $"Scale: {_cube.Scale:F2}\n\n" +
            $"Rotation Speed: {_cube.RotationSpeed}\n\n" +
            $"Current Color: {_cube.CurrentColor}";
            // \n quebra a linha para a debaixo
    }
}
