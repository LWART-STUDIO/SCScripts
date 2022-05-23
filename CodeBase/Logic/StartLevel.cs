using System;
using Dreamteck.Splines;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class StartLevel : MonoBehaviour
    {
        private CameraStateSwitcher _cameraStateSwitcher;
        private RotationSpeedControl _rotationSpeedControl;
        private PlayerRotator _playerRotator;
      //  private SplineFollower _splineFollower;
        

        private void Awake()
        {
            _cameraStateSwitcher = FindObjectOfType<CameraStateSwitcher>();
            _rotationSpeedControl = FindObjectOfType<RotationSpeedControl>();
          //  _splineFollower = FindObjectOfType<SplineFollower>();
            
        }

        public void StartClick()
        {
            _playerRotator = FindObjectOfType<PlayerRotator>();
            _rotationSpeedControl.SpeedFix = 0;
            _cameraStateSwitcher.SwitchCamera("Start");
          // _splineFollower.followSpeed = 4f;
            _playerRotator.Speed = -0.3f;
        }
    }
    
}
