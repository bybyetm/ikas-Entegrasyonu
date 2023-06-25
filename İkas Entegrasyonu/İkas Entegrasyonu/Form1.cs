using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using İkas_Entegrasyonu.Model;
using static İkas_Entegrasyonu.Model.tokenAl;

namespace İkas_Entegrasyonu
{
    public partial class Form1 : Form
    {

        string bearerToken = "";
        string endpoint = "https://api.myikas.com/api/v1/admin/graphql";
        string Tokenendpoint = "https://<Firma Adınız>.myikas.com/api/admin/oauth/token";
        string grant_type = "client_credentials";
        string client_id = "<cliend id>";
        string client_secret = "<client secret id>";

        public Form1()
        {
            InitializeComponent();
        }



        public void TokenAl()
        {
            using (HttpClient client = new HttpClient())
            {
                // İstek parametrelerini oluşturuyoruyorum
                var parameters = new Dictionary<string, string>
            {
                { "grant_type", grant_type },
                { "client_id", client_id },
                { "client_secret", client_secret }
            };

                // İstek içeriğini oluşturuyorum
                var content = new FormUrlEncodedContent(parameters);

                // POST olarak isteklerimi gönderiyorum
                var response = client.PostAsync(Tokenendpoint, content).GetAwaiter().GetResult();


                try
                {
                    // İsteğin başarılı olup olmadığını kontrol ediyorum


                    //200 ok ise yani sonuç doğru ise
                    if (response.IsSuccessStatusCode)
                    {
                        // Gelen yanıtı okuyorum
                        var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                        // Gelen yanıttan tokeni ayıklıyorum. Siz aşağıdaki gibi de yapabilirsiniz
                        // var myDeserializedClass = JsonConvert.DeserializeObject<tokenAl.TokenResponse>(responseContent);
                        // bearerToken = myDeserializedClass.access_token;

                        bearerToken = JObject.Parse(responseContent)["access_token"].Value<string>();

                        //Alına tokeni richtexboxa yazdırıyorum
                        richTextBox1.Text = bearerToken;
                    }
                    else
                    {
                        //code başarısız olduğunda gelen mesaş
                        MessageBox.Show("Request Başarısız: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    // Her hangi bir durumda oluşan hatanın yanıtı
                    MessageBox.Show(ex.Message);
                }

            }

        }



        public void MarkaGetir()
        {

            // tokeni, sorguyu ve filtreyi ayarlıyoruz

            //query ve varables in farklı tipteki yazılışları siz bu şekide de yapabilirsiniz
            //   string query = "query Query($name: StringFilterInput) { listProductBrand(name: $name) { name id updatedAt } }";
            //  string variables = "{\"name\": {\"like\": \"40 Million\"}}";


            // GraphQL sorgusu ve değişkenlerini oluşturun
            string query = @"
            query Query($name: StringFilterInput) {
                listProductBrand(name: $name) {
                    name
                    id
                    updatedAt
                }
            }";

            //varibles filtreleme için kullanılıyor like yaparsam içerir anlamına geliyor eq yaparsam eşit olduğu anlamıyor geliyor gibi.
            //Hiç bir şey yapmazsam yanı boş gönderirsem hepsini getirir
            //Gönderme bu şekilde
            /*
            var variables = new
            {

            };
            */

            var variables = new
            {

                name = new
                {
                    like = "40 Million"
                }

            };

            //json seri şekline çeviriyorum
            string json = JsonConvert.SerializeObject(variables);

            using (HttpClient client = new HttpClient())
            {
                // token

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

                // Seri haline çeviriyorum
                var variablesObject = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                // GraphQL istek oluşturuyorum
                var payload = new
                {
                    query = query,
                    variables = variablesObject
                };
                var jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                //Post istek gönderiyorum
                HttpResponseMessage response = client.PostAsync(endpoint, content).GetAwaiter().GetResult();

                // response değerini okuyrum
                string responseContent = response.Content.ReadAsStringAsync().Result;


                // gelen yanıtı istediğim gibi değiştiriyorum daha sonra onu foerach döngüsü ile parçalıyorum

                //Kaç tane olduğunu bilmek için ben sayı verdim siz istediğiniz gibi yapabilirsiniz
                int a = 0;
                var myDeserializedClass = JsonConvert.DeserializeObject<markaListele.Root>(responseContent);
                foreach (var item in myDeserializedClass.data.listProductBrand)
                {
                    //Parçalanan veriyi richtextboxa yazıyorum siz sql e alırsınız isterseniz
                    a++;
                    richTextBox1.Text += "id: " + item.id.ToString() + "\r\n";
                    richTextBox1.Text += "Name: " + item.name.ToString() + "\r\n";
                    richTextBox1.Text += "UpdatedAt: " + item.updatedAt.ToString() + "\r\n";
                    richTextBox1.Text += "Adet: " + a + "\r\n";


                }

            }
        }

        private void markaCekBtn_Click(object sender, EventArgs e)
        {
            TokenAl();

            MarkaGetir();
        }

        private void tokenAlBtn_Click(object sender, EventArgs e)
        {
            TokenAl();
        }
    }
}

/*
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


*/