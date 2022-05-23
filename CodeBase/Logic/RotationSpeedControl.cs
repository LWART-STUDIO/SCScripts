using System;
using System.Collections;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class RotationSpeedControl : MonoBehaviour
    {
        [SerializeField] private LevelRotator[] _rotators;
        public float SpeedFix=1;
        private float _defaultSpeedFix;

        private void Update()
        {
            foreach (LevelRotator rotator in _rotators)
            {
                rotator.SpeedFx = SpeedFix;
            }
        }

        public void SetSpeed(float value)
        {
            StartCoroutine(Set(value));
        }
        public void ResetSpeed()
        {
            StartCoroutine(Reset());
        }

        private IEnumerator Reset()
        {
            float t=0;
            while (Math.Abs(SpeedFix - _defaultSpeedFix) > 0.001f)
            {
                t += 0.5f * Time.deltaTime;
                SpeedFix = Mathf.Lerp(SpeedFix, _defaultSpeedFix, t);
                yield return null;
            }
        }
        private IEnumerator Set(float value)
        {
            float t=0;
            while (Math.Abs(SpeedFix - value) > 0.001f)
            {
                t += 0.5f * Time.deltaTime;
                SpeedFix = Mathf.Lerp(SpeedFix, value, t);
                yield return null;
            }
        }
    }
}
