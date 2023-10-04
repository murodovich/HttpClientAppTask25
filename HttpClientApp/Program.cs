using HttpClientApp;

Console.WriteLine("Hello, World!");
CrudMethods http = new CrudMethods();
string result;
//result = await http.GetAllAsync();

//await http.PostAsync("Kitchen");
//await http.GetAllAsync();
await http.PutAsync(3, "Garment");
//result = await http.PostAsync();
//result = await http.DeleteAsync(4);
