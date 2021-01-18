using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Application.OutputPorts;

namespace Zoo.Application.UseCase.Animal.GetAnimal
{
    public class GetAnimalInput : IUseCaseInput
    {
        public int? Id { get; }
        public int PageNumber { get;  } = 1;
        public string Search { get;  }
        public int PageSize { get; }

        public GetAnimalInput( int? id, int pageNumber, int pageSize, string search)
        {
            this.Id = id;
            this.PageNumber = pageNumber;
            this.Search = search;
            this.PageSize = pageSize;

        }
    }
}
