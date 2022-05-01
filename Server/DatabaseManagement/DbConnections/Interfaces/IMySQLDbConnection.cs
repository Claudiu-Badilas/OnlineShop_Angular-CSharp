using System.Data;

namespace Server.DbConnections {
    public interface IMySQLDbConnection {
        public IDbConnection Connect();
    }
}
