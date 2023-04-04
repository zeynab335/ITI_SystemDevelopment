let {Reservation} = require("../Modules/FlightTicketsReservation");

let res1 =  new Reservation();
res1.displayAllTickets();
console.log("******getTicket********** ")
console.log(res1.getTicket(1));

const newData = {
    id: 1,
    seat_num: 10,
    flight_num: 10,
    departure_arrival_airports: 'airport-1',
    Travelling_date: new Date()
}
res1.updateTicket(1 , newData );
console.log(res1.getTicket(1));


