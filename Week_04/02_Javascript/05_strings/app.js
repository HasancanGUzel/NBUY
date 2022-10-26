let ders='Bahçeşehir Üniversitesi Wissen Akademie Iğdır';
let sonuc;
// sonuc=ders.toLowerCase();
// sonuc=ders.toLocaleLowerCase();// büyük I yı küçük İ yapıyordu bu satır türkçe karaktere uygun çeviriyor
// sonuc=ders.toUpperCase();
// sonuc=ders.toLocaleUpperCase();//toLocaleLowerCase il aynı büyük hali


// sonuc=ders.length;
// sonuc=ders[0];
// sonuc=ders[44];
// // slice başlangıç indexi ve bitiş indexi arasındaki harfleri alır yani 0 index ile 10 index arasındaki leri alır
// sonuc=ders.slice(0,10);
// sonuc=ders.slice(20,25);
// //5 indexten başlatıp 20. indexe kadar olanı alıyor
// // içindeki küçük indexten başlyapı büyük değere kadar gidiyor
// sonuc=ders.substring(20,10);

// sonuc=ders.replace(' ','-');//ilk gördüğü boşluğu - ile değiştirir
// sonuc=ders.replace('Iğdır','İstanbul')

// sonuc=ders.trim();//boşlukları kaldırı
// sonuc=ders.trimEnd();
// sonuc=ders.trimStart();
// //indexof içindeki değere göre cümledeki ilk yerini bulup söyler
// sonuc=ders.indexOf('a');
// sonuc=ders.toLocaleLowerCase().indexOf('a');

// sonuc=ders.split(' ');
// console.log(sonuc[3]);

// console.log(sonuc);

// kullanıcıdan girdiği bir cümlenin kaç sözcüklerden oluştuğunu bulunuz.
// let metin=prompt('cümle gir');
// let sozcukDizisi=metin.split(' ');
// console.log(sozcukDizisi.length);

// cümlenin içinde bu kelime geçiyormu ona bakar büyük küçük harf duyarlı
sonuc=ders.includes('Akademie');
sonuc=ders.startsWith('H');// başlangıcı bu harfle başlıyromu bakıyor
sonuc=ders.endsWith('Iğdır');// bitişi bu harfle biriyormu bakıyor





console.log(sonuc);




