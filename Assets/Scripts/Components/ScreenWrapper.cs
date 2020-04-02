using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ScreenWrap.CheckAndWrapAround(_rb);
    }
}
