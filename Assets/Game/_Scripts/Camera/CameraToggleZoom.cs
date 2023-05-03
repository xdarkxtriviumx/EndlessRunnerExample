using Aberranthian.EndlessRunner.Game.Handlers;
using System.Collections;
using UnityEngine;

namespace Aberranthian.EndlessRunner.Game
{
    public class CameraToggleZoom : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private float _zoomOutSize = 15f;
        [SerializeField] private float _zoomSpeed = 1f;

        [Header("References")]
        [SerializeField] private InputHandler _input;

        private Camera _camera;
        private float _initialZoomSize;
        private bool _isZooming = false;
        private bool _zoomedIn = true;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _initialZoomSize = _camera.orthographicSize;
        }

        private void Start()
        {
            _input.ZoomPressed += ToggleZoom;
        }

        private void OnDestroy()
        {
            _input.ZoomPressed -= ToggleZoom;
        }

        private void ToggleZoom()
        {
            if (_isZooming) return;

            _isZooming = true;
            StartCoroutine(ZoomCam());
        }

        private IEnumerator ZoomCam()
        {
            float start, end, current;
            float ratio = 0f;
            bool nextState;

            if (_zoomedIn)
            {
                start = _initialZoomSize;
                end = _zoomOutSize;
            }
            else
            {
                start = _zoomOutSize;
                end = _initialZoomSize;
            }

            nextState = !_zoomedIn;

            current = start;

            while (current != end)
            {
                current = Mathf.Lerp(start, end, ratio / _zoomSpeed);
                _camera.orthographicSize = current;
                yield return new WaitForEndOfFrame();
                ratio += Time.deltaTime;
            }

            _zoomedIn = nextState;
            _isZooming = false;
        }
    }
}