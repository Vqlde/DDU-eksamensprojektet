using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRogue : MonoBehaviour
{
    public Color normalColor = Color.black;
    public Color glowColor = Color.white;
    private bool isHovered = false;
    private SpriteRenderer spriteRenderer;
    private CharacterSelector characterSelector;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterSelector = GetComponentInParent<CharacterSelector>();
        
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            if (!isHovered)
            {
                spriteRenderer.color = glowColor;
                isHovered = true;
            }
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log(gameObject.name);
                characterSelector.StartGame(gameObject.name);

            }
        }
        else if (isHovered)
        {
            spriteRenderer.color = normalColor;
            isHovered = false;
        }
    }
}
