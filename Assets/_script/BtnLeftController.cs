using UnityEngine;

public class BtnLeftController : MonoBehaviour
{
    private bool _rotateLeft;
    public bool rotateLeft
    {
        get { return _rotateLeft; }
        set { _rotateLeft = value; }
    }
    
    public void OnPress()
    {
        rotateLeft = true;
        Debug.Log("LeftPressed");
    }

    public void OnRelease()
    {
        rotateLeft = false;
    }
}
