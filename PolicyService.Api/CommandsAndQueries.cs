using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;
using PolicyService.Api.Converters;
using PolicyService.Api.Commands.Dtos;

namespace PolicyService.Api.Commands
{
    public class CreateOfferCommand : IRequest<CreateOfferResult>
    {
        public string? ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; } = new();
        public List<QuestionAnswer> Answers { get; set; } = new();
    }

    public class CreateOfferByAgentCommand : CreateOfferCommand, IRequest<CreateOfferResult>
    {
        public CreateOfferByAgentCommand(string agentLogin, CreateOfferCommand command)
        {
            AgentLogin = agentLogin;
            ProductCode = command.ProductCode;
            PolicyFrom = command.PolicyFrom;
            PolicyTo = command.PolicyTo;
            SelectedCovers = command.SelectedCovers;
            Answers = command.Answers;
        }

        public string AgentLogin { get; set; }
    }

    public class CreateOfferResult
    {
        public string? OfferNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public Dictionary<string, decimal> CoversPrices { get; set; } = new();

        public static CreateOfferResult Empty() => new();
    }

    public class CreatePolicyCommand : IRequest<CreatePolicyResult>
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
        Text,
        Numeric,
        Choice
    }

    [JsonConverter(typeof(QuestionAnswerConverter))]
    public abstract class QuestionAnswer
    {
        public string? QuestionCode { get; set; }
        public abstract QuestionType QuestionType { get; }
        public abstract object GetAnswer();
    }

    public abstract class QuestionAnswer<T> : QuestionAnswer
    {
        public T Answer { get; set; } = default!;
        public override object GetAnswer() => Answer!;
    }

    public class TextQuestionAnswer : QuestionAnswer<string>
    {
        public override QuestionType QuestionType => QuestionType.Text;
    }

    public class ChoiceQuestionAnswer : QuestionAnswer<string>
    {
        public override QuestionType QuestionType => QuestionType.Choice;
    }

    public class NumericQuestionAnswer : QuestionAnswer<decimal>
    {
        public override QuestionType QuestionType => QuestionType.Numeric;
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
        public PolicyService.Api.Queries.Dto.PolicyDetailsDto Policy { get; set; } = new();
    }
}
