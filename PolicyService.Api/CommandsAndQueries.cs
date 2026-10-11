using System;
using System.Collections.Generic;
using PolicyService.Api.Commands.Dtos;

namespace PolicyService.Api.Commands
{
    public class CreateOfferCommand
    {
        public string? ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; } = new();
        public List<QuestionAnswer> Answers { get; set; } = new();
    }

    public class CreateOfferResult
    {
        public string? OfferNumber { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class CreatePolicyCommand
    {
        public string? OfferNumber { get; set; }
        public PersonDto? PolicyHolder { get; set; }
        public AddressDto? PolicyHolderAddress { get; set; }
    }

    public class CreatePolicyResult
    {
        public string? PolicyNumber { get; set; }
    }
}

namespace PolicyService.Api.Commands.Dtos
{
    public enum QuestionType
    {
        Choice,
        Numeric
    }

    public class QuestionAnswer
    {
        public string? QuestionCode { get; set; }
        public QuestionType QuestionType { get; set; }
    }

    public class ChoiceQuestionAnswer : QuestionAnswer
    {
        public string? Answer { get; set; }
        public ChoiceQuestionAnswer() { QuestionType = QuestionType.Choice; }
    }

    public class NumericQuestionAnswer : QuestionAnswer
    {
        public decimal Answer { get; set; }
        public NumericQuestionAnswer() { QuestionType = QuestionType.Numeric; }
    }

    public class PersonDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TaxId { get; set; }
    }

    public class AddressDto
    {
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
    }
}

namespace PolicyService.Api.Queries
{
    public class PolicyDto
    {
        public string? Number { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string? PolicyHolder { get; set; }
        public decimal TotalPremium { get; set; }
        public string? ProductCode { get; set; }
        public List<string> Covers { get; set; } = new();
    }

    public class GetPolicyDetailsQueryResult
    {
        public PolicyDto Policy { get; set; } = new();
    }
}
