// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;

namespace Unity.CommandStateObserver
{
    /// <summary>
    /// Interface for state components.
    /// </summary>
    interface IStateComponent
    {
        /// <summary>
        /// The current version of the state component.
        /// </summary>
        uint CurrentVersion { get; }

        /// <summary>
        /// Purges the changesets that track changes up to and including <paramref name="upToAndIncludingVersion"/>.
        /// </summary>
        /// <remarks>
        /// The state component can choose to purge more recent changesets.
        /// </remarks>
        /// <param name="upToAndIncludingVersion">Version up to which we should purge changesets. Pass uint.MaxValue to purge all changesets.</param>
        void PurgeObsoleteChangesets(uint upToAndIncludingVersion);

        /// <summary>
        /// Gets the type of update an observer should do.
        /// </summary>
        /// <param name="observerVersion">The last state component version observed by the observer.</param>
        /// <returns>Returns the type of update an observer should do.</returns>
        UpdateType GetObserverUpdateType(StateComponentVersion observerVersion);

        /// <summary>
        /// Called when the state component has been added to the state.
        /// </summary>
        /// <param name="state">The state to which the state component was added.</param>
        void OnAddedToState(IState state);

        /// <summary>
        /// Called when the state component has been removed from the state.
        /// </summary>
        /// <param name="state">The state from which the state component was removed.</param>
        void OnRemovedFromState(IState state);
    }
}
