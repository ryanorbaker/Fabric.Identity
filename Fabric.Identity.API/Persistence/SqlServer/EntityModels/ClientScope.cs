﻿namespace Fabric.Identity.API.Persistence.SqlServer.EntityModels
{
    public class ClientScope
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Scope { get; set; }

        public virtual Client Client { get; set; }
    }
}
