using UnityEngine;

public class BoardRotator : MonoBehaviour
{
    public void RotateBoard(int degrees)
    {
        if (GameManager.boardRotationAllowed)
        {
            transform.Rotate(0, 0, degrees);
        }
    }
}
