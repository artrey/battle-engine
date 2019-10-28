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
    public uint LastUnitHitPoints { get; private set; }
    public uint TotalHitPoints
    {
     get => (Count - 1) * HitPoints + LastUnitHitPoints;
     set
     {
       var div = Math.DivRem(value, HitPoints, out var mod);
       if (mod == 0)
       {
         Count = (uint)div;
         LastUnitHitPoints = div > 0 ? HitPoints : 0;
       }
       else
       {
         Count = (uint)(div + 1);
         LastUnitHitPoints = (uint)mod;
       }
     }
    }
    
    public uint Capacity => Constants.STACK_MAX_CAPACITY;
    public uint Count { get; private set; }

    private readonly HashSet<IModifier> _permanentModifiers;
    private readonly Dictionary<IModifier, IModifierChecker> _temporaryModifiers;

    public IEnumerable<IModifier> PermanentModifiers
      => _permanentModifiers.OrderBy(m => m.VisualName());
    public IEnumerable<KeyValuePair<IModifier, IModifierChecker>> TemporaryModifiers
      => _temporaryModifiers.OrderBy(p => p.Key.VisualName());
    public IEnumerable<IModifier> Modifiers
      => _temporaryModifiers.Keys.Union(_permanentModifiers).OrderBy(m => m.VisualName());

    public void AddPermanentModifier(IModifier modifier)
    {
      if (modifier == null) throw new ArgumentNullException(nameof(modifier));
      _permanentModifiers.Add(modifier);
    }

    public void AddTemporaryModifier(IModifier modifier, IModifierChecker checker)
    {
      if (modifier == null) throw new ArgumentNullException(nameof(modifier));
      if (checker == null) throw new ArgumentNullException(nameof(checker));
      if (checker.Expired) throw new ArgumentException("Adding expired modifier is prohibited", nameof(checker));
      _temporaryModifiers.Add(modifier, checker);
    }

    public void RemovePermanentModifier(IModifier modifier) => _permanentModifiers.Remove(modifier);
    public void RemoveTemporaryModifier(IModifier modifier) => _temporaryModifiers.Remove(modifier);
    
    public Dictionary<string, bool> Properties = new Dictionary<string, bool>();

    public IEnumerable<BattleAction> AvailableActions(Battle battle)
      => BattleAction.AllActions.Where(a => a.Available(battle, this)).ToArray();

    public UnitsStack(MapEntities.UnitsStack stack)
    {
      Unit = stack.Unit;
      InitialCount = stack.Count;
      HitPoints = Unit.HitPoints;
      TotalHitPoints = stack.Count * Unit.HitPoints;
      
      _permanentModifiers = new HashSet<IModifier>();
      _temporaryModifiers = new Dictionary<IModifier, IModifierChecker>();

      if (Unit.Perks.Any())
      {
        foreach (var perk in Unit.Perks)
        {
          perk.Process(this);
        }
      }

      Refresh();
    }

    public UnitsStack ForecastClone(uint roundOffset)
    {
      var ret = new UnitsStack(ToMapUnitsStack());
      
      foreach (var modifier in ret.PermanentModifiers.Except(PermanentModifiers))
      {
        ret.RemovePermanentModifier(modifier);
      }
      foreach (var modifier in PermanentModifiers.Except(ret.PermanentModifiers))
      {
        ret.AddPermanentModifier(modifier);
      }
      
      foreach (var p in _temporaryModifiers)
      {
        ret.AddTemporaryModifier(p.Key, p.Value.Clone());
      }

      while (roundOffset > 0)
      {
        foreach (var modifier in ret.TemporaryModifiers)
        {
          modifier.Value.Process();
          if (modifier.Value.Expired)
            ret.RemoveTemporaryModifier(modifier.Key);
        }
        --roundOffset;
      }
      
      ret.Refresh();

      return ret;
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

    public void UpdateModifiers()
    {
      foreach (var p in _temporaryModifiers.AsEnumerable())
      {
        p.Value.Process();
        if (p.Value.Expired)
          _temporaryModifiers.Remove(p.Key);
      }
    }

    public void Refresh()
    {
      HitPoints = Unit.HitPoints;
      Attack = Unit.Attack;
      Defence = Unit.Defence;
      MinDamage = Unit.MinDamage;
      MaxDamage = Unit.MaxDamage;
      Initiative = Unit.Initiative;

      foreach (var modifier in Modifiers)
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