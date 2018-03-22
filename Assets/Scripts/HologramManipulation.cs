using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;

namespace HoloToolkit.Unity.InputModule
{
	public class HologramManipulation : MonoBehaviour, IManipulationHandler
	{

		public bool isTransformEnabled = true;
		public bool isDragging = false;
		public bool isScaling = false;
		public bool isRotating = false;
		public bool isKeywordDrag = true;
		public bool isKeywordScale = false;
		public bool isKeywordRotate = false;

		private float _resizeSpeedFactor = 0.5f;
		private float _dragSpeedFactor = 0.2f;
		private int _maxDragDistance = 50;
		private float _rotationSpeedFactor = 200.0f;

		private Vector3 _previousPosition;
		private float _dragFactor;
		private Vector3 _previousScale;
		private float _scaleFactor;
		private Quaternion _previousRotation;
		private float _rotationFactor;

		private IInputSource _currentInputSource;
		private uint _currentInputSourceId;

		private float _handDistance;
		private Vector3 _handPosition;
		private Vector3 _newHandPosition;




		public void OnManipulationStarted(ManipulationEventData eventData)
		{
			Debug.Log("manipulation started");

			if (!isTransformEnabled)
			{
				return;
			}

			if (isScaling)
			{
				return;
			}

			if (isDragging)
			{
				return;
			}

			if (isRotating)
			{
				return;
			}

			isScaling = isKeywordScale;
			isDragging = isKeywordDrag;
			isRotating = isKeywordRotate;

			// put the game object onto the model stack
			InputManager.Instance.PushModalInputHandler(gameObject);

			_currentInputSource = eventData.InputSource;
			_currentInputSourceId = eventData.SourceId;

			_previousPosition = transform.position;
			_previousScale = transform.localScale;
			_previousRotation = transform.rotation;

			// Find position of hand
			_currentInputSource.TryGetPointerPosition(_currentInputSourceId, out _handPosition);
		}


		public void OnManipulationUpdated(ManipulationEventData eventData)
		{

			if (isTransformEnabled)
			{
				_currentInputSource.TryGetPointerPosition(_currentInputSourceId, out _newHandPosition);

				_handDistance = Vector3.Magnitude(_newHandPosition - _handPosition);

				if (isDragging)
				{
					Debug.Log("calling drag script");
					_dragFactor = (Mathf.Abs(_handDistance) * 10);
					drag(eventData.CumulativeDelta);
				}

				if (isScaling)
				{
					Debug.Log("calling scale script");
					_scaleFactor = (Mathf.Abs(_handDistance) * 10);
					scale(eventData.CumulativeDelta);
				}

				if (isRotating)
				{
					Debug.Log("calling rotate script");
					_rotationFactor = (Mathf.Abs(_handDistance) * 10);
					Quaternion rotation = new Quaternion(eventData.CumulativeDelta.x * _rotationFactor, eventData.CumulativeDelta.y * _rotationFactor, eventData.CumulativeDelta.z * _rotationFactor, 0.0f);
					rotate(rotation);
				}
			}


		}

		void scale(Vector3 newScale)
		{
			float x, y, z;

			// warp
			x = newScale.x * _scaleFactor;

			x = Mathf.Clamp(_previousScale.x + x, 0.2f, 2.0f);

			y = x;
			z = x;

			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(x, y, z), _resizeSpeedFactor);
		}

		void drag(Vector3 newPosition)
		{
			Vector3 targetPosition = _previousPosition + newPosition * _dragFactor;
			Debug.Log("Checking distance before dragging: " + Vector3.Distance(_previousPosition, targetPosition));
			if (Vector3.Distance(_previousPosition, targetPosition) <= _maxDragDistance)
			{
				Debug.Log("transforming position");
				transform.position = Vector3.Lerp(transform.position, targetPosition, _dragSpeedFactor);
			}
		}

		void rotate(Quaternion newRotation)
		{
			transform.rotation = Quaternion.Euler(new Vector3(_previousRotation.x, _previousRotation.y + newRotation.y, _previousRotation.z) * _rotationSpeedFactor);
		}

		public void OnManipulationCompleted(ManipulationEventData eventData)
		{
			Debug.Log("manipulation completed");

			if (!isDragging)
			{
				return;
			}
			if (!isRotating)
			{
				return;
			}
			if (!isScaling)
			{
				return;
			}


			// pop game off model stack
			InputManager.Instance.PopModalInputHandler();
			_currentInputSource = null;
			isDragging = false;
			isRotating = false;
			isScaling = false;
		}

		public void OnManipulationCanceled(ManipulationEventData eventData)
		{
			Debug.Log("manipulation canceled");

			if (!isDragging)
			{
				return;
			}
			if (!isRotating)
			{
				return;
			}
			if (!isScaling)
			{
				return;
			}

			// pop game off model stack
			InputManager.Instance.PopModalInputHandler();
			_currentInputSource = null;
			isDragging = false;
			isRotating = false;
			isScaling = false;
		}
	}

}
