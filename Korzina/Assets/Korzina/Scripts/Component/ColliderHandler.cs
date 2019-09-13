using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ColliderHandler : MonoBehaviour
{
    public RectTransform parent;

    public event Action<bool> CollisionEvent;

    private BoxCollider2D box;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        box.size = new Vector2(parent.rect.width, box.size.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Spawner.StatusObj status = collision.gameObject.GetComponent<Spawner>().status;

        if (status == Spawner.StatusObj.GoodObject)
        {
            CollisionEvent?.Invoke(false);
        }
        else
        {
            CollisionEvent?.Invoke(true);
        }

        Destroy(collision.gameObject);
    }
}