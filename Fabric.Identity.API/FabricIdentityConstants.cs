﻿namespace Fabric.Identity.API
{
    public static class FabricIdentityConstants
    {
        public static readonly string ServiceName = "identityservice";
        public static readonly string FabricCorsPolicyName = "FabricCorsPolicy";
        public static readonly string ManagementApiBasePath = "/api";
        public static readonly string IdentityRegistrationScope = "fabric/identity.manageresources";
        public static readonly string IdentityReadScope = "fabric/identity.read";
        public static readonly string IdentitySearchUsersScope = "fabric/identity.searchusers";
        public static readonly string AuditEventCategory = "Audit";
        public static readonly string FabricIdentityClient = "fabric-identity-client";

        public static class PublicClaimTypes
        {
            public static readonly string UserPrincipalName = "upn";
        }

        public static class StorageProviders
        {
            public const string InMemory = "inmemory";
            public const string CouchDb = "couchdb";
            public const string SqlServer = "sqlserver";
        }

        public static class DocumentTypes
        {
            public static readonly string IdentityResourceDocumentType = "identityresource:";
            public static readonly string ClientDocumentType = "client:";
            public static readonly string ApiResourceDocumentType = "apiresource:";
            public static readonly string PersistedGrantDocumentType = "persistedgrant:";
            public static readonly string UserDocumentType = "user:";
        }

        public static class FabricClaimTypes
        {
            public static readonly string Groups = "groups";            
        }

        public static class FabricCouchDbDesignDocumentDefinitions
        {
            public static readonly string Count = @"{
                                                      ""_id"":""_design/count"",
                                                      ""language"": ""javascript"",
                                                      ""views"":
                                                      {
                                                        ""client:"": {
                                                          ""map"": ""function(doc) { if (doc._id.indexOf('client:') !== -1)  emit(doc.id, 1) }"",
                                                          ""reduce"" : ""_count""
                                                        },
                                                        ""apiresource:"": {
                                                          ""map"": ""function(doc) { if (doc._id.indexOf('apiresource:') !== -1)  emit(doc.id, 1) }"",
                                                          ""reduce"" : ""_count""
                                                        },
                                                        ""identityresource:"": {
                                                          ""map"": ""function(doc) { if (doc._id.indexOf('identityresource:') !== -1)  emit(doc.id, 1) }"",
                                                          ""reduce"" : ""_count""
                                                        }
                                                      }
                                                    }";
        }

        public static class FabricCouchDbDesignDocuments
        {
            public static readonly string Count = "count";
        }

        public static class CustomEventIds
        {
            public static readonly int EntityCreatedAudit = 15000;
            public static readonly int EntityUpdatedAudit = 15001;
            public static readonly int EntityDeletedAudit = 15002;
            public static readonly int EntityReadAudit = 15003;
        }

        public static class CustomEventNames
        {
            public static readonly string EntityCreatedAudit = "EntityCreated";
            public static readonly string EntityUpdatedAudit = "EntityUpdated";
            public static readonly string EntityDeletedAudit = "EntityDeleted";
            public static readonly string EntityReadAudit = "EntityRead";
        }

        public static class FabricExternalIdentityProviderTypes
        {
            public const string Windows = "Windows";
            public const string Oidc = "OIDC";
        }

        public static class AuthorizationPolicyNames
        {
            internal const string RegistrationThreshold = "RegistrationThreshold";
            internal const string ReadScopeClaim = "ReadScopeClaim";
            internal const string SearchUsersScopeClaim = "SearchUsersScopeClaim";
        }

        public static class ExtensionGrantTypes
        {
            public const string Delegation = "delegation";
        }

        public static class ValidationRuleSets
        {
            public const string Default = "default";
            public const string ClientPost = "ClientPost";
            public const string ApiResourcePost = "ApiResourcePost";
            public const string PrincipalSearch = "PrincipalSearch";
            public const string PrincipalIdentityProviderSearch = "PrincipalIdentityProviderSearch";
            public const string PrincipalGroupSearch = "PrincipalGroupSearch";
            public const string PrincipalSubjectSearch = "PrincipalSubjectSearch";
        }

        public static class AuthenticationSchemes
        {
            public const string Azure = "AzureActiveDirectory";
        }

        public static class SearchIdentityProviders
        {
            public const string ActiveDirectory = "Windows";
            public const string AzureActiveDirectory = "AzureActiveDirectory";
            public const string IdentityDatabase = "Identity";

            public static readonly string[] ValidIdentityProviders = { ActiveDirectory, AzureActiveDirectory };
        }

        public static class AuthenticationExceptionMessages
        {
            public const string ArgumentNullExceptionMessage = "The object name '{0}' cannot be null.";
        }

        public static class SearchTypes
        {
            public const string Exact = "exact";
            public const string Wildcard = "wildcard";
        }
    }
}
