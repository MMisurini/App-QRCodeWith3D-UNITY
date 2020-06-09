using UnityEngine;
using UnityEngine.EventSystems;

public class PointerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Rotate rot = null;

    public virtual void OnPointerDown(PointerEventData eventData){
        switch (name){
            case "Up":
                if(CheckTouch(rot))
                    rot.IsActive = new bool[] {true,false,false,false };
                break;
            case "Down":
                if (CheckTouch(rot))
                    rot.IsActive = new bool[] { false, true, false, false };
                break;
            case "Left":
                if (CheckTouch(rot))
                    rot.IsActive = new bool[] { false, false, true, false };
                break;
            case "Right":
                if (CheckTouch(rot))
                    rot.IsActive = new bool[] { false, false, false, true };
                break;
            case "Reset":
                rot.Reset();
                break;
        }
    }

    public virtual void OnPointerUp(PointerEventData eventData){
        rot.IsActive = new bool[] {false,false,false,false };
    }

    bool CheckTouch(Rotate rt) {
        foreach (bool a in rt.IsActive) {
            if (a != false)
                return false;
        }

        return true;
    }
}