using System;
using MediatR;
using PolicyService.Api.Commands.Dtos;

namespace PolicyService.Api.Events;

public class PolicyCreated : INotification
{
    public string PolicyNumber { get; set; } = string.Empty;
    public DateTime PolicyFrom { get; set; }
    public DateTime PolicyTo { get; set; }
    public PersonDto PolicyHolder { get; set; } = new();
    public string ProductCode { get; set; } = string.Empty;
    public decimal TotalPremium { get; set; }
    public string AgentLogin { get; set; } = string.Empty;

    public PolicyCreated() { }

    public PolicyCreated(string policyNumber, DateTime policyFrom, DateTime policyTo, PersonDto policyHolder, string productCode, decimal totalPremium, string agentLogin)
    {
        PolicyNumber = policyNumber;
        PolicyFrom = policyFrom;
        PolicyTo = policyTo;
        PolicyHolder = policyHolder;
        ProductCode = productCode;
        TotalPremium = totalPremium;
        AgentLogin = agentLogin;
    }
}
