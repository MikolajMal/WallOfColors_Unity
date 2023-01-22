using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockPathPreview : MonoBehaviour
{
    #region Singleton

    public static BlockPathPreview Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    #endregion

    public GameObject blockShadow;
    int startPosition;
    int maxShadowsAmount;

    List<GameObject> blocksShadows = new List<GameObject>();
    List<SpriteRenderer> blocksShadowsSprites = new List<SpriteRenderer>();

    void Start()
    {

        startPosition = GameManager.levelSize;

        transform.position = Vector3.down * startPosition;

        // Actual size of the level because GameManager.levelSize is the max size from the 0 including +/-GameManager.levelSize
        maxShadowsAmount = (GameManager.levelSize * 2) + 1;
        for (int i = 0; i < maxShadowsAmount; i++)
        {
            GameObject blockShadowInstantiated = Instantiate(blockShadow, transform.position + (Vector3.up * i), Quaternion.identity);
            blockShadowInstantiated.transform.parent= transform;
            blocksShadows.Add(blockShadowInstantiated);
            SpriteRenderer spriteRenderer = blockShadowInstantiated.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1, 1, 1, 0.2f);
            blocksShadowsSprites.Add(spriteRenderer);

            // TO DO: Overriding color of the selected block 
            Debug.Log(blockShadowInstantiated.GetComponent<SpriteRenderer>().color);
            // TO DO: At the beginning the path is not enabled

            // TO DO: Object pooling

        }

        SetVisability(false);
    }

    public void ShowPathPreview(GameObject selectedBlock)
    {
        transform.position = new Vector3(selectedBlock.transform.position.x, transform.position.y);
        SetVisability(true);
        Color selectedColor = selectedBlock.GetComponent<SpriteRenderer>().color;
        SetColor(selectedColor);
        // TO DO: Overriding color of the selected block 
    }

    public void HidePathPreview(GameObject selectedBlock)
    {
        SetVisability(false);
    }

    void SetVisability(bool setActive)
    {
        foreach (GameObject shadow in blocksShadows)
        {
            shadow.SetActive(setActive);
        }
    }

    void SetColor(Color color)
    {
        Color newColor = new Color(color.r, color.g, color.b, 0.3f);

        foreach (SpriteRenderer shadowRenderer in blocksShadowsSprites)
        {
            shadowRenderer.color= newColor;
        }
    }
}
