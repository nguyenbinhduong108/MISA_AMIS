using MISA.AspNetcore.Domain;
using System;

namespace MISA.AspNetcore
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Console.WriteLine(exception);
            context.Response.ContentType = "application/json";


            switch (exception) 
            {
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync(
                        text: new BaseException()
                        {
                            ErrorCode = ((NotFoundException)exception).ErrorCode,
                            DevMessage = "Không tìm thấy tài nguyên",
                            UserMessage = exception.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = exception.HelpLink
                        }.ToString() ?? ""
                    );
                    break;

                case ConflictException:
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    await context.Response.WriteAsync(
                        text: new BaseException()
                        {
                            ErrorCode = ((ConflictException)exception).ErrorCode,
                            DevMessage = "Tài nguyên bị trùng",
                            UserMessage = exception.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = exception.HelpLink
                        }.ToString() ?? ""
                    );
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync(
                        text: new BaseException()
                        {
                            ErrorCode = ((NotFoundException)exception).ErrorCode,
                            UserMessage = "Lỗi hệ thống",
#if DEBUG
                            DevMessage = exception.Message,
#else
                        DevMessage = "",
#endif
                            TraceId = context.TraceIdentifier,
                            MoreInfo = exception.HelpLink
                        }.ToString() ?? ""
                    );
                    break;
            }
        }
    }
}