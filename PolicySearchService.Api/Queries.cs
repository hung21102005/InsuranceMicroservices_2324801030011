using System;
using System.Collections.Generic;
using System;
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
        public DateTimeOffset PolicyStartDate { get; set; }
        public DateTimeOffset PolicyEndDate { get; set; }
        public string? PolicyHolder { get; set; }
        public decimal PremiumAmount { get; set; }
    }
}
