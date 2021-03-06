﻿using Fabric.Identity.API.Persistence.CouchDb.Configuration;
using Fabric.Identity.API.Persistence.SqlServer.Configuration;
using Fabric.Platform.Shared.Configuration;

namespace Fabric.Identity.API.Configuration
{
    using System.Collections.Generic;

    public class AppConfiguration : IAppConfiguration
    {
        public string IssuerUri { get; set; }
        public bool LogToFile { get; set; }
        public string ClientName { get; set; }
        public string RegistrationAdminGroup { get; set; }
        public bool AllowLocalLogin { get; set; }
        public bool WindowsAuthenticationEnabled { get; set; }
        public bool AzureAuthenticationEnabled { get; set; }
        public bool UseDiscoveryService { get; set; }
        public string DiscoveryServiceEndpoint { get; set; }
        public string DomainName { get; set; }
        public IdentityProviderSearchSettings IdentityProviderSearchSettings { get; set; }
        public SigningCertificateSettings SigningCertificateSettings { get; set; }
        public ElasticSearchSettings ElasticSearchSettings { get; set; }
        public HostingOptions HostingOptions { get; set; }
        public CouchDbSettings CouchDbSettings { get; set; }
        public ExternalIdProviderSettings ExternalIdProviderSettings { get; set; }
        public AzureActiveDirectorySettings AzureActiveDirectorySettings { get; set; }
        public IdentityServerConfidentialClientSettings IdentityServerConfidentialClientSettings { get; set; }
        public AzureActiveDirectoryClientSettings AzureActiveDirectoryClientSettings { get; set; }
        public ApplicationInsights ApplicationInsights { get; set; }
        public LdapSettings LdapSettings { get; set; }
        public FilterSettings FilterSettings { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        
    }
}
