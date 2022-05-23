using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class BodyPart : MonoBehaviour
    {
        public EnemyControll enemy;
        public Renderer bodyPartRenderer;
        public GameObject bodyPartPrefab;

        public bool replaced;
        // Start is called before the first frame update

        public void HidePartAndReplace()
        {
            if (replaced)
                return;

            if (bodyPartRenderer != null)
                bodyPartRenderer.enabled = false;

            GameObject part=null;
            if (bodyPartPrefab != null)
                part = Instantiate(bodyPartPrefab, transform.position, transform.rotation);

            Rigidbody[] rbs = part.GetComponentsInChildren<Rigidbody>();
            Rigidbody rb = part.GetComponent<Rigidbody>();
            foreach (Rigidbody r in rbs)
            {
                r.interpolation = RigidbodyInterpolation.Interpolate;
                r.AddExplosionForce(15, transform.position, 5);
            }

            rb.AddExplosionForce(15, transform.position, 5);

            this.enabled = false;
            replaced = true;
        }
    }
}
