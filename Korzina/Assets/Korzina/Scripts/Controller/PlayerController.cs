using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool left;
    public bool right;
    public RectTransform parent;

    public event Action<bool> CatchEvent;

    private float speed;
    private float offset;
    private ScreenOrientation orientation;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        offset = (parent.rect.width / 2f) - rectTransform.rect.width / 2;
        speed = 1.5f;
        orientation = Screen.orientation;
    }

    private void Update()
    {
        if (left)
        {
            if (transform.localPosition.x > -offset)
                transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (right)
        {
            if (transform.localPosition.x < offset)
                transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (orientation != Screen.orientation)
        {
            orientation = Screen.orientation;
            StartCoroutine(ChangeOffset());
        }
    }

    private IEnumerator ChangeOffset()
    {
        yield return new WaitForSecondsRealtime(1f);
        offset = (parent.rect.width / 2f) - rectTransform.rect.width / 2;
        if (transform.localPosition.x < -offset || transform.localPosition.x > offset)
        {
            transform.localPosition = Vector3.zero;
        }
        yield return null;
    }

    public void StartRight()
    {
        left = false;
        right = true;
    }

    public void StartLeft()
    {
        right = false;
        left = true;
    }

    public void ResetMove()
    {
        right = false;
        left = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Spawner.StatusObj status = collision.gameObject.GetComponent<Spawner>().status;

        if (status == Spawner.StatusObj.GoodObject)
        {
            CatchEvent?.Invoke(true);
        }
        else
        {
            CatchEvent?.Invoke(false);
        }

        Destroy(collision.gameObject);
    }
}