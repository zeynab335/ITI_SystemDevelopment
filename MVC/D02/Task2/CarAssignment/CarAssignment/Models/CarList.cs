using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAssignment.Models
{
    public class CarList:List<Car>
    {
        public static List<Car> carLists = new List<Car>()
        {
            new Car(){ Color= "White"  , Model="Zotye Z100 2020" , Manfacture="Company-1" , Num=205  } ,
            new Car(){ Color= "Red"  , Model="Suzuki Alto 2021\r\n" , Manfacture="Company-2" , Num=295  },
            new Car(){ Color= "Dark"  , Model="Suzuki S Presso 2021\r\n" , Manfacture="Company-3" , Num=275  },
            new Car(){ Color= "white"  , Model="C4" , Manfacture="Company-1" , Num=255  },
            new Car(){ Color= "white"  , Model="C1" , Manfacture="Company-1" , Num=208  },
            new Car(){ Color= "white"  , Model="C1" , Manfacture="Company-1" , Num=305  },

        };
    }
}