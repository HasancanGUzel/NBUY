let sonuc;
// getElementById
sonuc=document.getElementById('title');
sonuc=document.getElementById('title').id;
sonuc=document.getElementById('title').className;
sonuc=document.getElementById('title').classList;


// burada style etketleri camelCase olarak adlandırılır
document.getElementById('title').style.fontSize='70px';
document.getElementById('title').style.color='red';
// document.getElementById('title').style.display='none';


// getElementById sadece ID seçer ama query selector her elemnti seçer
//querySelector getElementById gibi ama bunda parantez içine style gibi id ye # işareti class olursa '.' işareti konur 
sonuc=document.querySelector('#title')
sonuc=document.querySelector('div')//ilk karşılatğını seçer
sonuc=document.querySelector('.h1')


sonuc=document.querySelector('li');//ilk karşılaştığını seçer
sonuc=document.querySelector('li:first-child');//first-chil ilk çocuk demek ilk elemnti seçer
sonuc=document.querySelector('li:last-child');//last-child son çocuk demek son elemnti seçer
sonuc=document.querySelector('li:nth-child(2)');//nth-child ise li lerin içinde prantez içine yazılan li yi seçer




console.log(sonuc);