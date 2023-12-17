using System;
using System.Collections.Generic;

namespace MaturitetnaSpletnaStran.DataDB
{
    public partial class ClientUser
    {
        public int Id { get; set; }
        public int? IdClient { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual Client? IdClientNavigation { get; set; }
    }
}
