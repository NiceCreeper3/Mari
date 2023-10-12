using UnityEngine;

public class StikeToObjeckt : MonoBehaviour
{
    // gets what to "StikeTo"
    [SerializeField] Transform _thingToStikeTo;

    // Update is called once per frame
    void LateUpdate()
    {
        // makes it so this object is alwas on the same position as the object it "stikes"
        transform.position = _thingToStikeTo.position;
    }
}
