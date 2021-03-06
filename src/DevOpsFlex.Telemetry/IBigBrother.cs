﻿namespace DevOpsFlex.Telemetry
{
    using System;
    using Core;
    using JetBrains.Annotations;

    /// <summary>
    /// Contract that provides a way to publish telemetry events for instrumentation.
    /// </summary>
    public interface IBigBrother
    {
        /// <summary>
        /// Publishes a <see cref="BbEvent"/> through the pipeline.
        /// </summary>
        /// <param name="bbEvent">The event that we want to publish.</param>
        /// <param name="correlation">The correlation handle if you want to correlate events</param>
        void Publish([NotNull]BbEvent bbEvent, object correlation = null);

        /// <summary>
        /// Forces the telemetry channel to be in developer mode, where it will instantly push
        /// telemetry to the Application Insights account.
        /// </summary>
        IBigBrother DeveloperMode();

        /// <summary>
        /// Creates a strict correlation handle for synchronous correlation.
        /// </summary>
        /// <returns>The correlation handle as an <see cref="IDisposable"/>.</returns>
        IDisposable CreateCorrelation();

        /// <summary>
        /// Flush out all telemetry clients, both the external and the internal one.
        /// </summary>
        /// <remarks>
        /// There is internal telemetry associated with calling this method to prevent bad usage.
        /// </remarks>
        void Flush();

        /// <summary>
        /// Sets the ammount of minutes to keep a lose correlation object reference alive.
        /// </summary>
        /// <param name="span">The <see cref="TimeSpan"/> to keep a lose correlation handle alive.</param>
        void SetCorrelationKeepAlive(TimeSpan span);
    }
}
