using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBackgroundFrameSetup : MonoBehaviour
{
    [SerializeField]
    GameObject gridFramePrefab;
    void Start()
    {
        for (int i = -GameManager.Instance.levelSize; i <= GameManager.Instance.levelSize; i++)
        {
            for (int j = -GameManager.Instance.levelSize; j <= GameManager.Instance.levelSize; j++)
            {
                GameObject gridTile = Instantiate(gridFramePrefab, transform);
                gridTile.transform.position =  new Vector3(i,j,0);
            }
        }
    }
}
