/*
        EcmaScript (ES)
        Değişkenler tanımlanırken 3 faklı keyword kullanılabilir
        1) var
        2) let
        3) const(sabit)

        - ES6 ile birlikte aetık modern javascript tabiri kullanılmaya başlanmıştır
        bu süreçte let ve const kullanın var kullanmaktan kaçının.

        -JS te değişken tanımlanırken tip belitrilmez.
        -Bu değişkenlerin tipi olmadığı anlamına gelmez.
        -JS motoru bir değişkene değer atanması esnasında o değere göre tipi velirler.
        -Eğer henüz bir değişkene değer atanmamışsa undefined olarak belirlenir.
        log ve clg console.log kısayolu

*/

// let yas=20;
// console.log(yas);

// let ad='Geç kalan sema';
// let soyad='geç kalan harun';
// console.log(ad);
// console.log(soyad);
// console.log(ad,soyad);

// let firstname='serhat';
// let lastname='kaya';
// console.log(firstname+' '+lastname);

// let sayi1=15;
// let sayi2=25;
// let sayi3=35;
// let s1=15,s2=45,s3=55;  // yan yana değer tanımlama
// let sayi=25, // buda üsttekinin aynısı daha okunuru
//     say2=55,
//     say3=48;


// let durum=true;
// let durum2=false;
// console.log(durum,durum2);

// sayi1=125;
// console.log(sayi1);

// const benimdogumyilim=2000;
// console.log('Benim doğum yılım:'+ benimdogumyilim);

/*

bildiğiniz değişken isimlendirme yöntemlerini bura da da kullanabilirsiniz
değişkenleri genellikle camelCase ile isimlendirebilrisiniz
Değişken isminde harf rakam $ ve _ olabilir
Değişken ismi ramakla başlayamaz
Reserved Keyword ler değişken adı olarak kullanılmaz

Const sabit değerleri tutumak için kullanılır genellikle tamamen büyük harf ile isimlendirilir

const PI_SAYISI=3.14;
const _PI_SAYISI=3.14; gibi
*/

// const RENK_1='Sarı';
// const RENK_2='Kırmızı';
// let renk_3="pink";
// console.log(RENK_1,RENK_2,renk_3);



    // ******************************** DATA TYPES *************************************

    // **************************************** 1 NUMBER **************************************************

    // let sayi1=100;
    // console.log(sayi1);
    // //sayi1 in tipini öğrenmek için typeof kullandık
    // console.log(typeof sayi1);
    // console.log(typeof(sayi1));
    // let sayi2=17.5;
    // console.log(sayi2,typeof sayi2);

    // let sayi3=25/0;
    // console.log(sayi3,typeof sayi3);

    // let sayi4='okul'/25;
    // console.log(sayi4,typeof sayi4);


    // // sayıların hepsini görebilmek için bigint yapmamız lazım bunu içinde sayının sonudan n koymamız lazım
    // let sayi5=999999999999999999999999999999999999999999999999915484852647623473648276293870293813810918424n;
    // console.log(sayi5,typeof sayi5);

    // let sayi6=sayi5*99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999n;
    // console.log(sayi6,typeof sayi6);


    // *************************************** STRİNG *************************************************

    /*
        String ifadeler üç farklı şekilde ifade edilebilir.
        1) Tek tınrka ile( '' )
        2) çift tırnak ile ("")
        3) backticks (``)
           
    */

        // let ad= "'engin'";
        // let soyad='\'niyazi\'';
        // let adSoyad=ad+" "+ soyad;
        // console.log(adSoyad);

        // let adres ='halit ağa mahallesi\nsütlü nuriye sok\ncandaş apt\nzno:21 bjk';
        // console.log(adres);

        // let adSoyad='Hasancan Güzel';
        // let yas=22;
        // let kanGrubu='AbRh+';
        // let kilo=558;
        // let cinsiyet='erkek';

        // console.log('sayın:'+ adSoyad+', '+ yas+'yaşındasınız.\n Kilo:'+ kilo+'\n KanGrubu:'+kanGrubu+'\n Cinsiyet:'+cinsiyet+'\n\n\n');

        // // `` bu işaret arasında yazdığımız zaman istedğimiz şekli verebiirirz aşşağıya inmek için \n koymak yerine bunun içine yazabiliriz.
        // console.log(`Sayın ${adSoyad},${yas} yaşındasınız.
        // Kilo:${kilo},
        // Kan Grubu:${kanGrubu},
        // Cinsiyet:${cinsiyet}`);

        //********************************  BOOLEAN **********************************
        // let durum=true;
        // console.log(durum,typeof(durum));
        // let ad='Halil';
        // console.log(ad,typeof(ad));



        //******************************** */ null, undifined ***********************
        // let yas;
        // yas=null;
        // yas=12/0;
        // console.log(yas,typeof(yas));

        // JS de char diye bir tip yoktur.


        //********************* CONVERT DATA TYPES ******************************
        // let durum=true;
        // console.log(durum,typeof(durum));

        // let metin='durumunuz '+ durum +' şeklindedir.';
        // console.log(metin,typeof(metin));
        // //Strng ile parantez içine yazılan değer veya değişken string e dönüşür
        // let durumMetin=String(durum);
        // console.log(durumMetin,typeof durumMetin);

        // let sayi=25;
        // let metin2=sayi+'yaşındasınız';
        // console.log(metin2,typeof(metin2));

        // let sayiMetin=String(sayi);
        // console.log(sayiMetin,typeof(sayiMetin));


        // let metinSayi='455';
        // console.log(metinSayi ,typeof(metinSayi));
        // // Number ise int değerine  yani sayı değerine dönüştürmeyi sağlar
        // let metinSayiNumber=Number(metinSayi);
        // console.log(metinSayiNumber,typeof(metinSayiNumber));

        // let sayiMetin='     145    ';
        // console.log(sayiMetin, typeof(sayiMetin));
        // let sayi=Number(sayiMetin);
        // console.log(sayi,typeof(sayi));
        // number--->2 üzeri 53-1
        // let sayi=1254n;
        // console.log(sayi,typeof(sayi));


        // console.log(Number(true));
        // console.log(Number(false));

        // Boolean sadece sayısal değer olan 0 ı false olarak alır ama diğer bütün sayıları veya stringleri bile true alır
        // console.log(Boolean(0));
        // console.log(Boolean(1));
        // console.log(Boolean(458451));
        // console.log(Boolean(-4685123));
        // console.log(Boolean('0'));


        let a;
        a=''+1+0; console.log(a,typeof a);// string ile sayısal değerin yanında + olduğu için birleştiriyor o yüzden string oluyor
        a=''-1+0; console.log(a,typeof a);// burada ise stringle -1 olunca + olmadığı için birleştirme yapmıyor sonradan -1+0 değeri -1  ve number oluyor '' içinde string yani a bc gibi değer olsa NaN olurdu '' içinde sayı olsaydı number ve toplama çıkarma işlemi yapardı
        a=true+false; console.log(a ,typeof a);// true 1 false 0 true+false 1 çıkıyor ve number
        a=6 /'3'; console.log(a,typeof a);//  / işlemi olduğu için ve tırkanj içide sayı olduğu için böldü + olsaydı birleştrirdi veya '3' yerine'3a'olsaydı hata verirdi yani NaN OLURDU
        a=4+5+'px'; console.log(a,typeof a);// ilk önce 4+5 topluyor numberlar sonra 9+'px değerini  birleştirip string yapıyor
        a='$'+4+5; console.log(a,typeof a);// ilk önce string ifade ve sonrakileride + olduğu için birleştiriyor ve string oluyor
        a='4px'-2; console.log(a,typeof a);//burada ilk string değer olduğu için ve sonraki işlem- olduğu için hata verir ve NaN NUMBER OLUR
        a='    -9    '+5; console.log(a ,typeof a);//string ifadeyle + olduğu için birleştiriyor
        a=null+1; console.log(a,typeof a);//boş + 1 1 oluyor ve number
        a=undefined+1; console.log(a,typeof a);//undifined içinde değerin ne olduğu belli değil o yüzden NaN çıkıyor ama NUMBER

        


       


        















