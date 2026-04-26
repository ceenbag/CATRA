using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; // Required for the New Input System

public class PlayerAttack : MonoBehaviour
{
    [Tooltip("Drag your AttackHitbox child object here")]
    public GameObject attackHitbox; 
    
    public float attackDuration = 0.2f; 
    private bool isAttacking = false;

    void Update()
    {

        if (Keyboard.current != null && Keyboard.current.cKey.wasPressedThisFrame && !isAttacking) 
        {
            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
    {
        isAttacking = true;
        attackHitbox.SetActive(true); 

        yield return new WaitForSeconds(attackDuration);

        attackHitbox.SetActive(false); 
        isAttacking = false;
    }
}