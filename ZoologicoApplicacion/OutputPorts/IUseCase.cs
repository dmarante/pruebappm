using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoo.Application.Common;

namespace Zoo.Application.OutputPorts
{
    public interface IUseCase<in TUseCaseInput>
      where TUseCaseInput : IUseCaseInput

    {

        Task<Result> Execute(TUseCaseInput input);
    }
}
