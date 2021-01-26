/// <summary>
/// Object that can be hit and given some amount of damage
/// </summary>
public interface IHittable
{
    /// <summary>
    /// Get hit with some damage
    /// </summary>
    /// <param name="damage"></param>
    void Hit(float damage);
}
