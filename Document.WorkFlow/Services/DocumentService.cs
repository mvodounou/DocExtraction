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

            //var gb = Path.GetExtension(filePaths[0]);

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

        public IEnumerable<R> ExtractData2<R>(List<string> filePaths)
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

                return tempDataCollection;
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
            if (DataCollection is null || !DataCollection.Any())
                return false;

            _dbContext.PurchaseOrders.AddRange(DataCollection);
            return _dbContext.SaveChanges() <= 0 ? false : true;
        }

        public async Task<bool> LoadpurchaseOrderLineData(List<PurchaseOrderLine> DataCollection)
        {
            if (DataCollection is null || !DataCollection.Any())
                return false;

            _dbContext.PurchaseOrderLines.AddRange(DataCollection);
            return _dbContext.SaveChanges() <= 0 ? false : true;
        }

        public async Task<bool> LoadpurchaseOrderSupplierData(List<Supplier> DataCollection)
        {
            if (DataCollection is null || !DataCollection.Any())
                return false;

            _dbContext.Suppliers.AddRange(DataCollection);
            return _dbContext.SaveChanges() <= 0 ? false : true;
        }

        public async Task<bool> LoadpurchaseOrderSupplierData(IEnumerable<Supplier> DataCollection)
        {
            if (DataCollection is null || !DataCollection.Any())
                return false;

            _dbContext.Suppliers.AddRange(DataCollection);
            return _dbContext.SaveChanges() <= 0 ? false : true;
        }
    }
}

