using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesDispayUpdater : TMPUpdater
{
    protected override void AdditionalOperationsInStart()
    {
        UpdateLivesDisplay();
        GameCore.Instance.LivesCountUpdated += UpdateLivesDisplay;
    }

    private void UpdateLivesDisplay()
    {
        var livesCount = GameCore.Instance.LivesCount;
        var activeObjects = 0;
        var totalChildren = 0;
        var spriteWidth = 0f;

        //check if we have enough active sprites for display
        foreach (Transform childTransform in transform)
        {
            if (childTransform.gameObject.activeSelf)
            {
                if (spriteWidth == 0) spriteWidth = (childTransform as RectTransform).rect.size.y;
                activeObjects++;
                totalChildren++;
            }
        }
        //activate more if needed
        if (activeObjects < livesCount)
        {
            foreach (Transform childTransform in transform)
            {
                if (!childTransform.gameObject.activeSelf)
                {
                    childTransform.gameObject.SetActive(true);
                    activeObjects++;
                    if (activeObjects == livesCount) break;
                }
            }
        }

        //deactivate if more than enough
        if (activeObjects > livesCount)
        {
            foreach (Transform childTransform in transform)
            {
                if (childTransform.gameObject.activeSelf)
                {
                    childTransform.gameObject.SetActive(false);
                    activeObjects--;
                    if (activeObjects == livesCount) break;
                }
            }
        }
        //need to add extra if there are not enough children
        { } //fine fore now

        
        //--Calculate space for sprites
        //Check is all sprites can fit in the rect
        var boxWidth = GetComponent<RectTransform>().rect.size.x;
        var widthRatio = boxWidth / (spriteWidth * activeObjects);
        Debug.Log("widthRatio = boxWidth / (spriteWidth * activeObjects) " + widthRatio + "=" + boxWidth + "/(+" + spriteWidth + "*" + activeObjects + ")");
        var startPoint = 0f;
        if (widthRatio <= 1)
        {
            //start right from left border
            startPoint = transform.position.x - boxWidth / 2 + spriteWidth / 2;
        }
        else
        {
            //all sprites can fit, normal filling
            widthRatio = 1;
            startPoint = transform.position.x - spriteWidth * activeObjects / 2 + spriteWidth / 2;
        }

        //place life sprites
        foreach (Transform childTransform in transform)
        {
            childTransform.position = new Vector3(startPoint, childTransform.position.y, childTransform.position.z);
            startPoint += spriteWidth * widthRatio;
        }
        
    }
}
