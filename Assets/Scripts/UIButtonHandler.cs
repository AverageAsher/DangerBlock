using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum ButtonType { Left, Right }
    public ButtonType buttonType;
    public PlayerController player;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonType == ButtonType.Left)
            player.MoveLeft();
        else if (buttonType == ButtonType.Right)
            player.MoveRight();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.StopMoving();
    }
}
