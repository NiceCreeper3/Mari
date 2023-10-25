using UnityEngine;

public class BounsPadSkript : MonoBehaviour, IJumpable
{
    [Header("How highe the player wil bouns")]
    [SerializeField] float _maxBounse;
    [SerializeField] float _normalBounse;

    private MariValues _mariValues;

    void IJumpable.JumpetOn(int hit)
    {
        Debug.Log("Platform hit");
        BoundsPlayer();
    }

    void BoundsPlayer()
    {
        // will make the player bouns estrer high if there press jump 
        if (Input.GetButton("Jump"))
        {
            MariValues.Velocity.y = _maxBounse;
            FindObjectOfType<AudioMangerScript>().PlayAudio("MaxBoundsJump", true);
        }
        else
        {
            MariValues.Velocity.y = _normalBounse;
            FindObjectOfType<AudioMangerScript>().PlayAudio("NormalBoundsJump", true);
        }
    }

}
