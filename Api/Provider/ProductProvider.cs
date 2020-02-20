using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOOCOMMERCE_SPECFLOW.Api.Domain;
using WOOCOMMERCE_SPECFLOW.Api;
using Newtonsoft.Json.Linq;

namespace WOOCOMMERCE_SPECFLOW.Api.Provider
{
    public class ProductProvider
    {
        private HttpRequestBuilder httpBuilder = new HttpRequestBuilder();
        Product product = new Product();
        Category category = new Category();
        Image image = new Image();

        private string GetAlejandroProductBody(string name)
        {
            product.name = name;
            product.type = "simple";
            product.regular_price = "21.99";
            product.description = "InProgress";
            product.short_description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.";

            category.id = 9;
            Category[] categories = new Category[] { category };
            product.categories = categories;

            image.src = "http://demo.woothemes.com/woocommerce/wp-content/uploads/sites/56/2013/06/T_2_front.jpg";
            Image[] images = new Image[] { image };
            product.images = images;

            string output = JsonConvert.SerializeObject(product);
            return output;
        }

        public string CreateProductAlejandro()
        {
            
            string endpoint = "wp-json/wc/v3/products";
            string json = GetAlejandroProductBody("Alejandro");
            HttpResponse response = httpBuilder.SendRequest(HttpRequestBuilder.HttpWebRequestMethod.POST, endpoint,json);
            JObject responseBody = JObject.Parse(response.ResponseBody);

            return responseBody["id"].ToString();
        }

        public bool DeleteProduct(string id)
        {

            string endpoint = "wp-json/wc/v3/products/" + id;
            
            HttpResponse response = httpBuilder.SendRequest(HttpRequestBuilder.HttpWebRequestMethod.DELETE, endpoint);
            if ((response.StatusCode.ToString()).Equals("OK"))
                return true;
            return false;
        }
    }
}
