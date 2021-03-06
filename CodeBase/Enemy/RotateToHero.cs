using UnityEngine;

namespace GAME_MAIN.CodeBase.Enemy
{
    public class RotateToHero:MonoBehaviour
    {
        public float Speed=3;

        private Transform _heroTransform;
        private Vector3 _positionToLook;

        public void Constract(Transform heroTransform)
        {
            _heroTransform = heroTransform;
        }
        

        private void Update()
        {
            if (IsInitialized())
                RotateTowardsHero();
        }

        private void RotateTowardsHero()
        {
            UpdatePositionToLookAt();

            transform.rotation = SmoothedRotation(transform.rotation, _positionToLook);
        }

        private void UpdatePositionToLookAt()
        {
            Vector3 positionDelta = _heroTransform.position - transform.position;
            _positionToLook = new Vector3(positionDelta.x, transform.position.y, positionDelta.z);
        }
    
        private Quaternion SmoothedRotation(Quaternion rotation, Vector3 positionToLook) =>
            Quaternion.Lerp(rotation, TargetRotation(positionToLook), SpeedFactor());

        private Quaternion TargetRotation(Vector3 position) =>
            Quaternion.LookRotation(position);

        private float SpeedFactor() =>
            Speed * Time.deltaTime;

        private bool IsInitialized() => 
            _heroTransform != null;
        


    }
}