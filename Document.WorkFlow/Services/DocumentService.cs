using System;
using System.Globalization;
using CsvHelper;
using Document.WorkFlow.Context;
using Document.WorkFlow.Contracts;
using Document.WorkFlow.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Document.WorkFlow.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly PurchaseOrderContext _dbContext;
        private readonly MongoDBService _mongoDBService;

        public DocumentService(MongoDBSettings mongoDBSettings)
        {
            mongoDBSettings = new MongoDBSettings { ConnectionURI = "mongodb+srv://docUser:1234Nero@cluster0.aq0js.mongodb.net/?retryWrites=true&w=majority", CollectionName = "documents", DatabaseName = "doc" };
            _mongoDBService = new MongoDBService(mongoDBSettings);
        }

        public DocumentService(PurchaseOrderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ExtractData<R>(string filePaths, out IEnumerable<R>? extractedData, out List<string> badRecord)
        {
            if (filePaths is null || !filePaths.Any())
                throw new Exception("File path(s) cannot be empty");

            var badData = new List<string>(); ;
            var missingfields = new List<string>(); ;

            IEnumerable<R>? tempDataCollection = null;
            try
            {

                var reader = new StreamReader(path: filePaths);
                var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    BadDataFound = arg => badData.Add(arg.Context.Parser.RawRecord),
                    MissingFieldFound = arg => missingfields.Add(arg.Context.Parser.RawRecord)
                };
                using (var csv = new CsvReader(reader, config))
                {
                    tempDataCollection = csv.GetRecords<R>().ToList();
                }

                extractedData = tempDataCollection;
                badRecord = badData;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        public void TransformData<I, O>(IEnumerable<I>? InDataCollection, out IEnumerable<O>? OutDataCollection)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoadpurchaseOrderData(List<PurchaseOrder> DataCollection)
        {
            try
            {
                var _tempDataCollection = new List<PurchaseOrder>(DataCollection);
                if (_tempDataCollection is null || !_tempDataCollection.Any())
                    return false;
                if (_dbContext != null && _tempDataCollection != null)
                {
                    await _dbContext.PurchaseOrders.AddRangeAsync(DataCollection);
                    _tempDataCollection = null;
                    return _dbContext.SaveChanges() <= 0 ? false : true;
                }
                else if (_mongoDBService != null && _tempDataCollection != null)
                {
                    await _mongoDBService.CreateAsync(_tempDataCollection);
                    _tempDataCollection = null;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> LoadpurchaseOrderLineData(List<PurchaseOrderLine> DataCollection)
        {
            try
            {
                var _tempDataCollection = new List<PurchaseOrderLine>(DataCollection);
                if (_tempDataCollection is null || !_tempDataCollection.Any())
                    return false;

                if (_dbContext != null && _tempDataCollection != null)
                {
                    await _dbContext.PurchaseOrderLines.AddRangeAsync(DataCollection);
                    _tempDataCollection = null;
                    return _dbContext.SaveChanges() <= 0 ? false : true;
                }
                else if (_mongoDBService != null && _tempDataCollection != null)
                {
                    await _mongoDBService.CreateAsync(_tempDataCollection);
                    _tempDataCollection = null;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> LoadpurchaseOrderSupplierData(List<Supplier> DataCollection)
        {
            try
            {
                var _tempDataCollection = new List<Supplier>(DataCollection);
                if (_tempDataCollection is null || !_tempDataCollection.Any())
                    return false;
                if (_dbContext != null && _tempDataCollection != null)
                {
                    await _dbContext.Suppliers.AddRangeAsync(DataCollection);
                    _tempDataCollection = null;
                    return _dbContext.SaveChanges() <= 0 ? false : true;

                }
                else if (_mongoDBService != null && _tempDataCollection != null)
                {
                    await _mongoDBService.CreateAsync(_tempDataCollection);
                    _tempDataCollection = null;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> LoadpurchaseOrderSupplierData(IEnumerable<Supplier> DataCollection)
        {
            try
            {
                var _tempDataCollection = new List<Supplier>(DataCollection);
                if (_tempDataCollection is null || !_tempDataCollection.Any())
                    return false;
                if (_dbContext != null)
                {
                    await _dbContext.Suppliers.AddRangeAsync(DataCollection);
                    var res = _dbContext.SaveChanges();
                    _tempDataCollection = null;
                    return res <= 0 ? false : true;

                }
                else if (_mongoDBService != null)
                {
                    await _mongoDBService.CreateAsync(_tempDataCollection);
                    _tempDataCollection = null;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
