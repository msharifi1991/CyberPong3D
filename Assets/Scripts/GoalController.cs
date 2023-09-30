using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    
    public UnityEvent onTriggerEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) {
            onTriggerEnter.Invoke();
        }
    }

}
