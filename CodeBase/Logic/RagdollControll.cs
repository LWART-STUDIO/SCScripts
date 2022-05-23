using System.Collections.Generic;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class RagdollControll : MonoBehaviour
    {

        [SerializeField] private Rigidbody[] _rigidbodies;
        [SerializeField] private Animator _animator;

        public void SetUpRagoll()
        {
            _rigidbodies = GetComponentsInChildren<Rigidbody>();
        }

        public void TurnOn()
        {
            foreach (Rigidbody rigdbody in _rigidbodies)
            {
                rigdbody.isKinematic = false;
                _animator.enabled = false;
            }
        }

        public void TurnOff()
        {
            foreach (Rigidbody rigdbody in _rigidbodies)
            {
                rigdbody.isKinematic = true;
            }
        }
    }
}
