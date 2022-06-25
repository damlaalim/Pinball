using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get; private set; }

    [SerializeField] private List<Color> list;

    private int _currentIndex;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentIndex = Random.Range(0, list.Count);
    }

    public Color GetCurrentColor()
    {
        _currentIndex = Random.Range(0, list.Count);
        return list[_currentIndex];
    }
}