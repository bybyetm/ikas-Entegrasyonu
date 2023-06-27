Arkadaşlar projede doldurulması gereken alanlar var onları kendinize göre doldurup değiştirebilirsiniz

Doldurulması Gereken Şeyler
---------------------------
    
        string Tokenendpoint = "";
        string client_id = "";
        string client_secret = "";

Değişmesi Gereken Şeyler
------------------------
     

Sorgu Gönderin
------------------------

    string query = @"
            query Query($name: StringFilterInput) {
                listProductBrand(name: $name) {
                    name
                    id
                    updatedAt
                }
            }";
            
Filtreleme Yapın
------------------------

    var variables = new
    {

        name = new
        {
            like = "40 Million"
        }

    };




İsteyenler Projenin Çalışır Halini Buradan da İndirebilirler
------------------------

https://drive.google.com/file/d/1M07GvdLD_VFDoD5AZ7dH2VaGXyq4i6X9/view?usp=sharing

Faydalandığım Kaynak
------------------------

https://ikas.dev/docs/intro
