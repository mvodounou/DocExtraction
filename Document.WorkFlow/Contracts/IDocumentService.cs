﻿using System;
using Document.WorkFlow.Models;

namespace Document.WorkFlow.Contracts
{
    public interface IDocumentService
    {
        Task<bool> LoadpurchaseOrderData(List<PurchaseOrder> DataCollection);
        Task<bool> LoadpurchaseOrderLineData(List<PurchaseOrderLine> DataCollection);
        Task<bool> LoadpurchaseOrderSupplierData(List<Supplier> DataCollection);
        void ExtractData<R>(List<string> filePath, out IEnumerable<R>? extractedData);
        void TransformData<I, O>(IEnumerable<I>? InDataCollection, out IEnumerable<O>? OutDataCollection);
    }
}

