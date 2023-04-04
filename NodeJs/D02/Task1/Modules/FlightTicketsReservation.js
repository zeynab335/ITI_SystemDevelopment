let today = new Date();
class Reservation{
    
    #seat_num;
    #id;

    #flight_num;
    #departure_arrival_airports;
    #Travelling_date;

    All_Tickets = [
        {id : 1 , seat_num: 1 ,flight_num:1 , departure_arrival_airports:"airport-1" ,Travelling_date: today  },
        {id : 2 , seat_num: 2 ,flight_num:2 , departure_arrival_airports:"airport-2" ,Travelling_date: today  },
        {id : 3 , seat_num: 2 ,flight_num:2 , departure_arrival_airports:"airport-3" ,Travelling_date: today  }

    ];
  
    displayAllTickets(){
        this.All_Tickets.forEach(element => {
            console.log(element)
        });
    }

    getTicket(id){
        return this.All_Tickets.filter(t=>t.id == id);
    }
    updateTicket(id , data){
        let index ;
        this.All_Tickets.map((t , i)=>{
            if(t.id==id){
                index = i;
            }
        }
        );          
      
        this.All_Tickets[index] = data;
    }
}

module.exports = {
    Reservation
}