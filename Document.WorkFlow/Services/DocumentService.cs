using System;
using System.Globalization;
using CsvHelper;
using Document.WorkFlow.Context;
using Document.WorkFlow.Contracts;
using Document.WorkFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace Document.WorkFlow.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly PurchaseOrderContext _dbContext;

        public DocumentService()
        {
            _dbContext = new PurchaseOrderContext();
        }

        public void ExtractData<R>(List<string> filePaths, out IEnumerable<R>? extractedData)
        {
            if (filePaths is null || !filePaths.Any())
                throw new Exception("File path(s) cannot be empty");

            IEnumerable<R>? tempDataCollection = null;
            try
            {
                filePaths.ForEach(filePath =>
                {
                    if (!Path.GetExtension(filePath).Equals(".csv"))
                    {
                        throw new Exception("File type not supported.");
                    }

                    var reader = new StreamReader(path: filePath);

                    var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture) { BadDataFound = null };
                    var csvDochelper = new CsvReader(reader, config);

                    tempDataCollection = csvDochelper.GetRecords<R>();

                });

                extractedData = tempDataCollection;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //tempDataCollection = null;
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

                await _dbContext.PurchaseOrders.AddRangeAsync(DataCollection);
                _tempDataCollection = null;
                return _dbContext.SaveChanges() <= 0 ? false : true;
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

                await _dbContext.PurchaseOrderLines.AddRangeAsync(DataCollection);
                _tempDataCollection = null;
                return _dbContext.SaveChanges() <= 0 ? false : true;
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

                await _dbContext.Suppliers.AddRangeAsync(DataCollection);
                _tempDataCollection = null;
                return _dbContext.SaveChanges() <= 0 ? false : true;
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

                await _dbContext.Suppliers.AddRangeAsync(DataCollection);
                _tempDataCollection = null;
                var res = _dbContext.SaveChanges();
                return res <= 0 ? false : true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
