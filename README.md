Arkadaşlar projede doldurulması gereken alanlar var onları kendinize göre doldurup değiştirebilirsiniz

Doldurulması gereken şeyler
    ---------------------------
    
        string Tokenendpoint = "";
        string client_id = "";
        string client_secret = "";

    Değişmesi gereken şeyler
    ------------------------
     

  SORGU GÖNDERİN
    string query = @"
            query Query($name: StringFilterInput) {
                listProductBrand(name: $name) {
                    name
                    id
                    updatedAt
                }
            }";

   FİLTRELEME YAPIN
    var variables = new
    {

        name = new
        {
            like = "40 Million"
        }

    };




isteyenler projenin çalışır halini buradan da indirebilirler
https://drive.google.com/file/d/1M07GvdLD_VFDoD5AZ7dH2VaGXyq4i6X9/view?usp=sharing
