using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectivePan : MonoBehaviour{
    private static readonly float PanSpeed = 5f;

    private static readonly float[] BoundsX = new float[] { -10f, 5f };
    private static readonly float[] BoundsZ = new float[] { -18f, -4f };

    private float zoomOutMin = 0;
    private float zoomOutMax = 0;

    private Camera cam;

    private Vector3 lastPanPosition;
    private int panFingerId; // Touch mode only

    private bool wasZoomingLastFrame; // Touch mode only
    private Vector2[] lastZoomPositions; // Touch mode only

    void Awake() {
        zoomOutMin = 10f;
        zoomOutMax = 85f;

        cam = GetComponent<Camera>();
    }

    void Update() {
        HandleTouch();
    }

    void HandleTouch() {
        switch (Input.touchCount) {

            case 1: // Panning
                wasZoomingLastFrame = false;

                // If the touch began, capture its position and its finger ID.
                // Otherwise, if the finger ID of the touch doesn't match, skip it.
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    lastPanPosition = touch.position;
                    panFingerId = touch.fingerId;
                } else if (touch.fingerId == panFingerId && touch.phase == TouchPhase.Moved) {
                    PanCamera(touch.position);
                }
                break;

            case 2: // Zooming
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                zoom(difference * 0.1f);
                break;

            default:
                wasZoomingLastFrame = false;
                break;
        }
    }

    void PanCamera(Vector3 newPanPosition) {
        // Determine how much to move the camera
        Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
        Vector3 move = new Vector3(offset.x * PanSpeed, offset.y * PanSpeed,0);

        // Perform the movement
        transform.Translate(move, Space.World);

        // Ensure the camera remains within bounds.
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, BoundsX[0], BoundsX[1]);
        pos.z = Mathf.Clamp(transform.position.z, BoundsZ[0], BoundsZ[1]);
        transform.position = pos;

        // Cache the position
        lastPanPosition = newPanPosition;
    }

    void zoom(float increment) {

        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - increment, zoomOutMin, zoomOutMax);
    }
}