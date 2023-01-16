using UnityEngine;

public class BoardRotator : MonoBehaviour
{
    public void RotateBoard(int degrees)
    {
        if (GameManager.actionsNotBlocked)
        {
            transform.Rotate(0, 0, degrees);
        }
    }
}
