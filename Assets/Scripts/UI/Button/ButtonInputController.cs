using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInputController : MonoBehaviour
{
    public PlayerMovement playerMovement; // 將 PlayerMovement 物件拖入這裡
    private float horizontalInput;
    

    // UI Button
    public GameObject moveLeftButton;
    public GameObject moveRightButton;
    public Button jumpButton;

    private void Start()
    {
        // 綁定按鈕事件
        // 為左右按鈕添加事件
        AddEventTrigger(moveLeftButton, OnMoveLeftDown, EventTriggerType.PointerDown); // 按下
        AddEventTrigger(moveLeftButton, OnMoveStop, EventTriggerType.PointerUp); // 釋放

        AddEventTrigger(moveRightButton, OnMoveRightDown, EventTriggerType.PointerDown); // 按下
        AddEventTrigger(moveRightButton, OnMoveStop, EventTriggerType.PointerUp); // 釋放
        jumpButton.onClick.AddListener(()=>Jump());
    }
     private void AddEventTrigger(GameObject target, UnityEngine.Events.UnityAction<BaseEventData> action, EventTriggerType triggerType)
    {
        EventTrigger trigger = target.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = target.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = triggerType };
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }
    private void OnMoveLeftDown(BaseEventData data)
    {
        playerMovement.SetHorizontalInput(-1f); // 左移
    }

    private void OnMoveRightDown(BaseEventData data)
    {
        playerMovement.SetHorizontalInput(1f); // 右移
    }

    private void OnMoveStop(BaseEventData data)
    {
        playerMovement.SetHorizontalInput(0); // 停止移動
    }

     public void Jump()
    {
        playerMovement.PerformJump();
    }
}
