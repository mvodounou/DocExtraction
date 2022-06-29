using System;
using System.Globalization;
using System.Text.Json;
using Document.WorkFlow.Contracts;
using Document.WorkFlow.Models;
using Document.WorkFlow.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<IDocumentService, DocumentService>())
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBService>();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Started");

var documentService = new DocumentService(new MongoDBSettings());

IEnumerable<Supplier>? tempDataCollection = null;
IEnumerable<PurchaseOrder>? tempOrderDataCollection = null;
IEnumerable<PurchaseOrderLine>? tempOrderlineDataCollection = null;

var countbadSupplierrecords = new List<string>();
var countbadOrderrecords = new List<string>();
var countbadOrderLinerecords = new List<string>();

documentService.ExtractData<Supplier>(filePaths: "Suppliers.csv", out tempDataCollection, out countbadSupplierrecords);
documentService.ExtractData<PurchaseOrder>(filePaths: "PurchaseOrders.csv", out tempOrderDataCollection, out countbadOrderrecords);
documentService.ExtractData<PurchaseOrderLine>(filePaths: "PurchaseOrderLines.csv", out tempOrderlineDataCollection, out countbadOrderLinerecords);

Console.WriteLine("Supplier Data Report");
Console.WriteLine($"Bad Record count:{countbadSupplierrecords.Count}");
Console.WriteLine($"Records: \n {JsonConvert.SerializeObject(countbadSupplierrecords)}");
Console.WriteLine("Orders Data Report");
Console.WriteLine($"Bad Record count:{countbadOrderrecords.Count}");
Console.WriteLine($"Records: \n {JsonConvert.SerializeObject(countbadOrderrecords)}");
Console.WriteLine("Orderline Data Report");
Console.WriteLine($"Bad Record count:{countbadOrderLinerecords.Count}");
Console.WriteLine($"Records: \n {JsonConvert.SerializeObject(countbadOrderLinerecords)}");

Console.WriteLine("Loading to  database");
await documentService.LoadpurchaseOrderSupplierData(tempDataCollection);
await documentService.LoadpurchaseOrderData(new List<PurchaseOrder>(tempOrderDataCollection));
await documentService.LoadpurchaseOrderLineData(new List<PurchaseOrderLine>(tempOrderlineDataCollection));
Console.WriteLine("Loading complete");


var orders = tempOrderDataCollection.Where(d => d.SearchString?.Split('|')[0].TrimEnd() != string.Empty && (DaysDifference(DateTime.ParseExact(d?.SearchString?.Split('|')[0]?.TrimEnd(), format: "dd-MM-yyyy", provider: System.Globalization.CultureInfo.InvariantCulture), DateTime.Now) <= 90));


Console.WriteLine($"Purchase Records for the last 90 days: \n {JsonConvert.SerializeObject(orders)}");


int DaysDifference(DateTime startDate, DateTime endDate)
{
    TimeSpan timespan = endDate.Subtract(startDate);
    return (int)timespan.TotalDays;
}


