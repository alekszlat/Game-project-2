using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerUtil 
{
    private float currentTime;
    private List<Sprite> animations = new List<Sprite>();
    private int speed;
    private int currentSpriteIndex;

    public AnimationControllerUtil(List<Sprite>animationSheet=null,int speed=6)
    {
        currentSpriteIndex = 0;
        currentTime = 0;
        animations = animationSheet;
        this.speed = speed;   
    }
    public void UpdateAnimationController(float currentTime)
    {
        if (!HasSprites()) return;
        this.currentTime += currentTime;
        currentSpriteIndex=(int)(this.currentTime * speed) % animations.Count;      
    }
    public void SwtichSpriteSheet(List<Sprite> animationSheet,int speed=6)
    {
        if (!HasSprites()) return;
        currentTime = 0;
        animations = animationSheet;
    }
    public void SetTime(int speed)
    {
        this.speed = speed;
    }
    public Sprite GetSprite()
    {
        return animations[currentSpriteIndex];   
    }
    public bool HasSprites()
    {
        return animations != null && animations.Count > 0;
    }
}
