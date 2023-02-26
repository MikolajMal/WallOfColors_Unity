using UnityEngine;

public class Block : MonoBehaviour
{
    public Color color { get; private set; }
    public bool isMarkedAsMatching = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = GameManager.Instance.currentColors[Random.Range(0, GameManager.Instance.currentColors.Count)];
        spriteRenderer.color = color;
    }
}
