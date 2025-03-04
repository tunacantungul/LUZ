using UnityEngine;

public class Door : MonoBehaviour
{
    public float openAngle = 90f;
    public float smooth = 2f;

    private Quaternion _closedRotation;
    private Quaternion _openRotation;
    private bool _isOpen = false;

    void Start()
    {
        _closedRotation = transform.rotation;
        _openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        if (_isOpen)
            transform.rotation = Quaternion.Slerp(transform.rotation, _openRotation, Time.deltaTime * smooth);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, _closedRotation, Time.deltaTime * smooth);
    }

    public void ToggleDoor()
    {
        _isOpen = !_isOpen;
    }
}