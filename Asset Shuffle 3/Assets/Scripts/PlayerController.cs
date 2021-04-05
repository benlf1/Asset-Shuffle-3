using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Game Component; Controls and manages the actions of a Player
/// </summary>
public class PlayerController : Controller
{
    [Header("Player Host Component")]
    public PlayerHost host;

    [Header("Player Settings")]
    public float moveSpeed;

    private Vector2 currDirection;

    #region Update
    // Iterate each frame to check for player input
    void Update()
    {
        // Check for any play input
        GetInput();
        if (Input.GetMouseButtonDown(0))
        {
            host.movement.FullStop(host.movement.mainBody);
            StopAllCoroutines();
            host.movement.Face(currDirection);
            host.movement.Move(host.movement.mainBody, moveSpeed);
            float speed = host.movement.mainBody.velocity.magnitude;
            Debug.Log(speed);
            StartCoroutine(StopMovement(CalculateTime(Vector3.zero, currDirection, speed)));
        }
    }
    #endregion

    #region Input
    // Override the virtual input receiver
    protected override void GetInput()
    {
        GetMousePosition();
    }

    // Converts Mouse Position to a World Position
    private void GetMousePosition()
    {
        Vector2 mousePos = Input.mousePosition; // Returns coordinates in the Screen Coordinate System
        currDirection = Camera.main.ScreenToWorldPoint(mousePos) - transform.position; // Converts from Screen position to World Position relative to the player's position
    }
    #endregion

    #region Calculations
    private float CalculateTime(Vector2 current, Vector2 target, float rate) => Vector2.Distance(current, target) / rate;

    private IEnumerator StopMovement(float delay)
    {
        Debug.Log(delay);
        yield return new WaitForSeconds(delay);
        host.movement.FullStop(host.movement.mainBody);
    }
    #endregion
}
