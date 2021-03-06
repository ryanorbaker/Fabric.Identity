﻿using System;

namespace Fabric.Identity.API.Models
{
    /// <summary>
    /// A model to represent a DiscoveryService Registration.
    /// </summary>
    public class DiscoveryServiceApiModel
    {
        /// <summary>
        /// Gets or sets the Name of service. Used with Version to retrieve service details.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the Version of the service. Used with ServiceName to retrieve service details.
        /// Defaults to 1.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the Fully qualified url of the service.
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Indicates last time a successful request to the service was made. Used by the DiscoveryService to record the status of the service.
        /// Is not required when adding a new service.
        /// </summary>
        public DateTime? Heartbeat { get; set; }

        /// <summary>
        /// Gets or sets the type of service this is.
        /// </summary>
        public string DiscoveryType { get; set; }

        /// <summary>
        /// Gets or sets whether this service should be displayed in the all applications pages and the application switcher.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or sets the Service's friendly name.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the description of the application/service.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the the build number of the application/service.
        /// </summary>
        public string BuildNumber { get; set; }

    }
}
