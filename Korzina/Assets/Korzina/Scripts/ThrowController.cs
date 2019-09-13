using Dialogs;
using UnityEngine;
using UnityEngine.UI;

public class ThrowController : MonoBehaviour
{
    //PUBLIC VARIABLES

    public float Y;
    public float Z;
    public float speed = 5f;

    //EDITOR VARIABLES

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Slider _slider;

    //CONSTANT

    public const int MIN_FORCE = 8;

    public const int MAX_FORCE = 11;

    //PRIVATE VARIABLES

    private bool freezeUI;
    private Vector3 startPos = new Vector3(0, 0.23f, 6f);

    private void Start()
    {
        DialogController.Instance.onDialogsOpened += Lock;
        DialogController.Instance.onDialogsClosed += Unlock;
    }

    private void Update()
    {
        if (freezeUI)
            return;

        _slider.value = Mathf.PingPong(Time.time, 1f);
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
        {
            freezeUI = true;
            Throwing();
        }
    }

    public void Resets()
    {
        if (_slider != null)
            _slider.value = 0;

        freezeUI = false;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.transform.position = startPos;
    }

    public void ThrowComplete()
    {
        ScoreManager.Instance.AddScore();
        Resets();
    }

    public void Throwing()
    {
        Y = Mathf.Lerp(MIN_FORCE, MAX_FORCE, _slider.value);
        _rb.AddForce(new Vector3(0, Y, Z), ForceMode.Impulse);
    }

    private void Lock()
    {
        freezeUI = true;
    }

    private void Unlock()
    {
        freezeUI = false;
    }

    private void OnDestroy()
    {
        DialogController.Instance.onDialogsOpened -= Lock;
        DialogController.Instance.onDialogsClosed -= Unlock;
    }
}