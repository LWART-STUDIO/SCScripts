
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GAME_MAIN.CodeBase.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GAME_MAIN.CodeBase.Logic
{
    public class DestroyTarget : MonoBehaviour
    {
        [SerializeField] private GameObject _referense;
        [SerializeField] private Transform[] _fragments;
        public Vector3 MinRandomRotation;
        public Vector3 MaxRandomRotation;
        public float FallingSpeedMultiplier;
        public float FallingDuration;
        public Vector3 ImpactPoint;
        public Vector3 ImpactNormal;
        public Vector3 ShootPosition;
        public float Strength;
        
        

        public void Awake()
        {
            if (_referense != null)
            {
                _fragments = _referense.GetComponentsInChildren<Transform>();
                _fragments = _fragments.Skip(1).ToArray();
            }

        }

        public void Demolish()
        {
            if (_referense != null)
            {
                _referense.transform.SetParent(null);
                _referense.SetActive(true);
                foreach (Transform fragment in _fragments)
                {
                    CopyComponent(fragment.gameObject);
                    DestroyTarget destroyTarget=CopyComponent(fragment.gameObject);
                    int rnd = Random.Range(0, 3);
                    if (rnd == 2)
                    {
                        Rigidbody rb=fragment.gameObject.AddComponent<Rigidbody>();
                        var collider = fragment.gameObject.AddComponent<BoxCollider>();
                        if (rb == null)
                        {
                            rb = fragment.GetComponent<Rigidbody>();
                        }
                       // rb.isKinematic = true;
                        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                    }
                    destroyTarget.StartFalling();
                    
                }
               Destroy(gameObject);
            }
        }

        public void StartFalling()
        {
            StartCoroutine(FallingProcessing());
        }

        public IEnumerator FallingProcessing()
        {
            float t = 0f;
            float speedMult = 0f;
            float rayLength = 1f;
            Vector3 movementVector = (ImpactNormal-ShootPosition).normalized*Strength*100;
            movementVector.Random(Vector3.zero,movementVector);
            Vector3 randomEulers = new Vector3(
                Random.Range(MinRandomRotation.x, MaxRandomRotation.x),
                Random.Range(MinRandomRotation.y, MaxRandomRotation.y),
                Random.Range(MinRandomRotation.z, MaxRandomRotation.z));

                while (t < 1f)
                {
                    if (gameObject.TryGetComponent(out Rigidbody rb))
                    {
                        StartCoroutine(PhiscFalling(rb, movementVector));
                        yield break;
                    }
                    else
                    {
                        speedMult = Mathf.SmoothStep(0f, 1f, t * FallingSpeedMultiplier);
                        movementVector += Physics.gravity;
                        transform.position +=movementVector * Time.deltaTime*speedMult;
                        transform.Rotate(randomEulers * speedMult);
                    }
                    
                    // if (_isDestructionFx && !_isGrounded) CheckGrounded(rayLength);
                    t += Time.deltaTime / FallingDuration;
                    yield return null;
                
            }
            

            gameObject.SetActive(false);
        }

        private IEnumerator PhiscFalling(Rigidbody rb,Vector3 movementVector)
        {
            rb.velocity = movementVector/100;
            yield return new WaitForSeconds(4f);
            rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
            rb.isKinematic = true;
            
            yield return new WaitForSeconds(20f);
            gameObject.SetActive(false);
        }

        DestroyTarget CopyComponent( GameObject destination)
        {
            DestroyTarget copy = destination.AddComponent<DestroyTarget>();
            // Copied fields can be restricted with BindingFlags
            copy.FallingDuration = FallingDuration;
            copy.FallingSpeedMultiplier = FallingSpeedMultiplier;
            copy.MaxRandomRotation = MaxRandomRotation;
            copy.MinRandomRotation = MinRandomRotation;
            copy.ImpactPoint = ImpactPoint;
            copy.ShootPosition = ShootPosition;
            copy.Strength = Strength;

            return copy;
        }
    }
}