﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D08
{
    
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }  
        public Book(string _ISBN, string _Title,
        string[] _Authors, DateTime _PublicationDate,
        decimal _Price)
        {
            ISBN= _ISBN;
            Title= _Title;
            Authors= _Authors;
            PublicationDate= _PublicationDate;
            Price= _Price;

        }
        public override string ToString()
        {
            return this.Title + " Author = " + string.Join(",", this.Authors) + " Price =  " + this.Price;
        }
    }


    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }
        public static string GetAuthors(Book B)
        {
            return string.Join("," , B.Authors);

        }
        public static string GetPrice(Book B)
        {
            return B.Price + "";
        }
    }


}
