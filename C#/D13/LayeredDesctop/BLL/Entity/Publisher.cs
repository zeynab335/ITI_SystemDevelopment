using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
   
    public class Publisher:EntityBase
    {
         string pub_id_val = "";
         string pub_name_val = "";
         string city_val = "" ;
         string State_val = "";
         string country_val = "";

        public string pub_id
        {
            get => pub_id_val;

            set
            {
                if (value != pub_id_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    pub_id_val = value;

                }
            }
        }

        public string pub_name
        {
            get => pub_name_val;

            set
            {
                if (value != pub_name_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    pub_name_val = value;

                }
            }
        }

        public string city
        {
            get => city_val;

            set
            {
                if (value != city_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    city_val = value;

                }
            }
        }

        // State first character small in db
        public string state
        {
            get => State_val;

            set
            {
                if (value != State_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    State_val = value;

                }
            }
        }

        public string country
        {
            get => country_val;

            set
            {
                if (value != country_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    country_val = value;

                }
            }
        }

    }
}
