using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "voidEventChannel", menuName = "Scriptable Objects/voidEventChannel")]
public class voidEventChannel : ScriptableObject
{
    public UnityAction OnEventRaised;
     public void Raise(){
        if (OnEventRaised!=null){
            OnEventRaised.Invoke();
        }
     }
}
