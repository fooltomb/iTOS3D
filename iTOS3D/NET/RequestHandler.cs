using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTOSeunm;
using MySql.Data.MySqlClient;

namespace iTOS3D.NET
{
    class RequestHandler
    {
        Dictionary<RequestCode, Action<byte[]>> _handlers;

        MySqlConnection conn;
        Server server;

        public RequestHandler(MySqlConnection conn,Server server)
        {
            this.conn = conn;
            this.server = server;
            _handlers = new Dictionary<RequestCode, Action<byte[]>>();
            _handlers.Add(RequestCode.Maintenance, MaintenanceHandler);
        }

        public void ChooseHandlerToHandle(byte[] data)
        {
            RequestCode requestCode = (RequestCode)BitConverter.ToInt32(data, 0);
            Action<byte[]> handler;
            if (_handlers.TryGetValue(requestCode, out handler))
            {
                handler(data);
            }
        }
        #region handlers
        private void MaintenanceHandler(byte[] data)
        {
            //TODO
        }
        #endregion
        RequestCode abc =RequestCode.Maintenance;
    }
}
