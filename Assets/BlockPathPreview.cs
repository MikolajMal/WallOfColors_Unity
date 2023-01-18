using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPathPreview : MonoBehaviour
{
    public GameObject blockShadow;
    int startPosition;
    int maxShadowsAmount;

    void Awake()
    {
        startPosition = GameManager.levelSize;

        transform.position = Vector3.down * startPosition;

        // Actual size of the level because GameManager.levelSize is the max size from the 0 including +/-GameManager.levelSize
        maxShadowsAmount = (GameManager.levelSize * 2) + 1;
        for (int i = 0; i < maxShadowsAmount; i++)
        {
            GameObject blockShadowInstantiated = Instantiate(blockShadow, transform.position + (Vector3.up * i), Quaternion.identity);
            blockShadowInstantiated.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);

            // TO DO: Overriding color of the selected block 
            Debug.Log(blockShadowInstantiated.GetComponent<SpriteRenderer>().color);
            // TO DO: At the beginning the path is not enabled

            // TO DO: Object pooling

        }
    }

    public static void ShowPathPreview(GameObject selectedBlock)
    {
        // TO DO: Overriding color of the selected block 
    }

    public static void HidePathPreview(GameObject selectedBlock)
    {

    }
}
