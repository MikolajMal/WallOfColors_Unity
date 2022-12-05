using UnityEngine;

public class BoardRotator : MonoBehaviour
{
    public void RotateBoard(int degrees)
    {
        transform.Rotate(0,0,degrees);
    }
}
