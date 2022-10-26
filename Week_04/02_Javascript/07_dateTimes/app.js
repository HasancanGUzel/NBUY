let simdi=new Date();
let sonuc=simdi;
sonuc=simdi.getDate();// ayın gününü getiriyor 26 sı mesela
sonuc=simdi.getDay();//haftanın kaçını günü 3 çarşamba
sonuc=simdi.getFullYear();//yılı veriyor
sonuc=simdi.getHours();//saati veriyor sadece sat kısmını 17 yani akşam 5
sonuc=simdi.getTime();//tarih seri numarası

simdi.setFullYear(2015);//sadece yılı değiştirdik diğer bilgiler doğru
simdi.setMonth(0);//ayıda değiştrdik
sonuc=simdi


let suAn=new Date();
sonuc=suAn;
let kacyilsonra=1;
sonuc=new Date(suAn.setFullYear(suAn.getFullYear()+kacyilsonra));


simdi=new Date();
sonuc=simdi;
let dogumTarihi=new Date(2000,7,18);
sonuc=simdi.getFullYear()-dogumTarihi.getFullYear();

let milisecond=simdi-dogumTarihi;
let second=milisecond/1000;
let minute=second/60;
let hour=minute/60;
let day=hour/24;
sonuc=parseInt(day);

console.log(dogumTarihi);
console.log(sonuc);