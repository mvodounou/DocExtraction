using System.Text.Json;
using Document.WorkFlow.Contracts;
using Document.WorkFlow.Models;
using Document.WorkFlow.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<IDocumentService, DocumentService>())
    .Build();

//IConfiguration Config = new ConfigurationBuilder()
//                .AddJsonFile("appsettings.json")
//                .Build();


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Started");

var documentService = new DocumentService();

IEnumerable<Supplier>? tempDataCollection = null;

documentService.ExtractData<Supplier>(filePaths: new List<string> { "Suppliers.csv" }, out tempDataCollection);

//Console.WriteLine(JsonSerializer.Serialize(tempDataCollection));

//Console.WriteLine(JsonSerializer.Serialize(tempDataCollection.ToList()));

await documentService.LoadpurchaseOrderSupplierData(tempDataCollection);



