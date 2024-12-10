using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2f;
    public float zoomSpeed = 2f; // 줌 속도
    public float minZoom = 5f; // 최소 줌
    public float maxZoom = 20f; // 최대 줌
    public SpriteRenderer backgroundSprite;

    private Camera mainCamera;
    private Vector3 dragOrigin;
    private bool isDragging = false;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            enabled = false;
            return;
        }

        if (backgroundSprite == null)
        {
            enabled = false;
            return;
        }

        CalculateBounds();
    }

    void CalculateBounds()
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        Bounds bounds = backgroundSprite.bounds;
        minX = bounds.min.x + camWidth;
        maxX = bounds.max.x - camWidth;
        minY = bounds.min.y + camHeight;
        maxY = bounds.max.y - camHeight;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 pos = mainCamera.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

            Vector3 newPosition = transform.position - move;
            transform.position = ClampCamera(newPosition);

            dragOrigin = Input.mousePosition;
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            float newSize = mainCamera.orthographicSize - scrollInput * zoomSpeed;
            newSize = Mathf.Clamp(newSize, minZoom, maxZoom);

            Vector3 beforeZoomPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            mainCamera.orthographicSize = newSize;

            CalculateBounds();

            Vector3 afterZoomPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = beforeZoomPos - afterZoomPos;

            transform.position = ClampCamera(transform.position + offset);
        }
    }

    Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        float minX = backgroundSprite.bounds.min.x + camWidth;
        float maxX = backgroundSprite.bounds.max.x - camWidth;
        float minY = backgroundSprite.bounds.min.y + camHeight;
        float maxY = backgroundSprite.bounds.max.y - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}