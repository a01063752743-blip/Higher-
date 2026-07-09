using UnityEngine;

public class DiffiManager : MonoBehaviour
{
    public static DiffiManager instance;

    public bool _easy = false;
    public bool _normal = false;
    public bool _hard = false;
    public bool _secret = false;

    private void Awake()
    {
        instance = this;
    }

    public void Reset()
    {
        _easy = false;
        _normal = false;
        _hard = false;
        _secret = false;
    }
}
