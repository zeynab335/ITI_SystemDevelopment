using BLL.Entity;
using BLL.EntityList;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManager
{
    public class TitleManager
    {
        static DBManager manager = new DBManager();
        public TitleManager() { }

        public static bool DeleteTitle(string id)
        {
            try
            {

                Dictionary<string, object> ParamDic = new() { ["@title_id"] = id };

                return
                manager.ExecuteNonQuery("DeleteTitle", ParamDic) > 0;

            }
            catch
            {

            }
            return false;
        }


        public static bool UpdatePropertiesInTitle(string id, string prop, string propVal)
        {
            try
            {

                Dictionary<string, object> ParamDic = new() { ["@Property"] = prop, ["@PropertyValue"] = propVal, ["@title_id"] = id };

                return
                manager.ExecuteNonQuery("UpdatePropertiesInTitle", ParamDic) > 0;

            }
            catch
            {

            }
            return false;
        }

        public static bool UpdatePropertiesInTitle(Title t)
        {
            try
            {

                Dictionary<string, object> ParamDic = new()
                {
                    ["@title_id"] = t.title_id,
                    ["@title"] = t.title,
                    ["@pub_id"] = t.pub_id,
                    ["@price"] = t.price,
                    ["@advance"] = t.advance,
                    ["@royalty"] = t.royalty,
                    ["@ytd_sales"] = t.ytd_sales,
                    ["@notes"] = t.notes,

                };

                return
                manager.ExecuteNonQuery("UpdateTitle", ParamDic) > 0;

            }
            catch
            {

            }
            return false;
        }


        public static bool InsertTitle(Title t)
        {
            try
            {
 
                Dictionary<string, object> ParamDic = new() {
                    ["@title_id"]   = t.title_id ,
                    ["@title"]      = t.title,
                    ["@pub_id"]     = t.pub_id,
                    ["@price"]      = t.price ,
                    ["@advance"]    = t.advance,
                    ["@royalty"]    = t.royalty,
                    ["@ytd_sales"]  = t.ytd_sales,
                    ["@notes"]      = t.notes,

                };

                return
                manager.ExecuteNonQuery("insertNewTitle", ParamDic) > 0;

            }
            catch
            {

            }
            return false;
        }
        

        public static TitleList selectAllTitles()
        {
            try
            {
                return DataTableToTitleList(manager.ExecuteDataTable("selectAllTitles"));
            }
            catch
            {
                return new TitleList();
            }
        }

        // Mapping
        internal static TitleList DataTableToTitleList(DataTable dataTable)
        {
            TitleList titleList = new TitleList();
            foreach (DataRow row in dataTable.Rows)
            {
                titleList.Add(DataRowToTitle(row));
            }
            return titleList;
        }


        internal static Title DataRowToTitle(DataRow Dr)
        {
            Title title = new Title();

            // Maooing Int Properties
            if (int.TryParse(Dr["royalty"].ToString(), out int parseInt))
            {
                title.royalty = parseInt;
            }
            if (int.TryParse(Dr["ytd_sales"].ToString(), out parseInt))
            {
                title.ytd_sales = parseInt;
            }

            // Mapping Decimal Properties
            if (Decimal.TryParse(Dr["price"].ToString(), out Decimal parseDes))
            {
                title.price = parseDes;
            }
            if (Decimal.TryParse(Dr["advance"].ToString(), out parseDes))
            {
                title.advance = parseDes;
            }

            // Mapping String Properties
            title.title_id = Dr["title_id"]?.ToString() ?? "NA";
            title.title  = Dr["title"]?.ToString()  ?? "NA";
            title.notes  = Dr["notes"]?.ToString()  ?? "NA";
            title.pub_id = Dr["pub_id"]?.ToString() ?? "NA";
            title.type   = Dr["type"]?.ToString()   ?? "NA";

            if (DateTime.TryParse(Dr["pubdate"].ToString(),out DateTime date)){
                title.pubdate = date;
            }

            title.State = EntityState.Unchanged;

            return title;
        }

    }
}
