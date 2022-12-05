using UnityEngine;

public class Block : MonoBehaviour
{
    public Color color { get; private set; }
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GameManager.currentColors[Random.Range(0, GameManager.currentColors.Count)];
    }
}
