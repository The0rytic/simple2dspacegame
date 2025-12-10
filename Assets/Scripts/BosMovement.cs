using UnityEngine;
using System.Collections;

public class BosMovement : MonoBehaviour
{
    public float moveDistance = 0.7f;
    public float bottomLimit = -0.5f;
    public float topLimit = 3f;
    
    // 🔥 NEW: Horizontal boundaries
    public float leftLimit = -3f;
    public float rightLimit = 3f;
    
    public float horizontalDuration = 1.5f;
    public float chargeDuration = 1.2f;
    public float backDuration = 1.2f;
    
    public bool movingRight = true;
    
    enum BossState { Horizontal, ChargeForward, MoveBack }
    BossState currentState = BossState.Horizontal;
    SpriteRenderer sr;
    
    public AnimationCurve easeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.flipY = true;
        StartCoroutine(StateMachine());
    }
    
    IEnumerator StateMachine()
    {
        while (true)
        {
            switch (currentState)
            {
                case BossState.Horizontal:
                    yield return StartCoroutine(MoveHorizontal());
                    currentState = BossState.ChargeForward;
                    break;
                case BossState.ChargeForward:
                    yield return StartCoroutine(ChargeDown());
                    currentState = BossState.MoveBack;
                    break;
                case BossState.MoveBack:
                    yield return StartCoroutine(MoveUp());
                    currentState = BossState.Horizontal;
                    break;
            }
        }
    }
    
    // ==========================================================
    // MOVEMENTS WITH TRUE EASING + RANDOM MOVE DISTANCE + BOUNDS
    // ==========================================================
    IEnumerator MoveHorizontal()
    {
        float startX = transform.position.x;
        
        // 🔥 COMPLETELY RANDOM target position within bounds
        float targetX = Random.Range(leftLimit, rightLimit);
        
        // Update direction based on where we're moving
        movingRight = targetX > startX;
        
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / horizontalDuration;
            float easedT = easeCurve.Evaluate(t);
            transform.position = new Vector3(
                Mathf.Lerp(startX, targetX, easedT),
                transform.position.y,
                0
            );
            sr.flipX = !movingRight;
            yield return null;
        }
    }
    
    IEnumerator ChargeDown()
    {
        float startY = transform.position.y;
        float targetY = bottomLimit - 0.5f;
        sr.flipY = false;
        
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / chargeDuration;
            float easedT = easeCurve.Evaluate(t);
            transform.position = new Vector3(
                transform.position.x,
                Mathf.Lerp(startY, targetY, easedT),
                0
            );
            yield return null;
        }
    }
    
    IEnumerator MoveUp()
    {
        float startY = transform.position.y;
        float targetY = topLimit + 0.5f;
        sr.flipY = true;
        
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / backDuration;
            float easedT = easeCurve.Evaluate(t);
            transform.position = new Vector3(
                transform.position.x,
                Mathf.Lerp(startY, targetY, easedT),
                0
            );
            yield return null;
        }
    }
    
    // ==========================================================
    // GIZMOS — ALL LIMIT LINES
    // ==========================================================
    private void OnDrawGizmos()
    {
        // Bottom limit (red)
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-10f, bottomLimit, 0), new Vector3(10f, bottomLimit, 0));
        
        // Top limit (green)
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(-10f, topLimit, 0), new Vector3(10f, topLimit, 0));
        
        // 🔥 Left limit (blue)
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(leftLimit, -10f, 0), new Vector3(leftLimit, 10f, 0));
        
        // 🔥 Right limit (yellow)
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(rightLimit, -10f, 0), new Vector3(rightLimit, 10f, 0));
    }
}