﻿using PipServices.Commons.Data;

using System.Threading.Tasks;

namespace PipServices.Quotes.Client.Version1
{
    public interface IQuotesClientV1
    {
        Task<DataPage<QuoteV1>> GetQuotesAsync(string correlationId, FilterParams filter, PagingParams paging);
        Task<QuoteV1> GetRandomQuoteAsync(string correlationId, FilterParams filter);
        Task<QuoteV1> GetQuoteByIdAsync(string correlationId, string quoteId);
        Task<QuoteV1> CreateQuoteAsync(string correlationId, QuoteV1 quote);
        Task<QuoteV1> UpdateQuoteAsync(string correlationId, QuoteV1 quote);
        Task<QuoteV1> DeleteQuoteByIdAsync(string correlationId, string quoteId);
    }
}
