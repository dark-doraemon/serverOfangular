using System.Net;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using webapi.Models;

namespace webapi.DataAccess
{
    public class SeedData
    {
        public static void initialize(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<DatabaseContext>();//lấy service trong provider

           
            #region add user
            //nếu đã có dữ liệu
            if (!context.Users.Any())
            {
                List<User> users = new List<User>();
                users.Add(new User
                {
                    UserId = "user1",
                    FullName = "John Doe",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890",
                    Address = "123 Main St"
                });

                users.Add(new User
                {
                    UserId = "user2",
                    FullName = "Jane Smith",
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "987-654-3210",
                    Address = "456 Elm St"
                });

                users.Add(new User
                {
                    UserId = "user3",
                    FullName = "Alice Johnson",
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com",
                    PhoneNumber = "555-123-4567",
                    Address = "789 Oak St"
                });

                context.AddRange(users);
                context.SaveChangesAsync();
            }
            #endregion

            #region category and product
            if (!context.Categories.Any() && !context.Products.Any())
            {
                //đầu tiên insert category trước
                List<Category> categories = new List<Category>();
                categories.Add(new Category { CategoryId = "LT1", CategoryName = "Laptop" });
                categories.Add(new Category { CategoryId = "SP1", CategoryName = "Smartphone" });
                categories.Add(new Category { CategoryId = "PC1", CategoryName = "PC" });
                categories.Add(new Category { CategoryId = "KB1", CategoryName = "Keyboard" });
                categories.Add(new Category { CategoryId = "C1", CategoryName = "Chair"});
                categories.Add(new Category { CategoryId = "HP1", CategoryName = "Headphone"});
                categories.Add(new Category { CategoryId = "M1", CategoryName = "Mouse"});
                categories.Add(new Category { CategoryId = "R1", CategoryName = "Ram"});
                categories.Add(new Category { CategoryId = "Storge1", CategoryName = "Storge"});
                context.AddRange(categories);
                context.SaveChangesAsync();

                //sao đó lấy các category ra để làm khóa ngoại
                var laptop = (from c in context.Categories where c.CategoryId == "LT1" select c).FirstOrDefault();
                var Smartphone = (from c in context.Categories where c.CategoryId == "SP1" select c).FirstOrDefault();
                var pc = (from c in context.Categories where c.CategoryId == "PC1" select c).FirstOrDefault();
                var keyboard = (from c in context.Categories where c.CategoryId == "KB1" select c).FirstOrDefault();
                var chair = (from c in context.Categories where c.CategoryId == "C1" select c).FirstOrDefault();
                var headphone = (from c in context.Categories where c.CategoryId == "HP1" select c).FirstOrDefault();
                var mouse = (from c in context.Categories where c.CategoryId == "M1" select c).FirstOrDefault();
                var ram = (from c in context.Categories where c.CategoryId == "R1" select c).FirstOrDefault();
                var storage = (from c in context.Categories where c.CategoryId == "Storge1" select c).FirstOrDefault();
                //context.Add(new Product
                //{
                //    ProductId = "SP1",
                //    ProductName = "Laptop ASUS Vivobook 16 M1605YA MB303W",
                //    ProductDescription = "New",
                //    ProductPrice = 16000000,
                //    Category = cate1
                //});

                //context.Add(new Product
                //{
                //    ProductId = "SP2",
                //    ProductName = "Laptop gaming ASUS ROG Zephyrus Duo 16 GX650RX LO156W",
                //    ProductDescription = "New",
                //    ProductPrice = 80000000,
                //    Category = cate1
                //});


                List<Product> products = new List<Product>();
                products.Add(new Product
                {
                    ProductId = "SP1",
                    ProductName = "Laptop ASUS Vivobook 16 M1605YA MB303W",
                    ProductDescription = "New",
                    ProductPrice = 16000000,
                    Category = laptop,
                    img = "https://product.hstatic.net/200000722513/product/w800__4__b6adf66f95bd49aba55ab20bc182c633_1024x1024.png"
                }); ;
                products.Add(new Product
                {
                    ProductId = "SP2",
                    ProductName = "Laptop gaming ASUS ROG Zephyrus Duo 16 GX650RX LO156W",
                    ProductDescription = "New",
                    ProductPrice = 80000000,
                    Category = laptop,
                    img = "https://product.hstatic.net/200000722513/product/-rog-zephyrus-duo-16-gx650rx-lo156w-3_ccb92f80afab4b279e5ec8929cb13de4_fe252ffa31874b648da604eee0dcd07b_1024x1024.jpg"
                });

                products.Add(new Product
                {
                    ProductId = "SP3",
                    ProductName = "Iphone 15 pro max",
                    ProductDescription = "New",
                    ProductPrice = 35000000,
                    Category = Smartphone,
                    img = "https://cdn.viettelstore.vn/Images/Product/ProductImage/291703442.jpeg"
                });

                products.Add(new Product
                {
                    ProductId = "SP4",
                    ProductName = "PC GVN x ASUS EVANGELION 2",
                    ProductDescription = "New",
                    ProductPrice = 130230000,
                    Category = pc,
                    img = "https://product.hstatic.net/200000722513/product/gearvn-pc-gvn-x-asus-evangelion-2-2_484fbc46c2b646cda5d122a60e0f2391_grande.jpg"
                });

                products.Add(new Product
                {
                    ProductId = "SP5",
                    ProductName = "Bàn phím cơ Razer BlackWidow V4 Pro Green Switch",
                    ProductDescription = "New",
                    ProductPrice = 5890000,
                    Category = keyboard,
                    img = "https://product.hstatic.net/200000722513/product/him1_98807862c0594d25b700664a58766fba_c56c540899d44b7180f04be41e628296_3e87dfb1791c45b9afb84ebddff14282_1024x1024.png"
                });

                products.Add(new Product
                {
                    ProductId = "SP6",
                    ProductName = "Laptop ASUS Zenbook 14 OLED UX3402VA KM068W",
                    ProductDescription = "New",
                    ProductPrice = 27990000,
                    Category = laptop,
                    img = "https://cdn.tgdd.vn/Products/Images/44/309410/asus-zenbook-14-oled-ux3402va-i7-km068w-thumb-1-600x600.jpg"
                });

                products.Add(new Product
                {
                    ProductId = "SP7",
                    ProductName = "Laptop gaming Acer Predator Helios 300 PH315 55 76KG",
                    ProductDescription = "New",
                    ProductPrice = 30000000,
                    Category = laptop,
                    img = "https://product.hstatic.net/200000722513/product/76kg_1433e407838944df88bd906b57729c0a_grande.png"
                });

                products.Add(new Product
                {
                    ProductId = "SP8",
                    ProductName = "Laptop Gaming Acer Aspire 7 A715 42G R05G",
                    ProductDescription = "New",
                    ProductPrice = 14990000,
                    Category = laptop,
                    img = "https://hc.com.vn/i/ecommerce/media/GS.008961_FEATURE_98009.jpg",
                });

                products.Add(new Product
                {
                    ProductId = "SP9",
                    ProductName = "Chuột Logitech G502 X Plus LightSpeed White",
                    ProductDescription = "New",
                    ProductPrice = 3290000,
                    Category = mouse,
                    img = "https://resource.logitechg.com/d_transparent.gif/content/dam/gaming/en/products/g502x-plus/gallery/g502x-plus-gallery-1-white.png"
                });

                products.Add(new Product
                {
                    ProductId = "SP10",
                    ProductName = "Chuột Logitech G102 LightSync White",
                    ProductDescription = "New",
                    ProductPrice = 420000,
                    Category = mouse,
                    img = "https://product.hstatic.net/200000722513/product/logitech-g102-lightsync-rgb-white-1_eb113ff7e83b4289812fb9bff7034b4d_581b766edc6e402e995fd81477456742_1024x1024.jpg"
                });


                products.Add(new Product
                {
                    ProductId = "SP11",
                    ProductName = "Ghế Corsair T3 RUSH Charcoal (CF-9010029-WW)",
                    ProductDescription = "New",
                    ProductPrice = 6490000,
                    Category = chair,
                    img = "https://vn-test-11.slatic.net/p/474154a50928149949c8a6517aa24485.jpg"
                });


                products.Add(new Product
                {
                    ProductId = "SP12",
                    ProductName = "Tai nghe Corsair HS55 Wireless Core Black (CA-9011290-AP)",
                    ProductDescription = "New",
                    ProductPrice = 1590000,
                    Category = headphone,
                    img = "https://product.hstatic.net/200000722513/product/hinh-1_2735fbceb0a14ddb955bdf64b63e45b7_ac360205755f44648b50ec4bcf0a7fcd_1024x1024.gif"
                });


                products.Add(new Product
                {
                    ProductId = "SP13",
                    ProductName = "Tai nghe Logitech G PRO X 2 LIGHTSPEED Black",
                    ProductDescription = "New",
                    ProductPrice = 5490000,
                    Category = headphone,
                    img = "https://product.hstatic.net/200000722513/product/gallery-1-pro-x-2-lightspeed-gaming-headset-black_f0029215fce74bf586e710c7284d822f_1024x1024.png"
                });


                products.Add(new Product
                {
                    ProductId = "SP14",
                    ProductName = "Ram PNY XLR8 Low Profile 1x8GB 3200 DDR4",
                    ProductDescription = "New",
                    ProductPrice = 590000,
                    Category = ram,
                    img = "https://product.hstatic.net/200000722513/product/en_catalog_list_21h26_pmvs9dxnw2_a4acf0bd92c742b8b598010d58f12cbd_2b12a3ea526246c5942664b0db7b0e11.jpg"
                });


                products.Add(new Product
                {
                    ProductId = "SP15",
                    ProductName = "Bàn Phím Asus ROG Claymore II Red Switch",
                    ProductDescription = "New",
                    ProductPrice = 27990000,
                    Category = keyboard,
                    img = "https://phucanhcdn.com/media/product/45515_kec_asu_claymoreii_r_e.jpg"
                });


                products.Add(new Product
                {
                    ProductId = "SP16",
                    ProductName = "Ram PNY XLR8 Silver 1x8GB 3600 RGB",
                    ProductDescription = "New",
                    ProductPrice = 890000,
                    Category = ram,
                    img = "https://product.hstatic.net/200000722513/product/en_color_list_22d26_r9gc83djaz_3c686ea66ef2444a937c1fd51d008395_7590d1ef3eab470790dff3e9613a1a85_grande.jpg"
                });


                products.Add(new Product
                {
                    ProductId = "SP17",
                    ProductName = "Ghế DXRacer Gladiator-GB001-PVC-Black&Red-L (GC/LGB001LTC/NR)",
                    ProductDescription = "New",
                    ProductPrice = 5990000,
                    Category = chair,
                    img = "https://product.hstatic.net/200000722513/product/thumbghea_05f21065b0404ac5880b2b64601108ac_1024x1024.gif"
                });


                products.Add(new Product
                {
                    ProductId = "SP18",
                    ProductName = "Samsung Galaxy S23 Ultra 256GB",
                    ProductDescription = "New",
                    ProductPrice = 21990000,
                    Category = Smartphone,
                    img = "https://cdn.hoanghamobile.com/i/preview/Uploads/2023/02/02/image-removebg-preview-2_638109032737377121.png"
                });


                products.Add(new Product
                {
                    ProductId = "SP19",
                    ProductName = "Xiaomi 13T Pro 5G",
                    ProductDescription = "New",
                    ProductPrice = 27990000,
                    Category = Smartphone,
                    img = "https://cdn.tgdd.vn/Products/Images/42/309816/xiaomi-13t-pro-xanh-thumb-600x600.jpg"
                });


                products.Add(new Product
                {
                    ProductId = "SP20",
                    ProductName = "Samsung Galaxy Tab S9 Ultra 12GB 512GB",
                    ProductDescription = "New",
                    ProductPrice = 24990000,
                    Category = Smartphone,
                    img = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:80/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-tab-s9-xam-1_1.jpg"
                });



                context.AddRange(products);
                context.SaveChangesAsync();
            }
            #endregion
            return;
        }
    }
}


