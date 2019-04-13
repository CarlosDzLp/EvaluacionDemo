using System;
using System.Threading.Tasks;

namespace EvaluacionDemo.Helpers
{
    public interface ISnackBar
    {
        Task SnackSuccess(string message);
        Task SnackError(string message);
    }
}
