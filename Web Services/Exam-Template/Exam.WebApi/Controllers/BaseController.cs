using System.Web.Http;

using Exam.Data;
using Exam.WebApi.Infrastructure;

namespace Exam.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        protected IExamData data;
        protected IUserIdProvider provider;

        public BaseController(IExamData data, IUserIdProvider provider)
        {
            this.data = data;
            this.provider = provider;
        }
    }
}