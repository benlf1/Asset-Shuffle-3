using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Allows movement of a Rigidbody in the scene
/// </summary>
public class Movement : MonoBehaviour
{
    #region Variables
    [Header("Movement Settings")]
    public Rigidbody2D mainBody;

    private Vector3 _direction;
    public Vector3 Direction { get => _direction; }
    #endregion

    #region Initialization
    void Awake()
    {
        _direction = Vector3.right;
    }
    #endregion

    #region Motion Functions
    /// <summary>
    /// Sets the direction of the body
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void Face(float x, float y)
    {
        _direction.x = x;
        _direction.y = y;
    }

    /// <summary>
    /// Sets the direction of the body
    /// </summary>
    /// <param name="direction"></param>
    public void Face(Vector3 direction)
    {
        Face(direction.x, direction.y);
    }

    /// <summary>
    /// Creates motion for a Rigidbody by allowing a force onto the body
    /// </summary>
    /// <param name="body"></param>
    /// <param name="direction"></param>
    /// <param name="forceFactor"></param>
    public void Move(Rigidbody2D body, float forceFactor)
    {
        //body.AddForce(Vector3.Normalize(Direction) * forceFactor);
        body.velocity = Vector3.Normalize(Direction) * forceFactor;
    }

    /// <summary>
    /// Stops all current motion of a body
    /// </summary>
    /// <param name="body"></param>
    public void FullStop(Rigidbody2D body)
    {
        body.velocity = Vector3.zero;
    }
    #endregion
}
