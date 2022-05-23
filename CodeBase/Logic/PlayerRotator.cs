using System.Collections;
using UnityEngine;
namespace GAME_MAIN.CodeBase.Logic
{
    public class PlayerRotator : MonoBehaviour
    {
        public float Speed;
        public float SpeedFx=1;
        public float MoveHight;
        public float MoveSpeed;
        public float MoveTime;
        private SnipeMove _snipeMove;

        
        private void Update()
        {
            transform.Rotate(0,Speed*SpeedFx,0,Space.Self);
        }

        public void MoveUp()
        {
            _snipeMove = FindObjectOfType<SnipeMove>();
            _snipeMove.CanAtack = false;
            Vector3 newPosition = transform.position + new Vector3(0, MoveHight, 0);
            StartCoroutine(Move(newPosition));
        }

        private IEnumerator Move(Vector3 newPosition)
        {
            float t = Time.time;
            SpeedFx = 1.5f;
            float fracTime=0;
            while (true)
            {
                fracTime = Mathf.PingPong(Time.time - t, MoveTime / MoveSpeed);
                transform.position =Vector3.Slerp(transform.position,newPosition,fracTime*MoveSpeed);
                if (fracTime >= 1)
                {
                    SpeedFx = 1;
                    _snipeMove.CanAtack = true;
                    yield break;
                }
                yield return null;
            }

            

        }
    }
}
