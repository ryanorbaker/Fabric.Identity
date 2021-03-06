﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fabric.Identity.API;
using Newtonsoft.Json;
using Xunit;

namespace Fabric.Identity.IntegrationTests.ControllerTests.InMemory
{
    public class IdentityResourceControllerTests : IntegrationTestsFixture
    {
        private static readonly Random Rand = new Random(DateTime.Now.Millisecond);

        public IdentityResourceControllerTests(string provider = FabricIdentityConstants.StorageProviders.InMemory) : base(provider)
        { }

        private static readonly Func<IdentityServer4.Models.IdentityResource> GetTestIdentityResource = () =>
            new IdentityServer4.Models.IdentityResource
            {
                Name = Rand.Next().ToString(),
                DisplayName = Rand.Next().ToString(),
                UserClaims = new List<string>() { Rand.Next().ToString() },
            };

        private async Task<HttpResponseMessage> CreateNewIdentityResource(IdentityServer4.Models.IdentityResource identityResource)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(identityResource), Encoding.UTF8, "application/json");
            var httpClient = await HttpClient;
            var response = await httpClient.PostAsync("/api/identityresource", stringContent);
            return response;
        }

        [Fact]
        public async Task TestAddIdentityResource_DuplicateIdFailure()
        {
            var identityResource = GetTestIdentityResource();
            var response = await CreateNewIdentityResource(identityResource);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            response = await CreateNewIdentityResource(identityResource);
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteIdentityResource_NotFound()
        {
            var httpClient = await HttpClient;
            var response = await httpClient.SendAsync(new HttpRequestMessage(new HttpMethod("DELETE"), $"/api/identityresource/resource-that-does-not-exist"));
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteIdentityResource_Success()
        {
            var identityResource = GetTestIdentityResource();
            var response = await CreateNewIdentityResource(identityResource);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            // Send POST with same Name, should return a conflict
            response = await CreateNewIdentityResource(identityResource);
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);

            var httpClient = await HttpClient;
            response = await httpClient.SendAsync(new HttpRequestMessage(new HttpMethod("DELETE"),
                $"/api/identityresource/{identityResource.Name}"));
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            response = await httpClient.SendAsync(
                new HttpRequestMessage(new HttpMethod("GET"), $"/api/identityresource/{identityResource.Name}"));
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            // Create the same IdentityResource again.
            response = await CreateNewIdentityResource(identityResource);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
