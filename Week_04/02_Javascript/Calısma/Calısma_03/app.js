

// let deger = Number(prompt('bir sayı giriniz'));
// let asalMi;

// for (let i = 2; i <=deger; i++) 
// {
//     asalMi=true;
//     for (let j = 2; j < i; j++) {
//        if(i%j===0){
//         asalMi=false;
//        }
        
//     }
//     if (asalMi===true) {
//         console.log(i);
        
//     }
   
     
// }

let n=Number(prompt('bir sayı giriniz'));
nextPrime:
for (let i = 2; i <=n; i++) 
{
        for (let j = 2; j <i; j++)
        {
            if (i%j===0) {
                continue nextPrime;
            }
        }    
        console.log(i);

}
