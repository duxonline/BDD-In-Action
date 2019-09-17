using System;

namespace BddTraining.SharpArch.NHibernate
{
    public class ConnectionInfo : IComparable<ConnectionInfo>
    {
        public string ConnectionString { get; set; }
        public int Priority { get; set; }

        public int CompareTo(ConnectionInfo other)
        {
            if (Priority < other.Priority) return 1;
            if (Priority > other.Priority) return -1;
            return other.ConnectionString.ToLower().CompareTo(ConnectionString.ToLower());
        }
    }
}
