
var cards = [
    "1.gif",
    "2.gif",
    "3.gif",
    "4.gif",
    "5.gif",
    "6.gif",
    "1.gif",
    "2.gif",
    "3.gif",
    "4.gif",
    "5.gif",
    "6.gif",
]

//* to make shuffle in cards array
cards.sort(() => (Math.random() > .5) ? 1 : -1);
    
//* put cards into container

for(var i=0 ; i<12;i++){
    document.querySelector('.Container').innerHTML += 
    '<div class="flippingCard">'
    + '<img src="../Images/'+cards[i] +'"/></div>'
}


//* start Defination
var isSelected=true;
//* to put cards that user is selected
var SelectedCards = [];

//* get all cards matched 
var MatchedCards = [];
var MatchedCardsIndex = 0



 //* only select two cards then check 
 function SelectCard(){
    var Cards = document.querySelectorAll('.flippingCard');

    //* Empty , user not select any cards
    for(var i=0 ; i<Cards.length ; i++){
        
        Cards[i].onclick=function(){

            if(SelectCard){
                //? in this case user can selcet first card
                if(SelectedCards.length==0){
                    SelectedCards[0] = this.firstChild;
                    this.firstChild.style.opacity = 1;
                }
                //? in this case user can selcet second card
                else if(SelectedCards.length==1){
                    SelectedCards[1] = this.firstChild;
                    this.firstChild.style.opacity = 1;

                    setTimeout(FlipCards , 500) ;

                }
                //? in this case user can't select any cards
                else{
                    SelectCard = false;
                }
            }
        }
    
    }

    
}

 //& check if two cards identical or not then show alert to user
 function FlipCards(){
    console.log(SelectedCards[0] , SelectedCards[1])
    if(SelectedCards[0].src === SelectedCards[1].src ){
        //* add all Matched cards in array to calculate num of cards that being matched
        MatchedCards[MatchedCardsIndex++] = SelectedCards[0];
        MatchedCards[MatchedCardsIndex++] = SelectedCards[1];

        alert("Corrected 👏🎉");
    }
    else{
        alert("OH No , Try Again 😟");
        SelectedCards[0].style.opacity = 0;
        SelectedCards[1].style.opacity = 0;
    }
    SelectedCards = [];
    SelectCard = true;
    console.log(MatchedCards.length)
    if(MatchedCards.length == 12){
        document.querySelector('.FinishGame').innerText = "Congratulation You Finish Memory Game 👏🎉"
        document.querySelector('.PlayAgain').innerText = "Play Again"
        document.querySelector('.PlayAgain').style.opacity = 1;
    }

}

SelectCard();









var cards = [
    "1.gif",
    "2.gif",
    "3.gif",
    "4.gif",
    "5.gif",
    "6.gif",
    "1.gif",
    "2.gif",
    "3.gif",
    "4.gif",
    "5.gif",
    "6.gif",
]

//* to make shuffle in cards array
cards.sort(() => (Math.random() > .5) ? 1 : -1);
    
//* put cards into container

for(var i=0 ; i<12;i++){
    document.querySelector('.Container').innerHTML += 
    '<div class="flippingCard">'
    + '<img src="../Images/'+cards[i] +'"/></div>'
}


//* start Defination
var isSelected=true;
//* to put cards that user is selected
var SelectedCards = [];

//* get all cards matched 
var MatchedCards = [];
var MatchedCardsIndex = 0



 //* only select two cards then check 
 function SelectCard(){
    var Cards = document.querySelectorAll('.flippingCard');

    //* Empty , user not select any cards
    for(var i=0 ; i<Cards.length ; i++){
        
        Cards[i].onclick=function(){

            if(SelectCard){
                //? in this case user can selcet first card
                if(SelectedCards.length==0){
                    SelectedCards[0] = this.firstChild;
                    this.firstChild.style.opacity = 1;
                }
                //? in this case user can selcet second card
                else if(SelectedCards.length==1){
                    SelectedCards[1] = this.firstChild;
                    this.firstChild.style.opacity = 1;

                    setTimeout(FlipCards , 400) ;

                }
                //? in this case user can't select any cards
                else{
                    SelectCard = false;
                }
            }
        }
    
    }

    
}

 //& check if two cards identical or not then show alert to user
 function FlipCards(){
    console.log(SelectedCards[0] , SelectedCards[1])
    if(SelectedCards[0].src === SelectedCards[1].src ){
        //* add all Matched cards in array to calculate num of cards that being matched
        MatchedCards[MatchedCardsIndex++] = SelectedCards[0];
        MatchedCards[MatchedCardsIndex++] = SelectedCards[1];

        alert("Corrected 👏🎉");
    }
    else{
        alert("OH No , Try Again 😟");
        SelectedCards[0].style.opacity = 0;
        SelectedCards[1].style.opacity = 0;
    }
    SelectedCards = [];
    SelectCard = true;
    console.log(MatchedCards.length)
    if(MatchedCards.length == 12){
        document.querySelector('.FinishGame').innerText = "Congratulation You Finish Memory Game 👏🎉"
        document.querySelector('.PlayAgain').innerText = "Play Again"
        document.querySelector('.PlayAgain').style.opacity = 1;
    }

}

SelectCard();








