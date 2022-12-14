using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockShooter : MonoBehaviour
{
    bool blockClicked;
    Collider2D blockCollider;

    // Start is called before the first frame update
    void Start()
    {
        blockClicked = false;
        blockCollider = GetComponent<Collider2D>();
        blockCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (blockClicked)
        {
            GameManager.boardRotationAllowed = false;

            transform.Translate(Vector3.up * Time.deltaTime);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, .5f);
            if (hit)
            {
                if (hit.transform.CompareTag("StaticBlock"))
                {
                    int height = Mathf.RoundToInt(transform.position.x);
                    int width = Mathf.RoundToInt(transform.position.y);
                    transform.position = new Vector3(height, width);
                    blockCollider.enabled = true;
                    this.tag = "StaticBlock";
                    transform.parent = hit.transform.parent;
                    GameManager.boardRotationAllowed = true;
                    Destroy(this);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (blockClicked) return;

        blockCollider.enabled = false;

        RaycastHit2D hitNear = Physics2D.Raycast(transform.position, Vector3.up, .6f);
        RaycastHit2D hitFar = Physics2D.Raycast(transform.position, Vector3.up);

        if (hitNear) blockCollider.enabled = true;
        else if (!hitFar) blockCollider.enabled = true;
        else if (!hitNear && hitFar) blockClicked = true;
    }
}
