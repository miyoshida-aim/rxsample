using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEx : Button
{

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);
        Debug.Log("state : " + state);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        Debug.Log("onDeselect : " + eventData.selectedObject.name);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        Debug.Log("OnSelect : " + eventData.selectedObject.name);
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        base.OnSubmit(eventData);
        Debug.Log("OnSubmit : " + eventData.selectedObject.name);
    }
}
