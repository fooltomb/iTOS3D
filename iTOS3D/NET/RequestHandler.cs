using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTOSeunm;
using iTOS3D.DAO;
using MySql.Data.MySqlClient;

namespace iTOS3D.NET
{
    public class RequestHandler
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
            _handlers.Add(RequestCode.Lubrication, LubricationHandler);
            _handlers.Add(RequestCode.None, DefaultHandler);
            _handlers.Add(RequestCode.SpotInspection, SpotInspectionHandler);
            _handlers.Add(RequestCode.Alert, AlertHandler);
            _handlers.Add(RequestCode.Status, StatusHandler);
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
            //TODO这里先解析data，再看用什么方法
            MaintenanceDAO.GetMaintenanceInfo(conn, server.SendMessage);
        }
        private void LubricationHandler(byte[] data)
        {
            //TODO
        }
        private void SpotInspectionHandler(byte[] data)
        {
            //TODO
        }
        private void StatusHandler(byte[] data)
        {
            //TODO
        }
        private void AlertHandler(byte[] data)
        {
            //TODO
        }
        private void DefaultHandler(byte[] data)
        {
            //TODO
        }
        #endregion
    }
}
