let sonuc;
sonuc=Number('10.6');
sonuc=parseInt('10.6');
sonuc=parseFloat('10.6');
sonuc=parseInt('10abc');
sonuc=parseInt('10.6abc');
sonuc=parseFloat('10.6abc');

let sayi=15.468756;
sonuc=sayi.toFixed(4);// parantez içine yazmazsak sadece . kadar alır ama parantez içine hangi değeri yazarask . dan sonra o kadar değer alır ve string yapar

sonuc=sayi.toPrecision()//normalde sayının hepsini gösterir parante içine yazdığımız değere görede kaç basamak göstereceğini belirler

sonuc=Math.round(2.4);
sonuc=Math.round(2.6);

sonuc=Math.ceil(2.2);//tavana yuvarlar 3 yapar
sonuc=Math.floor(2.7);//aşşğıya yuvarlar 2  yapar

sonuc=Math.pow(2,3);
sonuc=Math.pow(5,2);

sonuc=Math.sqrt(25);
sonuc=Math.abs(-5);
sonuc=Math.min(43,56,12,8);
sonuc=Math.max(43,16,25,3);
sonuc=Math.random();//0ile 1 arasında sayı üretir
sonuc=parseInt(Math.random()*10+1);
console.log(sonuc,typeof sonuc);