using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesDispayUpdater : TMPUpdater
{
    [SerializeField]
    private GameObject lifeSpritePrefab;

    private static int maxSpritesAllowed = 30;

    protected override void AdditionalOperationsInStart()
    {
        UpdateLivesDisplay();
        GameCore.Instance.LivesCountUpdated += UpdateLivesDisplay;
    }

    private void UpdateLivesDisplay()
    {
        var livesCount = GameCore.Instance.LivesCount;
        int activeObjects = 0;
        float spriteWidth = 0f;

        //check if we have enough active sprites for display
        foreach (RectTransform childTransform in transform)
        {
            if (childTransform.gameObject.activeSelf)
            {
                if (spriteWidth == 0)
                    spriteWidth = childTransform.rect.size.y * childTransform.localScale.y;
                activeObjects++;
            }
        }
        //activate more if needed
        if (activeObjects < livesCount)
        {
            foreach (Transform childTransform in transform)
            {
                if (activeObjects == maxSpritesAllowed) break;
                if (!childTransform.gameObject.activeSelf)
                {
                    childTransform.gameObject.SetActive(true);
                    activeObjects++;
                    if (activeObjects == livesCount) break;
                }
            }

            //If there are not enough children add new one (to maxSpritesAllowed extense)
            while (activeObjects < maxSpritesAllowed && activeObjects < livesCount)
            {
                Instantiate(lifeSpritePrefab, transform.position, Quaternion.identity);
                activeObjects++;
            }
        }
        //deactivate if we have more than enough sprites 
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

        //--Calculate space for sprites
        //Check is all sprites can fit in the rect
        var rectTransform = GetComponent<RectTransform>();
        var rectWidth = rectTransform.rect.size.x * transform.localScale.x;
        var widthRatio = rectWidth / (spriteWidth * activeObjects);
        //Debug.Log("widthRatio = boxWidth / (spriteWidth * activeObjects) " + widthRatio + "=" + boxWidth + "/(" + spriteWidth + "*" + activeObjects + ")");
        var startPoint = 0f;
        if (widthRatio <= 1)
        {
            //start right from left border
            startPoint = rectTransform.anchoredPosition.x - rectWidth / 2 + spriteWidth / 2;
            //Debug.Log("widthRation<=1: startPoint = transform.position.x - (boxWidth - spriteWidth) / 2; " + startPoint + "=" + transform.position.x + "-(" + rectWidth + "-" + spriteWidth + ")");
        }
        else
        {
            //all sprites can fit, normal filling
            widthRatio = 1;
            startPoint = rectTransform.anchoredPosition.x - spriteWidth * livesCount / 2 + spriteWidth / 2;
            //Debug.Log("widthRation>1: startPoint = rectTransform.anchoredPosition.x - spriteWidth * livesCount / 2 + spriteWidth/2;; " + startPoint + "=" + rectTransform.anchoredPosition.x + "-" + spriteWidth + "*" + livesCount + "/2+" + spriteWidth + "/2");
        }

        //place life sprites
        foreach (RectTransform childTransform in transform)
        {
            if (!childTransform.gameObject.activeSelf) continue;
            print(childTransform.gameObject.name);
            //childTransform.anchoredPosition = new Vector3(startPoint, childTransform.position.y, childTransform.position.z);
            childTransform.anchoredPosition = new Vector2(startPoint, childTransform.anchoredPosition.y);
            startPoint += spriteWidth * widthRatio;
            print("sp " + startPoint);
        }

        //! Next !
        //If there are more than some amount of lifes (7 for ex) change diplay - 
        //instead of regular squize all sprites show 1 spite and int text amount near
        //btw delete all over limit sprites
    }
}
