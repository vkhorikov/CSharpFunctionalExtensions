using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Examples.ResultExtensions.Methods
{
    public class BindZipExamples
    {
        public async Task BindZipAsyncSample()
        {
            await FetchFirstEntity()
                .BindZip(FetchSecondEntity)
                .Map(x => $"{x.First}, {x.Second}!");

            return;

            Task<Result<string>> FetchFirstEntity() =>
                Task.FromResult(Result.Success("Hello"));

            Result<string> FetchSecondEntity(string _) =>
                "World";
        }
    }
}
