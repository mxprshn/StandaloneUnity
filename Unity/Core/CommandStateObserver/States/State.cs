// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;

namespace Unity.CommandStateObserver
{
    /// <summary>
    /// The state holds all data that can be displayed in the UI and modified by the user.
    /// </summary>
    class State : IState, IDisposable
    {
        bool m_Disposed;

        List<IStateComponent> m_StateComponents;

        /// <summary>
        /// Delegate called when state components are added to the state or removed from the state.
        /// </summary>
        public Action<IState, IStateComponent> OnStateComponentListModified { get; set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="State" /> class.
        /// </summary>
        public State()
        {
            m_StateComponents = new List<IStateComponent>();
        }

        ~State()
        {
            Dispose(false);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of resources used by the state.
        /// </summary>
        /// <param name="disposing">When true, this method is called from IDisposable.Dispose.
        /// Otherwise it is called from the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (m_Disposed)
                return;

            if (disposing)
            {
                foreach (var stateComponent in AllStateComponents)
                {
                    if (stateComponent is IDisposable disposable)
                        disposable.Dispose();
                }
            }

            m_Disposed = true;
        }

        /// <summary>
        /// Adds a state component to the state.
        /// </summary>
        /// <param name="stateComponent">The state component to add.</param>
        public void AddStateComponent(IStateComponent stateComponent)
        {
            if (m_StateComponents.Contains(stateComponent))
                return;

            m_StateComponents.Add(stateComponent);
            stateComponent.OnAddedToState(this);
            OnStateComponentListModified?.Invoke(this, stateComponent);
        }

        /// <summary>
        /// Removes a state component from the state.
        /// </summary>
        /// <param name="stateComponent">The state component to remove.</param>
        public void RemoveStateComponent(IStateComponent stateComponent)
        {
            if (!m_StateComponents.Remove(stateComponent))
                return;

            stateComponent.OnRemovedFromState(this);
            OnStateComponentListModified?.Invoke(this, stateComponent);
        }

        /// <summary>
        /// All the state components.
        /// </summary>
        public virtual IReadOnlyList<IStateComponent> AllStateComponents => m_StateComponents;
    }
}
