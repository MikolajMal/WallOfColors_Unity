using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class BlockShooter : MonoBehaviour
{
    bool blockClicked;
    Collider2D blockCollider;
    float speed = 20f;
    float checkingRayLength = .6f;
    Block blockScript;
    Color currentColor;

    int newBlocksInMatchingList = 0;

    public WallOfColorsSetup wallOfColorsSetupScript;

    void Start()
    {
        blockClicked = false;

        blockCollider = GetComponent<Collider2D>();
        blockScript = GetComponent<Block>();
        blockScript.isMarkedAsMatching = true;
        currentColor = blockScript.color;

        blockCollider.enabled = true;
    }


    void Update()
    {
        if (blockClicked)
        {
            GameManager.Instance.actionsNotBlocked = false;

            transform.Translate(Vector3.up * Time.deltaTime * speed);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, checkingRayLength);
            if (hit)
            {
                if (hit.transform.CompareTag("StaticBlock"))
                {
                    BlockSetting(hit);

                    GameManager.Instance.actionsNotBlocked = true;

                    CheckingForMatches();
                }
            }
        }
    }

    /// <summary>
    /// Checking if near blocks have the same color
    /// </summary>
    void CheckingForMatches()
    {
        // Searching matching blocks around shooted block
        List<Block> matchingBlocks = new List<Block>();
        CheckAllDirections(transform.position, matchingBlocks);
        int matchingBlocksCount = matchingBlocks.Count;

        // Searching for further matching blocks
        while (newBlocksInMatchingList != 0)
        {
            newBlocksInMatchingList = 0;
            matchingBlocksCount = matchingBlocks.Count;

            for (int i = 0; i < matchingBlocksCount; i++)
            {
                Collider2D currentBlockCollider = matchingBlocks[i].GetComponent<Collider2D>();

                currentBlockCollider.enabled = false;
                CheckAllDirections(matchingBlocks[i].transform.position, matchingBlocks);
                currentBlockCollider.enabled = true;
            }
        }

        // Checking if there are more then one matching block to the shooted block
        if (matchingBlocksCount > 1)
        {
            for (int i = matchingBlocksCount - 1; i >= 0; i--)
            {
                GameObject block = matchingBlocks[i].gameObject;
                matchingBlocks.RemoveAt(i);
                Destroy(block);
            }

            // Update preview path when blocks are destroyed
            BlockPathPreview.Instance.ShowPathPreview(this.gameObject);

            CalculateScore(matchingBlocksCount);

            Destroy(this.gameObject);
            return;
        }
        else
        {
            for (int i = 0; i < matchingBlocksCount; i++)
            {
                matchingBlocks[i].isMarkedAsMatching = false;
            }
        }

        blockCollider.enabled = true;
        blockScript.isMarkedAsMatching = false;
    }

    void CalculateScore(int matchingBlocksCount)
    {
        int newScore = (matchingBlocksCount * matchingBlocksCount) - 1;
        GameManager.Instance.Score += newScore;
    }

    /// <summary>
    /// Checking for matching blocks in all directions
    /// </summary>
    /// <param name="checkingPosition">List of matching blocks</param>
    /// <param name="matchingBlocks">Position of block for which matches are currently being checked</param>
    void CheckAllDirections(Vector3 checkingPosition, List<Block> matchingBlocks)
    {
        CheckDirection(checkingPosition, Vector3.up, matchingBlocks);
        CheckDirection(checkingPosition, Vector3.down, matchingBlocks);
        CheckDirection(checkingPosition, Vector3.left, matchingBlocks);
        CheckDirection(checkingPosition, Vector3.right, matchingBlocks);
    }

    void CheckDirection(Vector3 checkingPosition, Vector3 direction, List<Block> matchingBlocks)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkingPosition, direction, checkingRayLength);
        if (hit)
        {
            Block block = hit.transform.GetComponent<Block>();
            Color colorTarget = block.color;
            if ((colorTarget == currentColor) && !block.isMarkedAsMatching)
            {
                matchingBlocks.Add(block);
                newBlocksInMatchingList++;
                block.isMarkedAsMatching = true;
            }
        }
    }

    void BlockSetting(RaycastHit2D hit)
    {
        int height = Mathf.RoundToInt(transform.position.x);
        int width = Mathf.RoundToInt(transform.position.y);
        transform.position = new Vector3(height, width);
        //blockCollider.enabled = true;
        this.tag = "StaticBlock";
        transform.parent = hit.transform.parent;
        Destroy(this);
    }

    private void OnMouseDown()
    {
        if (blockClicked || !GameManager.Instance.actionsNotBlocked) return;

        blockCollider.enabled = false;

        RaycastHit2D hitNear = Physics2D.Raycast(transform.position, Vector3.up, .6f);
        RaycastHit2D hitFar = Physics2D.Raycast(transform.position, Vector3.up);

        if (hitNear) blockCollider.enabled = true;
        else if (!hitFar) blockCollider.enabled = true;
        else if (!hitNear && hitFar && wallOfColorsSetupScript != null)
        {
            blockClicked = true;
            wallOfColorsSetupScript.UpdateColumn(this.gameObject);
        }
    }

    private void OnMouseEnter()
    {
        BlockPathPreview.Instance.ShowPathPreview(this.gameObject);
    }

    private void OnMouseExit()
    {
        BlockPathPreview.Instance.HidePathPreview(this.gameObject);
    }
}
