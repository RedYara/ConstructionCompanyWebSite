using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.Order.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandHandler(IWebDbContext dbContext, IMailSender mailSender) : IRequestHandler<ChangeOrderStatusCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;
        private readonly IMailSender _mailSender = mailSender;

        public async Task<bool> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
            switch (request.Value)
            {
                case "В обработке":
                    await _mailSender.SendEmailAsync(order.Email, $"Информация по заказу #{order.Id}", $"Ваш заказ находится в обработке, ожидайте обратной связи.");
                    break;
                case "Выполнен":
                    await _mailSender.SendEmailAsync(order.Email, $"Информация по заказу #{order.Id}", $"Ваш заказ выполнен, ждём вас снова!");
                    break;
                case "Отклонен":
                    await _mailSender.SendEmailAsync(order.Email, $"Информация по заказу #{order.Id}", $"Ваш заказ отклонен, для уточнения подробностей Вы можете связаться с нами по телефону.");
                    break;
                default:
                    break;
            }
            order.Status = request.Value;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
