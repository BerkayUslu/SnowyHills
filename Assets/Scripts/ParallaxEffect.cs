using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxEffect : MonoBehaviour
{
   [SerializeField] private Vector2 _parallaxEffectMultiplier;

   private Transform _transform;
   private Transform _cameraTransform;
   private Vector3 _lastCameraPosition;
   private float textureUnitSizeX;
   

   private void Awake()
   {
      _cameraTransform = Camera.main.transform;
      _transform = transform;
      _lastCameraPosition = _cameraTransform.position;
      Sprite sprite = GetComponent<SpriteRenderer>().sprite;
      Texture2D texture = sprite.texture;
      textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
   }

   private void LateUpdate()
   {
      Vector3 positionChange = _cameraTransform.position - _lastCameraPosition;
      _transform.position +=
         new Vector3(_parallaxEffectMultiplier.x * positionChange.x , _parallaxEffectMultiplier.y * positionChange.y);
      _lastCameraPosition = _cameraTransform.position;

      if (_cameraTransform.position.x - _transform.position.x >= textureUnitSizeX)
      {
         float offsetPosition = (_cameraTransform.position.x - _transform.position.x) % textureUnitSizeX;
         _transform.position = new Vector3(_cameraTransform.position.x + offsetPosition, _transform.position.y, _transform.position.z);
      }
   }
}
