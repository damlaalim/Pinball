using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCenterController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private PointCenterType type;

    [SerializeField] private List<SpriteRenderer> spriteList;
    [SerializeField] private Animator animator;
    
    private static readonly int Square = Animator.StringToHash("square");
    private static readonly int Circle = Animator.StringToHash("circle");
    private static readonly int X = Animator.StringToHash("x");

    public void OnHit()
    {
        IEnumerator Do()
        {
            yield return ColorAnimation(.3f, ColorManager.Instance.GetCurrentColor());
            yield return ColorAnimation(.3f, Color.white);
        }

        StartCoroutine(Do());
        
        var animationIndex = 0;
        switch (type)
        {
            case PointCenterType.Square:
                animationIndex = Square;
                break;
            case PointCenterType.Circle:
                animationIndex = Circle;
                break;
            case PointCenterType.X:
                animationIndex = X;
                break;
        }
        animator.SetTrigger(animationIndex);
        
        GameManager.Instance.Score += score;
        
        AudioManager.Instance.Play(AudioType.Hit);
    }
    
    private IEnumerator ColorAnimation(float time, Color target)
    {
        float passed = 0;
        var init = spriteList[0].color;
        while (passed < time)
        {
            passed += Time.deltaTime;
            var current = Color.Lerp(init, target, passed / time);
            foreach (var item in spriteList)
                item.color = current;

            yield return null;
        }
    }
}

public enum PointCenterType
{
    Square,
    Circle,
    X
}