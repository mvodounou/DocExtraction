using System;
using Document.WorkFlow.Models;

namespace Document.WorkFlow.Contracts
{
    public interface IDocumentService
    {
        Task<bool> LoadpurchaseOrderData(List<PurchaseOrder> DataCollection);
        Task<bool> LoadpurchaseOrderLineData(List<PurchaseOrderLine> DataCollection);
        Task<bool> LoadpurchaseOrderSupplierData(List<Supplier> DataCollection);
        void ExtractData<R>(string filePath, out IEnumerable<R>? extractedData, out List<string> badRecord);
        void TransformData<I, O>(IEnumerable<I>? InDataCollection, out IEnumerable<O>? OutDataCollection);
    }
}

