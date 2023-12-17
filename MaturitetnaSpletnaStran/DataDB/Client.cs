using System;
using System.Collections.Generic;

namespace MaturitetnaSpletnaStran.DataDB
{
    public partial class Client
    {
        public Client()
        {
            ClientUsers = new HashSet<ClientUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ClientUser> ClientUsers { get; set; }
    }
}
