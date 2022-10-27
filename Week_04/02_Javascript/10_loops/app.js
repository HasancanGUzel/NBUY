

    ///******************************* WHİLE ***************************
    // let i=0;
    // while (i<10) {
    //     i++;
    //     console.log(i+ '.javascript');
    // }

    // ************************* DO WHİLE *********************
    // let i=0;
    // do {
    //     i++;
    //     console.log(i+'.JS');
    // } while (i<10);


    // ********* FOR *********

    // let sayi=10
    // for (let i = 0; i <= sayi; i++)
    //  {
    //    console.log(i+1+'JS');
        
    // }

    //1-10 arasındaki sayıları toplayıp ekrana yazan program
    // let toplam=0;
    // for (let i = 1; i <=10; i++) {
        
    //     toplam=toplam+i;
    //     console.log(' for ile '+ toplam);
    // }

    // let j=1;
    // let toplam2=0;
    // while (j<=10) {
    //     toplam2+=j;
    //     j++;
    //     console.log('while ile' + toplam2);
    // }

    // kullanıcın gireceği 3 sayıyı toplatan programı for ile yapınız.
    // let toplam=0;
    // for (let i = 1; i <=3 ; i++) {
    //     let a=prompt(i+'. sayıy giriniz');
    //     a=Number(a);
    //     toplam+=a;
    // }
    // console.log(toplam);

    // kullanıc 0 girene kadar girilen sayıları toplayıp ekran yazan program
//    let toplam=0;
//    let a;
//    let i=0;
//     do {
//         i++;

//        a=prompt(i + '.sayı giriniz');
//         a=Number(a);
//         toplam+=a;
        
//     console.log(toplam);


//     } while (a!=0);
//      console.log('yandın çık toplam==='+ toplam);
    
    

    // let toplam=0;
    // let a;
    // let i=1;
    // while (a!=0) {
    //     a=Number(prompt(i + '. sayıyı gir'));
    //     if (i==0) {
    //         break;
            
    //     }
    //     else{
    //         toplam+=a;
    //         console.log(toplam);
    //     }
        
    // }


    //  let toplam=0;
    // let a;
    

    // for (let i = 1; i <999999999999; i++)
    //  {
    //     a=Number(prompt(i + '. sayıyı gir.'));
    //     if (a==0) {
    //         break;
    //     } else {
    //         toplam+=a
    //         console.log(toplam);
    //     }
    // }


    //son örnekteki girilen sayılarıda sonuçta yazdıralım.
    
    //    let toplam=0;
    //    let i=0;
    //    let  sayilar=[];
    //     do {
    //        sayilar[i]=Number(prompt(i+1 + '.sayı giriniz'))
    //        toplam+=sayilar[i];
    //        i++;

    //     } while (sayilar[i-1]!=0);
    //     sayilar.pop();
    //     for (let i = 0; i <sayilar.length; i++) {
    //         console.log(i+1 +'. sayı: '+ sayilar[i]);
            
    //     }
    //      console.log('yandın çık toplam==='+ toplam);
         

    //Kullanıcın istedği kadar sayı girmesini sağlayın sayı girişi bitişi için 0 a basılması gereksin
    //0 a basılıp sayı girişi bittiğinde kullanıcıya şu soruyu sorun: Tek mi Çiftmi
    // Kullanıcı tek derse: tek sayıları ve toplamlarını
    //Çift derse : çift sayıları ve toplamlarını ekrana yazdırsın.


    let sayi;
    let sayilar=[];
    let toplam=0;
    let i=0;
    let tur;
    do {
        sayilar[i]=Number(prompt(i + 1 +'. sayı: '));
        i++;
    } while (sayilar[i-1]!=0);
    sayilar.pop();

        let sonucDizi=[];
       let cevap=prompt('Tek mi Çift mi') ;
       console.log(cevap,typeof cevap);
       if (cevap.toLocaleLowerCase()=='tek') {
        tur='Tek';
        for (let i = 0; i < sayilar.length; i++) {
           if (sayilar[i]%2===1) {
            sonucDizi.push(sayilar[i]);
            toplam+=sayilar[i];
           }
        }
       }
       else if (cevap.toLocaleLowerCase()=='çift') {
        tur='Çift';
        for (let i = 0; i < sayilar.length; i++) {
            if (sayilar[i]%2===0) {
             sonucDizi.push(sayilar[i]);
            toplam+=sayilar[i];

            }
         }
       }
       else{
        console.log('lütfen Tek yada Çift yaz');
       }
       console.log(sayilar);
       console.log(tur+' sayılar:'+sonucDizi);
       console.log(tur +'sayıların toplamı'+toplam);


   

