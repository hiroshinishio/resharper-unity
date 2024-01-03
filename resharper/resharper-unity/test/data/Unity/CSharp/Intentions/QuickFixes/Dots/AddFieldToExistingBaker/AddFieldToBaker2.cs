using Unity.Entities;
using UnityEngine;

namespace Systems
{
  public struct Angle : IComponentData
  {
    public float Value;
    public float Max{caret}Value;
  }

  public class AngleAuthoring : MonoBehaviour
  {
    public float Angle;
    public class AngleBaker : Baker<AngleAuthoring>
    {
      public override void Bake(AngleAuthoring authoring)
      {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity,
          new Angle
            {
              Value = authoring.Angle % 360,
            });
      }
    }
  }
}
