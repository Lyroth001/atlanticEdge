using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]


public class IKcontrol : MonoBehaviour
{
    protected Animator _animator;

    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform leftHandObj = null;
    public Transform headObj = null;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        if (_animator)
        {
            if (ikActive)
            {
                if (rightHandObj != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.position);
                    _animator.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.rotation);
                }
                if (leftHandObj != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    _animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.position);
                    _animator.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.rotation);
                }

                if (headObj != null)
                {
                    _animator.SetLookAtWeight(1);
                    _animator.SetLookAtPosition(headObj.position);
                }
                
            }
        }
    }
}
