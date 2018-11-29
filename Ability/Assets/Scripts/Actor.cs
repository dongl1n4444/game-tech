using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IAbilityTarget, IAbilityCaster
{
//    public AbilitySlot[] abilitySlots = new AbilitySlot[4];
//    public bool isPlayerControl;

	// private int curSelectAbilitySlotIndex = -1;
    // private AbilitySlot targetAbilitySlot = null;

	public Action<Actor> onTurnStart;
	public Action<Actor> onTurnFinish;

	public int actionPoint { get; set; }
	// public int bonusActionPoint { get; set; }
    public bool isActionTurn { get; set; }
	public List<Effect> effects = new List<Effect>();

	// public Bonus bonus = new Bonus();
	// public List<Bonus> bonuses = new List<Bonus>();

	public bool isActionForbid
	{
		get
		{
			for (int i = 0; i < effects.Count; ++i)
			{
				Effect eff = effects[i];
				if (eff.isActionForbid)
					return true;
			}
			return false;
		}
	}

	void Awake()
    {
		actionPoint = 1;
        isActionTurn = false;

//        for (int i = 0; i < abilitySlots.Length; ++i)
//        {
//            abilitySlots[i] = new AbilitySlot();
//            abilitySlots[i].caster = this;
//        }

        //
        // Fireball abilityFireball = new Fireball();
        // abilitySlots[0].SetAbility(abilityFireball);

        // targetAbilitySlot = abilitySlots[0];
    }

    public virtual void Tick(float dt)
    {
    }

	public virtual void TickRound()
	{
		// handle effect
		foreach (var effect in effects)
		{
		}
	}

    public virtual bool CanAttack(){ return false; }

    public virtual void Selected(IAbilityCaster caster, Ability ability){}

	public virtual void ApplyEffect(Effect effect)
	{
		Debug.Assert(effects.Contains(effect) == false, "CHECK");
		effects.Add(effect);

		// update bonus
		// bonusActionPoint += effect.bonusActionPoint;
		// bonus.isActionForbid |= effect.bonus.isActionForbid;
		// bonuses.Add(effect.bonus);
	}

	public virtual void RemoveEffect(Effect effect)
	{
		Debug.Assert(effects.Contains(effect) == true, "CHECK");
		effects.Remove(effect); 
	}

	public virtual void TakeDamage(int damage)
	{
	}

    public virtual void StartTurn()
	{
		if (isActionForbid)
		{
			FinishTurn();
			return;
		}

		isActionTurn = true;

		if (onTurnStart != null)
			onTurnStart(this);
	}

    protected virtual void FinishTurn()
	{
        isActionTurn = false;

		if (onTurnFinish != null)
			onTurnFinish(this);
	}
}
