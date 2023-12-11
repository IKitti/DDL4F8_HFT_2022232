using DDL4F8_HFT_2022232.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Xml;

namespace DDL4F8_HFT_2022232
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Choose an API endpoint: ");
            Console.WriteLine("1. Pet");
            Console.WriteLine("2. PetFood");
            Console.WriteLine("3. PetOwner");
            Console.WriteLine("4. Exit");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    PetEndpoint();
                    break;
                case "2":
                    PetFoodEndpoint();
                    break;
                case "3":
                    PetOwnerEndpoint();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.ReadLine();
        }

        private static void PetEndpoint()
        {
            Console.WriteLine("Choose an action: ");
            Console.WriteLine("1. Read all");
            Console.WriteLine("2. Read by id");
            Console.WriteLine("3. Create");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    PetEndpointReadAll();
                    break;
                case "2":
                    PetEndpointReadById();
                    break;
                case "3":
                    PetEndpointCreate();
                    break;
                case "4":
                    PetEndpointUpdate();
                    break;
                case "5":
                    PetEndpointDelete();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        private static void PetEndpointReadAll()
        {
            string url = "http://localhost:52326/api/pet";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = content.ReadAsStringAsync().Result;
                        myContent = FormatJSON(myContent);
                        Console.WriteLine(myContent);
                    }
                }
            }
        }

        private static void PetEndpointReadById()
        {
            Console.WriteLine("Specify the id: ");
            string id = Console.ReadLine();
            string url = "http://localhost:52326/api/pet/" + id;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = content.ReadAsStringAsync().Result;
                        myContent = FormatJSON(myContent);
                        Console.WriteLine(myContent);
                    }
                }
            }
        }

        private static void PetEndpointCreate()
        {
            Console.WriteLine("Specify the name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Specify the species: ");
            string species = Console.ReadLine();
            Console.WriteLine("Specify the title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Specify the age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Specify the petowner id: ");
            int petownerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Specify the petfood id: ");
            int petfoodId = int.Parse(Console.ReadLine());
            string url = "http://localhost:52326/api/pet";

            using (HttpClient client = new HttpClient())
            {
                var pet = new Pet
                {
                    Name = name,
                    Species = species,
                    Title = title,
                    Age = age,
                    PetownerId = petownerId,
                    PetFoodId = petfoodId
                };

                var response = client.PostAsJsonAsync(url, pet).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Pet created!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }

        private static void PetEndpointUpdate()
        {
            Console.WriteLine("Specify the id: ");
            string id = Console.ReadLine();
            Console.WriteLine("Specify the name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Specify the species: ");
            string species = Console.ReadLine();
            Console.WriteLine("Specify the title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Specify the age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Specify the petowner id: ");
            int petownerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Specify the petfood id: ");
            int petfoodId = int.Parse(Console.ReadLine());
            string url = "http://localhost:52326/api/pet/" + id;

            using (HttpClient client = new HttpClient())
            {
                var pet = new Pet
                {
                    Id = int.Parse(id),
                    Name = name,
                    Species = species,
                    Title = title,
                    Age = age,
                    PetownerId = petownerId,
                    PetFoodId = petfoodId
                };

                var response = client.PutAsJsonAsync(url, pet).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Pet updated!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }

        private static void PetEndpointDelete()
        {
            Console.WriteLine("Specify the id: ");
            string id = Console.ReadLine();
            string url = "http://localhost:52326/api/pet/" + id;
            using (HttpClient client = new HttpClient())
            {
                var response = client.DeleteAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Pet deleted!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }

        private static void PetFoodEndpoint()
        {
            Console.WriteLine("Choose an action: ");
            Console.WriteLine("1. Read all");
            Console.WriteLine("2. Read by id");
            Console.WriteLine("3. Create");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    PetFoodEndpointReadAll();
                    break;
                case "2":
                    PetFoodEndpointReadById();
                    break;
                case "3":
                    PetFoodEndpointCreate();
                    break;
                case "4":
                    PetFoodEndpointUpdate();
                    break;
                case "5":
                    PetFoodEndpointDelete();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        private static void PetFoodEndpointReadAll()
        {
            string url = "http://localhost:52326/api/food";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = content.ReadAsStringAsync().Result;
                        myContent = FormatJSON(myContent);
                        Console.WriteLine(myContent);
                    }
                }
            }
        }

        private static void PetFoodEndpointReadById()
        {
            Console.WriteLine("Specify the id: ");
            string id = Console.ReadLine();
            string url = "http://localhost:52326/api/food/" + id;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = content.ReadAsStringAsync().Result;
                        myContent = FormatJSON(myContent);
                        Console.WriteLine(myContent);
                    }
                }
            }
        }

        private static void PetFoodEndpointCreate()
        {
            Console.WriteLine("specify the pet recommendation: ");
            string petrecommendation = Console.ReadLine();
            Console.WriteLine("specify the casual food: ");
            string casualfood = Console.ReadLine();
            Console.WriteLine("specify the best food: ");
            string bestfood = Console.ReadLine();
            Console.WriteLine("specify the best food cost: ");
            int bestfoodcost = int.Parse(Console.ReadLine());
            Console.WriteLine("specify the pet food id: ");
            int petfoodid = int.Parse(Console.ReadLine());
            string url = "http://localhost:52326/api/food";

            using (HttpClient client = new HttpClient())
            {
                var petfood = new PetFood
                {
                    PetRecommendation = petrecommendation,
                    CasualFood = casualfood,
                    BestFood = bestfood,
                    BestFoodCost = bestfoodcost,
                    PetFoodId = petfoodid
                };

                var response = client.PostAsJsonAsync(url, petfood).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("PetFood created!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }

        private static void PetFoodEndpointUpdate()
        {
            Console.WriteLine("Specify the id: ");
            string id = Console.ReadLine();
            Console.WriteLine("specify the pet recommendation: ");
            string petrecommendation = Console.ReadLine();
            Console.WriteLine("specify the casual food: ");
            string casualfood = Console.ReadLine();
            Console.WriteLine("specify the best food: ");
            string bestfood = Console.ReadLine();
            Console.WriteLine("specify the best food cost: ");
            int bestfoodcost = int.Parse(Console.ReadLine());
            Console.WriteLine("specify the pet food id: ");
            int petfoodid = int.Parse(Console.ReadLine());
            string url = "http://localhost:52326/api/food/" + id;

            using (HttpClient client = new HttpClient())
            {
                var petfood = new PetFood
                {
                    Id = int.Parse(id),
                    PetRecommendation = petrecommendation,
                    CasualFood = casualfood,
                    BestFood = bestfood,
                    BestFoodCost = bestfoodcost,
                    PetFoodId = petfoodid
                };

                var response = client.PutAsJsonAsync(url, petfood).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("PetFood updated!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }

        private static void PetFoodEndpointDelete()
        {
            Console.WriteLine("Specify the id: ");
            string id = Console.ReadLine();
            string url = "http://localhost:52326/api/food/" + id;
            using (HttpClient client = new HttpClient())
            {
                var response = client.DeleteAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("PetFood deleted!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }

        private static void PetOwnerEndpoint()
        {
            Console.WriteLine("Choose an action: ");
            Console.WriteLine("1. Read all");
            Console.WriteLine("2. Read by id");
            Console.WriteLine("3. Create");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    PetOwnerEndpointReadAll();
                    break;
                case "2":
                    PetOwnerEndpointReadById();
                    break;
                case "3":
                    PetOwnerEndpointCreate();
                    break;
                case "4":
                    PetOwnerEndpointUpdate();
                    break;
                case "5":
                    PetOwnerEndpointDelete();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        private static void PetOwnerEndpointReadAll()
        {
            string url = "http://localhost:52326/api/petowner";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = content.ReadAsStringAsync().Result;
                        myContent = FormatJSON(myContent);
                        Console.WriteLine(myContent);
                    }
                }
            }
        }

        private static void PetOwnerEndpointReadById()
        {
            Console.WriteLine("Specify the id: ");
            string id = Console.ReadLine();
            string url = "http://localhost:52326/api/petowner/" + id;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = content.ReadAsStringAsync().Result;
                        myContent = FormatJSON(myContent);
                        Console.WriteLine(myContent);
                    }
                }
            }
        }

        private static void PetOwnerEndpointCreate()
        {
            Console.WriteLine("Specify the name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Specify the gender: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Specify the age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Specify the money: ");
            int money = int.Parse(Console.ReadLine());
            Console.WriteLine("Specify the pet owner id: ");
            int petownerid = int.Parse(Console.ReadLine());

            string url = "http://localhost:52326/api/petowner";
            using (HttpClient client = new HttpClient())
            {
                var petowner = new Petowner
                {
                    Name = name,
                    Sex = gender,
                    Age = age,
                    Money = money,
                    OwnerID = petownerid
                };

                var response = client.PostAsJsonAsync(url, petowner).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("PetOwner created!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }

        }

        private static void PetOwnerEndpointUpdate()
        {
            Console.WriteLine("Specify the id: ");
            string id = Console.ReadLine();
            Console.WriteLine("Specify the name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Specify the gender: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Specify the age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Specify the money: ");
            int money = int.Parse(Console.ReadLine());
            Console.WriteLine("Specify the pet owner id: ");
            int petownerid = int.Parse(Console.ReadLine());

            string url = "http://localhost:52326/api/petowner/" + id;
            using (HttpClient client = new HttpClient())
            {
                var petowner = new Petowner
                {
                    Name = name,
                    Sex = gender,
                    Age = age,
                    Money = money,
                    OwnerID = petownerid
                };

                var response = client.PutAsJsonAsync(url, petowner).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("PetOwner updated!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }

        private static void PetOwnerEndpointDelete()
        {
            Console.WriteLine("Specify the id: ");
            string id = Console.ReadLine();
            string url = "http://localhost:52326/api/petowner/" + id;
            using (HttpClient client = new HttpClient())
            {
                var response = client.DeleteAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("PetOwner deleted!");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }

        private static string FormatJSON(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
