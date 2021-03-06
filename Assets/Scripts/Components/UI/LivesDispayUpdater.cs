﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LivesDispayUpdater : TMPUpdater
{
    [SerializeField]
    private GameObject lifeSpritePrefab;

    private readonly static int maxSpritesAllowed = 30; 

    protected override void AdditionalOperationsInStart()
    {
        UpdateLivesDisplay();
        GameCore.Instance.LivesCountUpdated += UpdateLivesDisplay;
    }

    private void UpdateLivesDisplay()
    {
        var livesCount = GameCore.Instance.LivesCount;
        int activeSpriteObjects = 0;
        float spriteWidth = 0f;

        //check if we have enough active sprites for display
        foreach (RectTransform childTransform in transform)
        {
            if (childTransform.gameObject.activeSelf)
            {
                if (spriteWidth == 0)
                    spriteWidth = childTransform.rect.size.y * childTransform.localScale.y;
                activeSpriteObjects++;
            }
        }
        //activate more sprites if needed
        if (activeSpriteObjects < livesCount)
        {
            foreach (Transform childTransform in transform)
            {
                if (activeSpriteObjects == maxSpritesAllowed) break;
                if (!childTransform.gameObject.activeSelf)
                {
                    childTransform.gameObject.SetActive(true);
                    activeSpriteObjects++;
                    if (activeSpriteObjects == livesCount) break;
                }
            }

            //If there are not enough children add new one (to maxSpritesAllowed extense)
            while (activeSpriteObjects < maxSpritesAllowed && activeSpriteObjects < livesCount)
            {
                Instantiate(lifeSpritePrefab, transform.position, Quaternion.identity);
                activeSpriteObjects++;
            }
        }
        //deactivate if we have more than enough sprites 
        if (activeSpriteObjects > livesCount)
        {
            foreach (Transform childTransform in transform)
            {
                if (childTransform.gameObject.activeSelf)
                {
                    childTransform.gameObject.SetActive(false);
                    activeSpriteObjects--;
                    if (activeSpriteObjects == livesCount) break;
                }
            }
        }

        //--Calculate space for sprites
        //Check is all sprites can fit in the rect
        var rectTransform = GetComponent<RectTransform>();
        var rectWidth = rectTransform.rect.size.x * transform.localScale.x;
        var widthRatio = rectWidth / (spriteWidth * activeSpriteObjects);

        var startPoint = 0f;
        if (widthRatio <= 1) //All sprites cannot fit properly. They will share space
        {
            //start right from left border
            startPoint = rectTransform.anchoredPosition.x - rectWidth / 2 + spriteWidth / 2;
        }
        else //All sprites can fit, normal filling
        {
            widthRatio = 1;
            startPoint = rectTransform.anchoredPosition.x - spriteWidth * livesCount / 2 + spriteWidth / 2;
        }

        startPoint -= rectTransform.position.x;

        //place life sprites
        foreach (RectTransform childTransform in transform)
        {
            if (!childTransform.gameObject.activeSelf) continue;
            childTransform.anchoredPosition = new Vector2(startPoint, childTransform.anchoredPosition.y);
            startPoint += spriteWidth * widthRatio;
        }

    }
}
