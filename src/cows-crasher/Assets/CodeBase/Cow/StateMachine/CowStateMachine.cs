using System;
using System.Collections.Generic;
using CodeBase.Cow.StateMachine.States;
using CodeBase.Cow.StateMachine.States.Abstract;

namespace CodeBase.Cow.StateMachine
{
    public class CowStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _current;

        public CowStateMachine(CowBehaviour behaviour) =>
            _states = new Dictionary<Type, IState>
            {
                [typeof(CowNavigationState)] = new CowNavigationState(this, behaviour),
                [typeof(CowLevitationState)] = new CowLevitationState(this, behaviour),
                [typeof(CowRaisingState)] = new CowRaisingState(this, behaviour)
            };

        public void Enter<TState>() where TState : IState
        {
            _current?.Exit();
            _current = _states[typeof(TState)];
            _current.Enter();
        }

        public void Update(float delta)
        {
            if (_current is IUpdatableState updatable)
                updatable.Update(delta);
        }
    }
}