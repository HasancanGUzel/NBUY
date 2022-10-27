// let urunler=[];
// urunler[0]='samsung';
// urunler[1]='Iphone';
// urunler[123]='Xioami';



// let urunler=['Iphone','Del','Xioami','Samsung'];
// let fiyatlar=[15000,45000,25000,35000];
// let renkler=['gold','grey','black'];

// urunler.forEach((urun,i)=>{
// console.log(urun,fiyatlar[i],renkler[i]);
// });

// console.log(fiyatlar);
// console.log(renkler);
// console.log(urunler);

// let urun1=[];
// urun1[0]='Iphone 13';
// urun1[1]=25000;
// urun1[2]='gold';
// urun1[3]=true;

// let urun2=['samsung',15000,'black',false];
// let urun3=['Xioami',35000,'grey',true];

// let urunler=[urun1,urun2,urun3];
// console.log(urun1,typeof urun1);
// console.log(urun2 ,typeof urun2);
// console.log(urun3,typeof urun3);
// console.log(urunler,typeof urunler);


// let urun1='Iphone 13,25000,gold,true';
// let urun1Dizi=urun1.split(',');
// console.log(urun1,typeof urun1);
// console.log(urun1Dizi,typeof urun1Dizi);

// let ogrenciler=['Cemre','Melahat','Sema','Hasancan'];
// let sonuc;
// sonuc=ogrenciler;
// sonuc=ogrenciler.toString();
// sonuc=ogrenciler.join('/');

// ogrenciler[4]='Serhat';
// ogrenciler.push('aylin');
// ogrenciler.pop();//dizinin son elemanını siliyor


// sonuc=ogrenciler.push('aylin');//push en sona eleman ekler
// sonuc=ogrenciler.pop();
// sonuc=ogrenciler.unshift('aylin');//unshift en başa eleman ekler

// console.log(ogrenciler);
// console.log(sonuc);

    let sonuc;
    let markalar1=['mazda','honda','BMW'];
    let markalar2=['opel','renault','subaru wrx3'];
    let markalar3=['mitsubishi lancer evo'];

    console.log('markalar1: ' + markalar1);
    console.log('markalar2: ' + markalar2);
    console.log('markalar3: ' + markalar3);

    sonuc=markalar1.concat(markalar2);//concat markalar1 dizisiyle markalar2 yi birleştirdi
    sonuc=markalar1.concat(markalar2,markalar3);
    console.log('sonuc: '+sonuc);

    ikinciDizi=sonuc.splice(0,3);

    // sonuc=markalar1.splice(0,1);// splice silmek için yani hangi indexten başlıcaksın ve kaç index siliceksin
    
    // sonuc.splice(4,2);
    
    console.log('sonuc: '+sonuc);
    console.log('ikincidizi: '+ikinciDizi);
    
