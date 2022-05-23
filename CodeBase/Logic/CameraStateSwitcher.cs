using System.Collections;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class CameraStateSwitcher : MonoBehaviour
    {
        [SerializeField] private Animator _camerasAnimator;
        public bool CameraMove;

        public void SwitchCamera(string name)
        {
            if (name == "Start")
            {
                SwitchToMainCamera();
            }
        }
        public void SwitchToMainCamera()
        {
            _camerasAnimator.Play("MainCamera");
            CameraMove = true;
            StopAllCoroutines();
            StartCoroutine(WaitForCanAdd());
        }
        private IEnumerator WaitForCanAdd()
        {
       
            CameraMove = true;
            /*TimerAds.Finished = false;
            float timer = 30f;
            if (TimerAds.Timer >= (TimerAds.TimerMax - timer))
            {
                TimerAds.Timer -= timer;
            }
            while (timer>0)
            {
                timer -= Time.deltaTime;
                yield return null;
            }*/
            yield return null;
            CameraMove = false;

        }
    }
}
