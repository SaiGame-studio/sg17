using UnityEngine;

public class InputManager : SaiSingleton<InputManager>
{
    [SerializeField] private bool isMouseDown;
    [SerializeField] private bool isMouseUp;
    [SerializeField] private bool isRightClick;
    [SerializeField] private Vector3 mouseWorldPosition;
    [SerializeField] private Vector2 mouseScreenPosition;

    public bool IsMouseDown => isMouseDown;
    public bool IsMouseUp => isMouseUp;
    public bool IsRightClick => isRightClick;
    public Vector3 MouseWorldPosition => mouseWorldPosition;
    public Vector2 MouseScreenPosition => mouseScreenPosition;

    void Update()
    {
        isMouseDown = Input.GetMouseButtonDown(0);
        isMouseUp = Input.GetMouseButtonUp(0);
        isRightClick = Input.GetMouseButtonDown(1);
        mouseScreenPosition = Input.mousePosition;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane));

        if (isMouseDown)
        {
            Debug.Log("Left Mouse Button Pressed");
        }
        if (isMouseUp)
        {
            Debug.Log("Left Mouse Button Released");
        }
    }

    public Vector2 GetMouseScreenPosition()
    {
        return mouseScreenPosition;
    }

    public Vector3 GetMouseWorldPosition()
    {
        return mouseWorldPosition;
    }
}
