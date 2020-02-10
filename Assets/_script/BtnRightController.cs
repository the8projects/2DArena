using UnityEngine;

public class BtnRightController : MonoBehaviour
{
    private bool _rotateRight;
    public bool rotateRight
    {
        get { return _rotateRight; }
        set { _rotateRight = value; }
    }
    
    public void OnPress()
    {
        rotateRight = true;
        Debug.Log("RightPressed");
    }

    public void OnRelease()
    {
        rotateRight = false;
    }
}
