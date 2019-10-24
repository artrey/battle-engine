using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleEngine.BattleEntities
{
  public class UnitsStack : IParametersEntity, ICapacity
  {
    public Unit Unit { get; }
    public uint InitialCount { get; }
    
    public uint HitPoints { get; private set; }
    public uint Attack { get; private set; }
    public uint Defence { get; private set; }
    public uint MinDamage { get; private set; }
    public uint MaxDamage { get; private set; }
    public double Initiative { get; private set; }
    public uint TotalHitPoints { get; private set; }
    public uint LastUnitHitPoints => TotalHitPoints > 0 ? TotalHitPoints - (Count - 1) * HitPoints : 0;
    
    public uint Capacity => Constants.STACK_MAX_CAPACITY;
    public uint Count => (uint)Math.Ceiling(1.0 * TotalHitPoints / HitPoints);
    
    private readonly Dictionary<IModifier, uint> _temporaryModifiers = new Dictionary<IModifier, uint>();
    private readonly HashSet<IModifier> _permanentModifiers = new HashSet<IModifier>();
    
    public IEnumerable<IModifier> Modifiers(uint roundOffset = 0)
      => _temporaryModifiers.Keys.Union(_permanentModifiers).OrderBy(m => m.VisualName());

    public void AddModifier(IModifier modifier, uint rounds)
    {
      if (rounds == 0) throw new ArgumentException("Rounds must be grater than 0", nameof(rounds));
      _temporaryModifiers.Add(modifier, rounds);
    }

    public void RemoveModifier(IModifier modifier)
    {
      _temporaryModifiers.Remove(modifier);
    }

    public IEnumerable<BattleAction> AvailableActions(Battle battle)
      => BattleAction.AllActions.Where(a => a.Available(battle, this)).ToArray();

    public UnitsStack(MapEntities.UnitsStack stack)
    {
      Unit = stack.Unit;
      InitialCount = stack.Count;

      Refresh(false);
      
      TotalHitPoints = stack.Count * HitPoints;

      if (Unit.Perks == null) return;
      
      foreach (var perk in Unit.Perks)
      {
//        _permanentModifiers.AddRange(perk.);
      }
    }

    public MapEntities.UnitsStack ToMapUnitsStack() => new MapEntities.UnitsStack(Unit, Count);

    public void Damage(uint damage)
    {
      if (TotalHitPoints < damage)
      {
        TotalHitPoints = 0;
      }
      else
      {
        TotalHitPoints -= damage;
      }
    }

    public void Cast(Cast cast, UnitsStack target)
    {
      if (!Unit.Casts.Contains(cast)) throw new ArgumentException($"Cast not allowed: {cast}", nameof(cast));
      cast.Process(target);
    }
    
    public void UpdateAttack(uint value) => Attack = Math.Max(value, 0);
    public void UpdateDefence(uint value) => Defence = Math.Max(value, 0);
    public void UpdateInitiative(double value) => Initiative = value;

    public void Refresh(bool endRound)
    {
      HitPoints = Unit.HitPoints;
      Attack = Unit.Attack;
      Defence = Unit.Defence;
      MinDamage = Unit.MinDamage;
      MaxDamage = Unit.MaxDamage;
      Initiative = Unit.Initiative;

      if (endRound)
      {
        foreach (var modifier in _temporaryModifiers.Keys)
        {
          --_temporaryModifiers[modifier];
          if (_temporaryModifiers[modifier] == 0)
          {
            _temporaryModifiers.Remove(modifier);
          }
        }
      }

      foreach (var modifier in Modifiers())
      {
        modifier.Apply(this);
      }
    }

    public override string ToString()
    {
      return $@"<{Unit.VisualName()} [{Count}] ({LastUnitHitPoints})>";
    }
  }
}