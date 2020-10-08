using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace RecipeScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Klockan är 03:35, måste bara få detta att funka till imorgon.
            var lsit = new List<Recipe>();

            try
            {
                using (var b = new MemoryStream())
                {

                    try
                    {
                        var request = (HttpWebRequest)WebRequest.Create(@"https://www.koket.se/smorstekt-torskrygg-med-pestoslungad-blomkal-och-sparris");
                        using (var response = request.GetResponse())
                        {
                            var recipe = new Recipe();
                            var htmlDocument = new HtmlDocument();

                            using (var content = response.GetResponseStream())
                            {
                                using (var buffer = new MemoryStream())
                                {
                                    content.CopyTo(buffer);
                                    buffer.Seek(0, SeekOrigin.Begin);
                                    htmlDocument.Load(buffer);

                                    var htmlElement = htmlDocument.GetElementbyId("__NEXT_DATA__").InnerHtml;
                                    var structureData = JsonConvert.DeserializeObject<JObject>(htmlElement);

                                    JObject recipeData = structureData.SelectToken("props.pageProps.structuredData[?(@['\x40type']=='Recipe')]") as JObject;

                                    recipe.Name = recipeData["name"].ToObject<string>();
                                    recipe.Description = recipeData["description"].ToObject<string>();
                                    recipe.Image = recipeData["image"].ToObject<string>();

                                    recipe.Ingredients = new List<Ingredient>();

                                    foreach (var ingredient in recipeData["recipeIngredient"] as JArray)
                                    {
                                        var ingredientData = ((string)ingredient).Split(' ');
                                        var amountData = ingredientData[0];

                                        Ingredient ingredientToAdd;

                                        if (double.TryParse(amountData, out var amount))
                                        {
                                            var name = ingredientData.Skip(2);
                                            ingredientToAdd = new Ingredient
                                            {
                                                Amount = amount,
                                                Unit = ingredientData[1],
                                                Name = string.Join(" ", name)
                                            };

                                            recipe.Ingredients.Add(new Ingredient { A = a, U = ((string)ingredient).Split(' ')[1], Name = string.Join(" ", name) });
                                        }
                                        else
                                        {
                                            ingredientToAdd = new Ingredient { Name = (string)ingredient };
                                        }

                                        recipe.Ingredients.Add(ingredientToAdd);

                                    }

                                    recipe.Steps = new List<Step>();

                                    foreach (var instruction in recipeData["recipeInstructions"] as JArray)
                                    {
                                        //Tar bort HTML-taggar.
                                        var stripHtml = new Regex("<[^>]*(>|$)");
                                        var instructionHtml = (string)instruction["text"];
                                        var instructionText = stripHtml.Replace(instructionHtml, string.Empty);

                                        var stepToAdd = new Step
                                        {
                                            Text = instructionText.Replace("\n", " ")
                                        };
                                        recipe.Steps.Add(stepToAdd);
                                    }
                                }

                                lsit.Add(recipe);
                            }
                        }
                    }
                    catch (Exception ex)

                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }

                try
                {
                    var r = (HttpWebRequest)WebRequest.Create(@"https://www.koket.se/vegoburgare-med-tryffelmajonnas");
                    using (var rr = r.GetResponse())
                    {
                        var tmp = new Recipe();
                        var htd = new HtmlDocument();
                        using (var c = rr.GetResponseStream())
                        {
                            using (var tmp2 = new MemoryStream())
                            {
                                c.CopyTo(tmp2);
                                tmp2.Seek(0, SeekOrigin.Begin);
                                htd.Load(tmp2);
                                var d = JsonConvert.DeserializeObject<JObject>(htd.GetElementbyId("__NEXT_DATA__").InnerHtml)
                                                                .SelectToken("props.pageProps.structuredData[?(@['\x40type']=='Recipe')]") as JObject;
                                tmp.Name = (string)d["name"].ToObject(typeof(string));
                                tmp.Description = (string)d["description"].ToObject(typeof(string));
                                tmp.Image = (string)d["image"].ToObject(typeof(string));
                                tmp.Ingredients = new List<Ingredient>();
                                foreach (var tm3p in d["recipeIngredient"] as JArray)
                                {
                                    if (double.TryParse(((string)tm3p).Split(' ')[0], out var a))
                                    {
                                        var n = ((string)tm3p).Split(' ').Skip(2);
                                        tmp.Ingredients.Add(new Ingredient { A = a, U = ((string)tm3p).Split(' ')[1], Name = string.Join(" ", n) });
                                    }
                                    else
                                    {
                                        tmp.Ingredients.Add(new Ingredient { Name = (string)tm3p });
                                    }
                                }
                                tmp.Steps = new List<Step>();
                                foreach (var t4mp in d["recipeInstructions"] as JArray)
                                    tmp.Steps.Add(new Step { Tx = new Regex("<[^>]*(>|$)").Replace((string)t4mp["text"], string.Empty).Replace("\n", " ") });
                            }
                            lsit.Add(tmp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
                try
                {
                    var r = (HttpWebRequest)WebRequest.Create(@"https://www.koket.se/smakrik-o-lrisotto-med-vitlo-ksrostad-tomat-citronsparris-och-het-chorizo");
                    using (var rr = r.GetResponse())
                    {
                        var tmp = new Recipe();
                        var htd = new HtmlDocument();
                        using (var c = rr.GetResponseStream())
                        {
                            using (var tmp2 = new MemoryStream())
                            {
                                c.CopyTo(tmp2);
                                tmp2.Seek(0, SeekOrigin.Begin);
                                htd.Load(tmp2);
                                var d = JsonConvert.DeserializeObject<JObject>(htd.GetElementbyId("__NEXT_DATA__").InnerHtml)
                                .SelectToken("props.pageProps.structuredData[?(@['\x40type']=='Recipe')]") as JObject;
                                tmp.Name = (string)d["name"].ToObject(typeof(string));
                                tmp.Description = (string)d["description"].ToObject(typeof(string));
                                tmp.Image = (string)d["image"].ToObject(typeof(string));
                                tmp.Ingredients = new List<Ingredient>();
                                foreach (var tm3p in d["recipeIngredient"] as JArray)
                                {
                                    if (double.TryParse(((string)tm3p).Split(' ')[0], out var a))
                                    {
                                        var n = ((string)tm3p).Split(' ').Skip(2);
                                        tmp.Ingredients.Add(new Ingredient { A = a, U = ((string)tm3p).Split(' ')[1], Name = string.Join(" ", n) });
                                    }
                                    else
                                    {
                                        tmp.Ingredients.Add(new Ingredient { Name = (string)tm3p });
                                    }
                                }
                                tmp.Steps = new List<Step>();
                                foreach (var t4mp in d["recipeInstructions"] as JArray)
                                    tmp.Steps.Add(new Step { Tx = new Regex("<[^>]*(>|$)").Replace((string)t4mp["text"], string.Empty).Replace("\n", " ") });
                            }

                            lsit.Add(tmp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
                try
                {
                    var r = (HttpWebRequest)WebRequest.Create(@"https://www.koket.se/smorbakad-spetskal-med-krispig-kyckling-och-graddskum");
                    using (var rr = r.GetResponse())
                    {
                        var tmp = new Recipe();
                        var htd = new HtmlDocument();
                        using (var c = rr.GetResponseStream())
                        {
                            using (var tmp2 = new MemoryStream())
                            {
                                c.CopyTo(tmp2);
                                tmp2.Seek(0, SeekOrigin.Begin);
                                htd.Load(tmp2);
                                var d = JsonConvert.DeserializeObject<JObject>(htd.GetElementbyId("__NEXT_DATA__").InnerHtml)
                                .SelectToken("props.pageProps.structuredData[?(@['\x40type']=='Recipe')]") as JObject;
                                tmp.Name = (string)d["name"].ToObject(typeof(string));
                                tmp.Description = (string)d["description"].ToObject(typeof(string));
                                tmp.Image = (string)d["image"].ToObject(typeof(string));
                                tmp.Ingredients = new List<Ingredient>();
                                foreach (var tm3p in d["recipeIngredient"] as JArray)
                                {
                                    if (double.TryParse(((string)tm3p).Split(' ')[0], out var a))
                                    {
                                        var n = ((string)tm3p).Split(' ').Skip(2);
                                        tmp.Ingredients.Add(new Ingredient { A = a, U = ((string)tm3p).Split(' ')[1], Name = string.Join(" ", n) });
                                    }
                                    else
                                    {
                                        tmp.Ingredients.Add(new Ingredient { Name = (string)tm3p });
                                    }
                                }
                                tmp.Steps = new List<Step>();
                                foreach (var t4mp in d["recipeInstructions"] as JArray)
                                    tmp.Steps.Add(new Step { Tx = new Regex("<[^>]*(>|$)").Replace((string)t4mp["text"], string.Empty).Replace("\n", " ") });
                            }

                            lsit.Add(tmp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            try
            {
                for (var x = 0; x < lsit.Count; x++)
                {
                    Console.WriteLine(@$"Recept:" + " " + lsit[x].Name);
                    Console.WriteLine("-------");
                    Console.WriteLine(lsit[x].Description.Trim());
                    Console.WriteLine("-------");
                    Console.WriteLine("Ingredienser:");
                    for (var y = 0; y < lsit[x].Ingredients.Count; y++)
                    {
                        if (lsit[x].Ingredients[y].A == 0)
                            Console.WriteLine(lsit[x].Ingredients[y].Name);
                        else
                            Console.WriteLine(lsit[x].Ingredients[y].A.ToString() + " " + lsit[x].Ingredients[y].U + " " + lsit[x].Ingredients[y].Name);
                    }
                    Console.WriteLine("-------");
                    Console.WriteLine("Steg:");
                    foreach (var step in Recipe.Steps)
                    {

                    }
                    for (var z = 0; z < lsit[x].Steps.Count; z++)
                    {
                        Console.WriteLine((z + 1).ToString() + ": " + lsit[x].Steps[z].Tx);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }

    class Recipe
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
    }

    class Ingredient
    {
        public double A { get; set; }
        public string U { get; set; }
        public string Name { get; set; }
    }

    class Step
    {
        public string T1 { get; set; }
        public string Tx { get; set; }
    }
}
