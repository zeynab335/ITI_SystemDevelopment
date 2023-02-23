using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{

    public class Title:EntityBase
    {
        // fields
        private string title_id_val;
        private string title_val;
        private string type_val;
        private string pub_id_val;
        private string notes_val;
        private decimal? price_val;
        private decimal? advance_val;
        private int? royalty_val;
        private int? ytd_sales_val;

        private DateTime pubdate_val;

        public string title_id { 
            get => title_id_val;
            
            set
            {
                if(value != title_id_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    title_id_val = value;

                }
            } 
        }
        public string title {
            get => title_val;

            set
            {
                if (value != title_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    title_val = value;

                }
            }
        }
        // type => 12 character
        public string type {
            get => type_val;

            set
            {
                if (value != type_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    type_val = value;

                }
            }
        }
        public string pub_id {
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
        public decimal? price {
            get => price_val;

            set
            {
                if (value != price_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    price_val = value;

                }
            }
        }
        public decimal? advance {
            get => advance_val;

            set
            {
                if (value != advance_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    advance_val = value;

                }
            }
        }
        public int? royalty {
            get => royalty_val;

            set
            {
                if (value != royalty_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    royalty_val = value;

                }
            }
        }
        public int? ytd_sales {
            get => ytd_sales_val;

            set
            {
                if (value != ytd_sales_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    ytd_sales_val = value;

                }
            }
        }
        public string notes {
            get => notes_val;

            set
            {
                if (value != notes_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    notes_val = value;

                }
            }
        }
        public DateTime pubdate {
            get => pubdate_val;

            set
            {
                if (value != pubdate_val)
                {
                    if (State != EntityState.Added)
                        // change State [update]
                        State = EntityState.Changed;
                    pubdate_val = value;

                }
            }
        }


        public Title() { 
            
        }
    }
}
