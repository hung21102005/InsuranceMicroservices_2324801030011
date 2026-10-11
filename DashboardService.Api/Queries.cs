using System;
using System.Collections.Generic;

namespace DashboardService.Api.Queries
{
    public enum TimeUnit
    {
        Day,
        Month,
        Year
    }

    public class GetTotalSalesQuery
    {
        public string? ProductCode { get; set; }
        public DateTime? SalesDateFrom { get; set; }
        public DateTime? SalesDateTo { get; set; }
    }

    public class GetTotalSalesResult
    {
        public Dtos.SalesDto Total { get; set; } = new();
        public Dictionary<string, Dtos.SalesDto> PerProductTotal { get; set; } = new();
    }

    public class GetAgentsSalesQuery
    {
        public DateTime? SalesDateFrom { get; set; }
        public DateTime? SalesDateTo { get; set; }
    }

    public class GetAgentsSalesResult
    {
        public Dictionary<string, Dtos.SalesDto> PerAgentTotal { get; set; } = new();
    }

    public class GetSalesTrendsQuery
    {
        public DateTime? SalesDateFrom { get; set; }
        public DateTime? SalesDateTo { get; set; }
        public TimeUnit Unit { get; set; }
    }

    public class GetSalesTrendsResult
    {
        public List<Dtos.PeriodSaleDto> PeriodsSales { get; set; } = new();
    }
}

namespace DashboardService.Api.Queries.Dtos
{
    public class SalesDto
    {
        public decimal PremiumAmount { get; set; }
        public int PoliciesCount { get; set; }
    }

    public class PeriodSaleDto
    {
        public string? Period { get; set; }
        public SalesDto Sales { get; set; } = new();
    }
}

namespace DashboardService
{
    public class DashboardServiceStub { }
}
