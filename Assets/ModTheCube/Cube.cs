using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MeshRenderer _renderer;

    [Header("Position Range")]
    [SerializeField] private Vector2 _xPosRange = new Vector2(-5f, 5f);
    [SerializeField] private Vector2 _yPosRange = new Vector2(-5f, 5f);
    [SerializeField] private Vector2 _zPosRange = new Vector2(-5f, 5f);

    [Header("Scale Range")]
    [SerializeField] private Vector2 _scaleRange = new Vector2(0.2f, 4f);

    [Header("Color")]
    [SerializeField] private Vector2 _alphaRange = new Vector2(0.2f,1.0f);
    [SerializeField] private float _colorSpeed;
    [SerializeField] private float _startHue;
    [SerializeField] private float _fixedAlpha;

    // Propriedades públicas de leitura (encapsulamento)
    public Vector3 Position { get; private set; }
    public float Scale { get; private set; }
    public Vector3 RotationSpeed { get; private set; }
    public Color CurrentColor { get; private set; }

    private Material _material;

    private void Awake()
    {
        // Awake é melhor para inicializar dependências internas
        if (_renderer == null)
            _renderer = GetComponent<MeshRenderer>();

        _material = _renderer.material;
    }

    private void Start()
    {
        InitializeRandomParameters();

        _startHue = Random.Range(0f, 1f);
        _fixedAlpha = Random.Range(_alphaRange.x, _alphaRange.y);
        _colorSpeed = Random.Range(0.001f, 2f);
    }

    private void Update()
    {
        UpdateColor();
        
        transform.Rotate(RotationSpeed * Time.deltaTime);
    }

    private void InitializeRandomParameters()
    {
        Position = new Vector3(
            Random.Range(_xPosRange.x, _xPosRange.y),
            Random.Range(_yPosRange.x, _yPosRange.y),
            Random.Range(_zPosRange.x, _zPosRange.y)
        );

        Scale = Random.Range(_scaleRange.x, _scaleRange.y);

        RotationSpeed = new Vector3(
            Random.Range(0, 181),
            Random.Range(0, 181),
            Random.Range(0, 181)
        );

        transform.position = Position;
        transform.localScale = Vector3.one * Scale;
    }

    private void UpdateColor()
    {
        float hue = Mathf.Repeat(_startHue+ Time.time * _colorSpeed, 1f);
        Color rgb = Color.HSVToRGB(hue, 1f, 1f);
        CurrentColor = new Color(rgb.r, rgb.g, rgb.b, _fixedAlpha);
        _material.color = CurrentColor;
    }
}
