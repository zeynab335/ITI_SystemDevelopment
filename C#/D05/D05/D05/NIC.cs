using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D05
{
    enum NICType
    {
        Ethernet , TokenRing
    }
    internal class NIC
    {
        // : Manufacture, MAC Address, Type 
        string Manufacture;
        string MACAddress;
        NICType Type;

        //* Private Constractor
        NIC(string manufacture , string mACAddress, NICType type)
        {
           Manufacture = manufacture;
           MACAddress = mACAddress;
           Type = type;
        }


        public static NIC GNIC { get; } = new("Dell", "56-BF-64-0C-C7-88" , NICType.Ethernet);

        public override string ToString()
        {
            return $"manufacture = {Manufacture} \nMACAddress = {MACAddress} \nType = {Type} ";
        }
       


    }
}
