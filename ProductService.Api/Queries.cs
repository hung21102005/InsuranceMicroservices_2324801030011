using System.Collections.Generic;

namespace ProductService.Api.Queries
{
}

namespace ProductService.Api.Queries.Dtos
{
    public class CoverDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public decimal? SumInsured { get; set; }
    }

    public class ChoiceDto
    {
        public string? Code { get; set; }
        public string? Label { get; set; }
    }

    public class QuestionDto
    {
        public string? QuestionCode { get; set; }
        public string? Text { get; set; }
    }

    public class ChoiceQuestionDto : QuestionDto
    {
        public IList<ChoiceDto> Choices { get; set; } = new List<ChoiceDto>();
    }

    public class NumericQuestionDto : QuestionDto
    {
    }

    public class ProductDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public decimal MaxPrice { get; set; }
        public List<QuestionDto> Questions { get; set; } = new();
        public List<CoverDto> Covers { get; set; } = new();
    }
}
