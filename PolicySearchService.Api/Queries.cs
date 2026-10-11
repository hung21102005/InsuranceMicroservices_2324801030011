using System;
using System.Collections.Generic;
using PolicySearchService.Api.Queries.Dtos;

namespace PolicySearchService.Api.Queries
{
    public class FindPolicyResult
    {
        public List<PolicyDto> Policies { get; set; } = new();
    }
}

namespace PolicySearchService.Api.Queries.Dtos
{
    public class PolicyDto
    {
        public string? PolicyNumber { get; set; }
        public string? ProductCode { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public string? PolicyHolder { get; set; }
        public decimal PremiumAmount { get; set; }
    }
}
