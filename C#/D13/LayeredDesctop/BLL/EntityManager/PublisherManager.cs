using BLL.Entity;
using BLL.EntityList;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManager
{
    public class PublisherManager
    {
        static DBManager manager = new DBManager();
        public PublisherManager() {
             
        }

        public static PublisherList selectAllPublishers()
        {
            try
            {
                return DataTableToTitleList(manager.ExecuteDataTable("selectAllPublishers"));
            }
            catch
            {
                return new PublisherList();
            }
        }
        // Mapping
        internal static PublisherList DataTableToTitleList(DataTable dataTable)
        {
            PublisherList publisherList = new PublisherList();
            foreach (DataRow row in dataTable.Rows)
            {
                publisherList.Add(DataRowToTitle(row));
            }
            return publisherList;
        }

        internal static Publisher DataRowToTitle(DataRow Dr)
        {
            Publisher publisher = new Publisher();

            // Mapping String Properties
            publisher.pub_id    = Dr["pub_id"]?.ToString() ?? "NA";
            publisher.pub_name  = Dr["pub_name"]?.ToString() ?? "NA";
            publisher.city      = Dr["city"]?.ToString() ?? "NA";
            publisher.state     = Dr["state"]?.ToString() ?? "NA";
            publisher.country   = Dr["country"]?.ToString() ?? "NA";


            publisher.State = EntityState.Unchanged;

            return publisher;
        }
    }
}
