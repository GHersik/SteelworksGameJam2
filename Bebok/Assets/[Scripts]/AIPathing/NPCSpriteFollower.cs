using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpriteFollower : MonoBehaviour {
    [SerializeField] NPC controller;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Vector2 offset;

    private void Update() {
        PositionSprite();
    }

    private void PositionSprite() {
        this.transform.position = new Vector2(controller.transform.position.x + offset.x, controller.transform.position.y + offset.y);
    }
}
