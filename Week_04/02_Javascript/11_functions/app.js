// function selamVer() {
//     console.log('merhaba  türkiye');
    
// }
// selamVer();

// function selamVer(isim='Dünya') {
//     console.log('Merhaba ' + isim);
// }
// selamVer('ahmet');
// selamVer();

// function yasHesapla(dogumYili) {
//     return  new Date().getFullYear()-dogumYili;
    
// }
// console.log(yasHesapla(1975));
// let yas=yasHesapla(1990);
// if (yas<30) {
//     console.log('yaşınız uygun değil');
// }
// else{
//     console.log('kabul edildiniz');
// }

//Bir tutar bilgisi alıp bu tutarın kdv sini hesaplayıp geri döndüren function.

// function kdvHesapla(tutar) {
//     let sonuc=(tutar*0.18).toFixed(2);
//     return sonuc;
    
// }
// console.log(kdvHesapla(1000));

// function kdvHesapla() {
//     for (let i = 0; i <arguments.length; i++) {
       
//         console.log(arguments[i]*0.18);
//     }   
// }
// kdvHesapla(45,75,180)


//kendisine göndericilecek tutar bilgilerini kullanarak kdv leri hesaplayıp geriye hesaplanmış kdv leri için de barındırına bir dizi döndüren function.

function kdvHesapla() {
    let sonuc=[];
    let kdv=0;
    for (let i = 0; i < arguments.length; i++) {
       kdv=arguments[i]*0.18;
       kdv=kdv.toFixed(2);
       sonuc.push(kdv);
    //    sonuc[i]*kdv;
        
    }
    return sonuc;
    
}
console.log(kdvHesapla(100,500,800,700));
