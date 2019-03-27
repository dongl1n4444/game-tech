using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class StateMachine
{
	private State m_prevState = null;
	private State m_curState = null;
	private Dictionary<System.Type, State> states = new Dictionary<System.Type, State>();

	public void Update()
	{
			if (m_curState != null)
				m_curState.Update();
	}

	public void AddState(State state)
	{
		states[state.GetType()] = state;
	}

	public State ChangeState(System.Type stateType)
	{
		if (m_curState != null && m_curState.GetType() == stateType)
			return m_curState;

		if (!states.ContainsKey(stateType))
		{
			Debug.LogError("failed to find state > " + stateType);
			return null;
		}

		if (m_curState != null)
			m_curState.OnExit();
		m_prevState = m_curState;

		m_curState = states[stateType];
		m_curState.OnEnter();

		return m_curState;
	}
}
