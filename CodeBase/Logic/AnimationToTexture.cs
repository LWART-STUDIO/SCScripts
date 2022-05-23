using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class AnimationToTexture:MonoBehaviour
    {
        [SerializeField] private Transform[] _fragments;
        private bool WantRecord=false;
        [SerializeField]private List<Color> positionColors=new List<Color>();
        [SerializeField]private List<Color> rotationColors=new List<Color>();

        private void Awake()
        {
            _fragments = GetComponentsInChildren<Transform>();
            StartCoroutine(Record());
        }

        private IEnumerator Record()
        {
            WantRecord = true;
            yield return new WaitForSeconds(2f);
            WantRecord = false;
            GenerateImages();
        }

        private void FixedUpdate()
        {
            if (WantRecord)
            {
                foreach (Transform fragment in _fragments)
                {
                    var localPosition = fragment.localPosition;
                    Color posColor = new Color(FloatToColor(localPosition.x),
                        FloatToColor(localPosition.y), FloatToColor(localPosition.z));
                    positionColors.Add(posColor);
                    
                    
                    var localRotation = transform.localRotation;
                    Color rotColor = new Color(FloatToColor(localRotation.x),
                        FloatToColor(localRotation.y), FloatToColor(localRotation.z));
                    rotationColors.Add(rotColor);
                }
            }
        }

        private void GenerateImages()
        {
            int frames = positionColors.Count / _fragments.Length;
            Texture2D posTexture2D = new Texture2D(_fragments.Length,frames);
            Texture2D rotTexture2D = new Texture2D(_fragments.Length,frames);

           
                /*for (int j = 0; j < positionColors.Count; j++)
                {
                    for (int i = 0; i < _fragments.Length; i++)
                    {

                        Color color = positionColors[j];
                        posTexture2D.SetPixel(i,j,color);
                        
                        Color color1 = rotationColors[j];
                        rotTexture2D.SetPixel(i,j,color1);
                        j++;

                    }

                    j--;

                    Debug.Log(j);
                }*/
                posTexture2D.SetPixels(positionColors.ToArray());
                rotTexture2D.SetPixels(rotationColors.ToArray());

            posTexture2D.Apply();
            rotTexture2D.Apply();

            byte[] pBytes = posTexture2D.EncodeToPNG();
            byte[] rBytes = rotTexture2D.EncodeToPNG();
            DestroyImmediate(posTexture2D);
            DestroyImmediate(rotTexture2D);

            if(!Directory.Exists(Application.dataPath+"/Assets/GAME_MAIN/Resources/Images/"+$"{gameObject.name}")) {
                Directory.CreateDirectory(Application.dataPath+"/Assets/GAME_MAIN/Resources/Images/"+$"{gameObject.name}");
            }
            File.WriteAllBytes(Application.dataPath + "/Assets/GAME_MAIN/Resources/Images/"+$"{gameObject.name}" + "PositionTexture" + ".png", pBytes);
            File.WriteAllBytes(Application.dataPath + "/Assets/GAME_MAIN/Resources/Images/" +$"{gameObject.name}"+ "RotationTexture" + ".png", rBytes);
        }

        float FloatToColor(float pos)
        {
            float x = 1 / pos;
            return x;
        }
    }
}