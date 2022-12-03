function convertToShortDate(dateString) {
    const shortDate = new Date(dateString).toLocaleDateString('tr-TR') // tarihi biz formda yeni categori vs eklediğimiz zaman değişik formatta yaızyordu bizde tr dilimindeki tarihe göre ayarladık
    return shortDate;
}
//true false ilk defa formdan kaydedince veritabanına kaydetmeden ekranda gösterdiğimiz için ilk harfleri küçük geliyordu biz o ilk harfi büyük yaptık
function convertFirstLetterToUpperCase(text) {
    text = text.toString();
    const convertedText = text.charAt(0).toUpperCase() + text.slice(1).toLowerCase(); // burda dışarıdan gelen tur false yani text içinde gelen veriyi burada charAt ile (0) ilk harfi aldık ve büyükttük sonra kalan false ise alse ekiğini slice ile 0 hariç (1) indexten itibaren al dedik ve birleştirip geri döndürdük
    return convertedText;
}